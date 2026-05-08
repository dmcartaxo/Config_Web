using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace Config_Web
{
    public partial class MainForm : Form
    {
        private WebConfigService _service;
        private string _originalFilePath;
        private string _tempFolderPath;
        private List<ConnectionStringEntry> _connectionStrings = new List<ConnectionStringEntry>();

        public MainForm()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(MainForm_FormClosed);
        }

        // ─── Arquivo ──────────────────────────────────────────────────────────────

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title  = "Selecione o arquivo Web.Config";
                dlg.Filter = "Web.Config|Web.Config;web.config|Arquivos XML|*.xml|Todos os arquivos|*.*";
                dlg.CheckFileExists = true;

                if (dlg.ShowDialog() == DialogResult.OK)
                    LoadConfig(dlg.FileName);
            }
        }

        private void LoadConfig(string filePath)
        {
            try
            {
                CleanupTempFolder();

                string tempFilePath = WebConfigService.CreateTempFile(filePath);
                _originalFilePath = filePath;
                _tempFolderPath   = Path.GetDirectoryName(tempFilePath);

                // Verifica estado de criptografia na copia (igual ao original)
                WebConfigService tempCheck = new WebConfigService(tempFilePath);
                bool csWasEncrypted  = tempCheck.IsSectionEncrypted("connectionStrings");
                bool apiWasEncrypted = tempCheck.IsSectionEncrypted("apiConfig");

                // Tenta descriptografar secoes no arquivo temporario
                if (csWasEncrypted || apiWasEncrypted)
                {
                    EncryptionService encSvc = new EncryptionService(_tempFolderPath);

                    if (csWasEncrypted)
                    {
                        try { encSvc.Decrypt("connectionStrings"); }
                        catch { /* mantém criptografado se falhar (maquina diferente) */ }
                    }

                    if (apiWasEncrypted)
                    {
                        try { encSvc.Decrypt("apiConfig"); }
                        catch { /* mantém criptografado se falhar */ }
                    }
                }

                _service = new WebConfigService(tempFilePath);

                txtConfigPath.Text        = filePath;
                txtTempFile.Text          = tempFilePath;
                tabControl.Enabled        = true;
                btnSalvarOriginal.Enabled = true;

                // Checkbox marcado = secao estava criptografada e foi descriptografada
                // = deve ser re-criptografada ao gravar no arquivo original
                bool csStillEncrypted  = _service.IsSectionEncrypted("connectionStrings");
                bool apiStillEncrypted = _service.IsSectionEncrypted("apiConfig");

                chkEncryptCS.Checked  = csWasEncrypted  && !csStillEncrypted;
                chkEncryptApi.Checked = apiWasEncrypted && !apiStillEncrypted;

                RefreshConnectionStringsTab();
                RefreshApiConfigTab();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar o arquivo:\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CleanupTempFolder()
        {
            if (!string.IsNullOrEmpty(_tempFolderPath) && Directory.Exists(_tempFolderPath))
            {
                try { Directory.Delete(_tempFolderPath, true); }
                catch { }
                _tempFolderPath = null;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CleanupTempFolder();
        }

        private bool HasFile()
        {
            return _service != null && File.Exists(_service.FilePath);
        }

        // ─── Aba: Connection Strings ──────────────────────────────────────────────

        private void RefreshConnectionStringsTab()
        {
            bool encrypted = _service.IsSectionEncrypted("connectionStrings");

            pnlCsWarning.Visible = encrypted;
            SetConnectionStringsEditable(!encrypted);

            lvConnections.Items.Clear();
            _connectionStrings.Clear();
            txtConnectionString.Clear();

            if (encrypted) return;

            try
            {
                _connectionStrings = _service.LoadConnectionStrings();
                RebuildConnectionListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SetConnectionStringsEditable(bool editable)
        {
            lvConnections.Enabled       = editable;
            txtConnectionString.Enabled = editable;
            btnAddUpdate.Enabled        = editable;
            btnRemove.Enabled           = editable;
            btnTestConnection.Enabled   = editable;
            btnSaveCS.Enabled           = editable;
            chkEncryptCS.Enabled        = editable;
        }

        private void RebuildConnectionListView()
        {
            lvConnections.Items.Clear();
            foreach (ConnectionStringEntry entry in _connectionStrings)
            {
                ListViewItem item = new ListViewItem(entry.Name);
                item.SubItems.Add(entry.ProviderName);
                item.SubItems.Add(entry.ConnectionString);
                item.Tag = entry;
                lvConnections.Items.Add(item);
            }
        }

        private void lvConnections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvConnections.SelectedItems.Count == 0)
            {
                txtConnectionString.Clear();
                return;
            }

            ConnectionStringEntry entry = (ConnectionStringEntry)lvConnections.SelectedItems[0].Tag;
            txtConnectionString.Text = BuildXmlLine(entry);
        }

        private string BuildXmlLine(ConnectionStringEntry entry)
        {
            return string.Format(
                "<add name=\"{0}\" connectionString=\"{1}\" providerName=\"{2}\" />",
                entry.Name, entry.ConnectionString, entry.ProviderName);
        }

        private void btnAddUpdate_Click(object sender, EventArgs e)
        {
            string xml = txtConnectionString.Text.Trim();
            if (string.IsNullOrEmpty(xml))
            {
                MessageBox.Show(
                    "Cole a string de conexao no formato XML.\nExemplo:\n" +
                    "<add name=\"001\" connectionString=\"Provider=...\" providerName=\"System.Data.OleDb\" />",
                    "Instrucao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ConnectionStringEntry parsed;
            try
            {
                parsed = ParseConnectionStringXml(xml);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Formato invalido:\n" + ex.Message,
                    "Erro de Parse", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(parsed.Name) || parsed.Name.Trim().Length == 0)
            {
                MessageBox.Show(
                    "O atributo 'name' e obrigatorio.",
                    "Validacao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(parsed.ConnectionString))
            {
                MessageBox.Show(
                    "O atributo 'connectionString' e obrigatorio.",
                    "Validacao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ConnectionStringEntry existing = null;
            foreach (ConnectionStringEntry c in _connectionStrings)
            {
                if (c.Name == parsed.Name) { existing = c; break; }
            }

            if (existing != null)
            {
                existing.ConnectionString = parsed.ConnectionString;
                existing.ProviderName     = parsed.ProviderName;
                MessageBox.Show(
                    string.Format("Conexao '{0}' atualizada na lista.\nClique em Salvar para gravar no arquivo temporario.", parsed.Name),
                    "Atualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _connectionStrings.Add(parsed);
                MessageBox.Show(
                    string.Format("Conexao '{0}' adicionada na lista.\nClique em Salvar para gravar no arquivo temporario.", parsed.Name),
                    "Adicionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            RebuildConnectionListView();
            txtConnectionString.Clear();
        }

        private ConnectionStringEntry ParseConnectionStringXml(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<root>" + xml + "</root>");

            XmlNode node = doc.SelectSingleNode("/root/add");
            if (node == null)
                throw new FormatException(
                    "Elemento <add> nao encontrado. Use o formato:\n" +
                    "<add name=\"...\" connectionString=\"...\" providerName=\"...\" />");

            return new ConnectionStringEntry
            {
                Name             = GetAttr(node, "name"),
                ConnectionString = GetAttr(node, "connectionString"),
                ProviderName     = GetAttr(node, "providerName")
            };
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lvConnections.SelectedItems.Count == 0)
            {
                MessageBox.Show(
                    "Selecione uma conexao para remover.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_connectionStrings.Count <= 1)
            {
                MessageBox.Show(
                    "Deve haver pelo menos uma conexao registrada. Nao e possivel remover a ultima.",
                    "Validacao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ConnectionStringEntry entry = (ConnectionStringEntry)lvConnections.SelectedItems[0].Tag;

            DialogResult confirm = MessageBox.Show(
                string.Format("Remover a conexao '{0}'?", entry.Name),
                "Confirmar Remocao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                _connectionStrings.Remove(entry);
                RebuildConnectionListView();
                txtConnectionString.Clear();
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            if (lvConnections.SelectedItems.Count == 0)
            {
                MessageBox.Show(
                    "Selecione uma conexao para testar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ConnectionStringEntry entry = (ConnectionStringEntry)lvConnections.SelectedItems[0].Tag;

            Cursor = Cursors.WaitCursor;
            try
            {
                DatabaseTestService.Test(entry);
                MessageBox.Show(
                    string.Format("Conexao com '{0}' estabelecida com sucesso!", entry.Name),
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("Falha ao conectar com '{0}':\n\n{1}", entry.Name, ex.Message),
                    "Falha na Conexao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnSaveCS_Click(object sender, EventArgs e)
        {
            if (_connectionStrings.Count == 0)
            {
                MessageBox.Show(
                    "Deve haver pelo menos uma conexao registrada.",
                    "Validacao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _service.SaveConnectionStrings(_connectionStrings);
                MessageBox.Show(
                    "Connection Strings salvas no arquivo temporario.\n" +
                    "Clique em 'Salvar no Arquivo Selecionado' para aplicar ao arquivo original.",
                    "Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao salvar:\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── Aba: API Config ──────────────────────────────────────────────────────

        private void RefreshApiConfigTab()
        {
            bool encrypted = _service.IsSectionEncrypted("apiConfig");

            pnlApiWarning.Visible = encrypted;
            SetApiConfigEditable(!encrypted);

            txtApiKey.Clear();
            lblApiKeyLength.Text = "Comprimento: 0 caracteres";

            if (encrypted) return;

            try
            {
                string key = _service.LoadApiKey();
                txtApiKey.Text = key;
                UpdateApiKeyLength();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SetApiConfigEditable(bool editable)
        {
            txtApiKey.Enabled      = editable;
            btnGenerateKey.Enabled = editable;
            btnSaveApi.Enabled     = editable;
            chkEncryptApi.Enabled  = editable;
        }

        private void btnGenerateKey_Click(object sender, EventArgs e)
        {
            string key = ApiKeyGenerator.Generate();
            txtApiKey.Text = key;
            UpdateApiKeyLength();
        }

        private void txtApiKey_TextChanged(object sender, EventArgs e)
        {
            UpdateApiKeyLength();
        }

        private void UpdateApiKeyLength()
        {
            int len = txtApiKey.Text.Length;
            lblApiKeyLength.Text = string.Format("Comprimento: {0} caracteres", len);
            lblApiKeyLength.ForeColor = (len == 128) ? Color.DarkGreen : Color.DimGray;
        }

        private void btnSaveApi_Click(object sender, EventArgs e)
        {
            string key = txtApiKey.Text.Trim();

            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show(
                    "A chave API nao pode ser vazia.",
                    "Validacao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _service.SaveApiKey(key);
                MessageBox.Show(
                    "Chave API salva no arquivo temporario.\n" +
                    "Clique em 'Salvar no Arquivo Selecionado' para aplicar ao arquivo original.",
                    "Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao salvar:\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── Gravar no arquivo original ───────────────────────────────────────────

        private void btnSalvarOriginal_Click(object sender, EventArgs e)
        {
            if (!HasFile()) return;

            DialogResult confirm = MessageBox.Show(
                string.Format(
                    "Gravar o arquivo temporario sobre o arquivo selecionado?\n\n" +
                    "Destino: {0}\n\n" +
                    "Criptografia ao gravar:\n" +
                    "  Connection Strings : {1}\n" +
                    "  API Config         : {2}",
                    _originalFilePath,
                    chkEncryptCS.Checked  ? "Sera criptografada"      : "Nao sera criptografada",
                    chkEncryptApi.Checked ? "Sera criptografada"      : "Nao sera criptografada"),
                "Confirmar Gravacao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            Cursor = Cursors.WaitCursor;
            try
            {
                File.Copy(_service.FilePath, _originalFilePath, true);

                if (chkEncryptCS.Checked || chkEncryptApi.Checked)
                {
                    EncryptionService encSvc = new EncryptionService(
                        Path.GetDirectoryName(_originalFilePath));

                    if (chkEncryptCS.Checked)
                        encSvc.Encrypt("connectionStrings");

                    if (chkEncryptApi.Checked)
                        encSvc.Encrypt("apiConfig");
                }

                MessageBox.Show(
                    "Arquivo salvo com sucesso em:\n" + _originalFilePath,
                    "Concluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao salvar no arquivo original:\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // ─── Utilitario ───────────────────────────────────────────────────────────

        private static string GetAttr(XmlNode node, string name)
        {
            if (node == null || node.Attributes == null) return string.Empty;
            XmlAttribute attr = node.Attributes[name];
            return attr != null ? attr.Value : string.Empty;
        }
    }
}
