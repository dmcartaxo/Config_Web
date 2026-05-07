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
        private List<ConnectionStringEntry> _connectionStrings = new List<ConnectionStringEntry>();

        public MainForm()
        {
            InitializeComponent();
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
                _service = new WebConfigService(filePath);
                txtConfigPath.Text = filePath;
                tabControl.Enabled = true;

                RefreshConnectionStringsTab();
                RefreshApiConfigTab();
                RefreshEncryptionTab();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar o arquivo:\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            lvConnections.Enabled      = editable;
            txtConnectionString.Enabled = editable;
            btnAddUpdate.Enabled       = editable;
            btnRemove.Enabled          = editable;
            btnTestConnection.Enabled  = editable;
            btnSaveCS.Enabled          = editable;
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
                    string.Format("Conexao '{0}' atualizada na lista.\nClique em Salvar para gravar no arquivo.", parsed.Name),
                    "Atualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _connectionStrings.Add(parsed);
                MessageBox.Show(
                    string.Format("Conexao '{0}' adicionada na lista.\nClique em Salvar para gravar no arquivo.", parsed.Name),
                    "Adicionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            RebuildConnectionListView();
            txtConnectionString.Clear();
        }

        private ConnectionStringEntry ParseConnectionStringXml(string xml)
        {
            // Envolve em uma tag raiz para formar XML valido
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
                    "Connection Strings salvas com sucesso.",
                    "Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshEncryptionTab();
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
                    "Chave API salva com sucesso.",
                    "Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshEncryptionTab();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao salvar:\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── Aba: Criptografia ────────────────────────────────────────────────────

        private void RefreshEncryptionTab()
        {
            if (!HasFile()) return;

            UpdateEncryptionStatus("connectionStrings", lblCsEncStatus, btnEncryptCS, btnDecryptCS);
            UpdateEncryptionStatus("apiConfig",         lblApiEncStatus, btnEncryptApi, btnDecryptApi);
        }

        private void UpdateEncryptionStatus(
            string sectionName,
            System.Windows.Forms.Label statusLabel,
            Button btnEncrypt,
            Button btnDecrypt)
        {
            bool encrypted = _service.IsSectionEncrypted(sectionName);

            if (encrypted)
            {
                statusLabel.Text      = "Status: CRIPTOGRAFADA  [bloqueada]";
                statusLabel.ForeColor = Color.DarkRed;
            }
            else
            {
                statusLabel.Text      = "Status: Descriptografada  [aberta]";
                statusLabel.ForeColor = Color.DarkGreen;
            }

            btnEncrypt.Enabled = !encrypted;
            btnDecrypt.Enabled =  encrypted;
        }

        private void btnEncryptCS_Click(object sender, EventArgs e)
        {
            ToggleEncryption("connectionStrings", true);
        }

        private void btnDecryptCS_Click(object sender, EventArgs e)
        {
            ToggleEncryption("connectionStrings", false);
        }

        private void btnEncryptApi_Click(object sender, EventArgs e)
        {
            ToggleEncryption("apiConfig", true);
        }

        private void btnDecryptApi_Click(object sender, EventArgs e)
        {
            ToggleEncryption("apiConfig", false);
        }

        private void ToggleEncryption(string sectionName, bool encrypt)
        {
            if (!HasFile()) return;

            string action = encrypt ? "criptografar" : "descriptografar";

            DialogResult confirm = MessageBox.Show(
                string.Format("Deseja {0} a secao '{1}'?\n\nEsta operacao utilizara o aspnet_regiis.exe.", action, sectionName),
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            Cursor = Cursors.WaitCursor;
            try
            {
                EncryptionService svc = new EncryptionService(_service.FolderPath);

                if (encrypt)
                    svc.Encrypt(sectionName);
                else
                    svc.Decrypt(sectionName);

                MessageBox.Show(
                    string.Format("Secao '{0}' {1}ada com sucesso.", sectionName, action),
                    "Concluido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Atualiza todas as abas pois o estado do arquivo mudou
                RefreshEncryptionTab();
                RefreshConnectionStringsTab();
                RefreshApiConfigTab();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("Erro ao {0} a secao '{1}':\n\n{2}", action, sectionName, ex.Message),
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
