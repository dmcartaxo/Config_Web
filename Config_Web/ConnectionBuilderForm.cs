using System;
using System.Text;
using System.Windows.Forms;

namespace Config_Web
{
    public partial class ConnectionBuilderForm : Form
    {
        public string ResultXml { get; private set; }

        public ConnectionBuilderForm()
        {
            InitializeComponent();
            cmbProvider.SelectedIndex      = 0;
            cmbOleDbProvider.SelectedIndex = 0;
            rbWinAuth.Checked = true;
            AtualizarVisibilidadeAuth();
        }

        // ─── Eventos de navegacao ─────────────────────────────────────────────────

        private void cmbProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isSql = cmbProvider.SelectedIndex == 0;
            pnlSql.Visible   = isSql;
            pnlOleDb.Visible = !isSql;
        }

        private void rbAuth_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarVisibilidadeAuth();
        }

        private void AtualizarVisibilidadeAuth()
        {
            bool sqlAuth = rbSqlAuth.Checked;
            lblSqlUser.Visible = sqlAuth;
            txtSqlUser.Visible = sqlAuth;
            lblSqlPwd.Visible  = sqlAuth;
            txtSqlPwd.Visible  = sqlAuth;
        }

        // ─── Geracao do XML ───────────────────────────────────────────────────────

        private void btnGerar_Click(object sender, EventArgs e)
        {
            string xml = BuildXml();
            if (xml != null)
                txtPreview.Text = xml;
        }

        private string BuildXml()
        {
            string name = txtName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("O campo 'Name' e obrigatorio.",
                    "Validacao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return null;
            }

            string connStr;
            string providerName;

            if (cmbProvider.SelectedIndex == 0) // SQL Server
            {
                string server = txtServer.Text.Trim();
                string db     = txtDatabase.Text.Trim();

                if (string.IsNullOrEmpty(server))
                {
                    MessageBox.Show("O campo 'Servidor' e obrigatorio.",
                        "Validacao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtServer.Focus();
                    return null;
                }

                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("Server={0};", server);
                if (!string.IsNullOrEmpty(db))
                    sb.AppendFormat("Database={0};", db);

                if (rbWinAuth.Checked)
                {
                    sb.Append("Integrated Security=True;");
                }
                else
                {
                    string user = txtSqlUser.Text.Trim();
                    if (string.IsNullOrEmpty(user))
                    {
                        MessageBox.Show("O campo 'Usuario' e obrigatorio para autenticacao SQL.",
                            "Validacao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSqlUser.Focus();
                        return null;
                    }
                    sb.AppendFormat("User Id={0};Password={1};", user, txtSqlPwd.Text);
                }

                connStr      = sb.ToString().TrimEnd(';');
                providerName = "System.Data.SqlClient";
            }
            else // OleDb
            {
                string dataSource = txtDataSource.Text.Trim();
                if (string.IsNullOrEmpty(dataSource))
                {
                    MessageBox.Show("O campo 'Data Source' e obrigatorio.",
                        "Validacao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDataSource.Focus();
                    return null;
                }

                StringBuilder sb = new StringBuilder();
                string oleProvider = cmbOleDbProvider.Text.Trim();
                if (!string.IsNullOrEmpty(oleProvider))
                    sb.AppendFormat("Provider={0};", oleProvider);
                sb.AppendFormat("Data Source={0};", dataSource);

                string user = txtOleDbUser.Text.Trim();
                if (!string.IsNullOrEmpty(user))
                    sb.AppendFormat("User Id={0};Password={1};", user, txtOleDbPwd.Text);

                connStr      = sb.ToString().TrimEnd(';');
                providerName = "System.Data.OleDb";
            }

            return string.Format(
                "<add name=\"{0}\" connectionString=\"{1}\" providerName=\"{2}\" />",
                name, connStr, providerName);
        }

        // ─── Acoes dos botoes ─────────────────────────────────────────────────────

        private void btnTestarConexao_Click(object sender, EventArgs e)
        {
            string xml = BuildXml();
            if (xml == null) return;

            txtPreview.Text = xml;

            ConnectionStringEntry entry = new ConnectionStringEntry
            {
                Name             = txtName.Text.Trim(),
                ConnectionString = ExtractConnectionString(xml),
                ProviderName     = ExtractProviderName(xml)
            };

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
                    string.Format("Falha ao conectar:\n\n{0}", ex.Message),
                    "Falha na Conexao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private static string ExtractConnectionString(string xml)
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml("<root>" + xml + "</root>");
            System.Xml.XmlNode node = doc.SelectSingleNode("/root/add");
            if (node == null || node.Attributes == null) return string.Empty;
            System.Xml.XmlAttribute attr = node.Attributes["connectionString"];
            return attr != null ? attr.Value : string.Empty;
        }

        private static string ExtractProviderName(string xml)
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml("<root>" + xml + "</root>");
            System.Xml.XmlNode node = doc.SelectSingleNode("/root/add");
            if (node == null || node.Attributes == null) return string.Empty;
            System.Xml.XmlAttribute attr = node.Attributes["providerName"];
            return attr != null ? attr.Value : string.Empty;
        }

        private void btnUsar_Click(object sender, EventArgs e)
        {
            string xml = BuildXml();
            if (xml == null) return;

            ResultXml    = xml;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
