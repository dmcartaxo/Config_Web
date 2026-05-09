namespace Config_Web
{
    partial class ConnectionBuilderForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // ── Instancias ──────────────────────────────────────────────────────────
            this.lblName            = new System.Windows.Forms.Label();
            this.txtName            = new System.Windows.Forms.TextBox();
            this.lblProvider        = new System.Windows.Forms.Label();
            this.cmbProvider        = new System.Windows.Forms.ComboBox();

            // Painel SQL Server
            this.pnlSql             = new System.Windows.Forms.Panel();
            this.lblServer          = new System.Windows.Forms.Label();
            this.txtServer          = new System.Windows.Forms.TextBox();
            this.lblDatabase        = new System.Windows.Forms.Label();
            this.txtDatabase        = new System.Windows.Forms.TextBox();
            this.lblAuth            = new System.Windows.Forms.Label();
            this.rbWinAuth          = new System.Windows.Forms.RadioButton();
            this.rbSqlAuth          = new System.Windows.Forms.RadioButton();
            this.lblSqlUser         = new System.Windows.Forms.Label();
            this.txtSqlUser         = new System.Windows.Forms.TextBox();
            this.lblSqlPwd          = new System.Windows.Forms.Label();
            this.txtSqlPwd          = new System.Windows.Forms.TextBox();

            // Painel OleDb
            this.pnlOleDb           = new System.Windows.Forms.Panel();
            this.lblOleDbProvider   = new System.Windows.Forms.Label();
            this.cmbOleDbProvider   = new System.Windows.Forms.ComboBox();
            this.lblDataSource      = new System.Windows.Forms.Label();
            this.txtDataSource      = new System.Windows.Forms.TextBox();
            this.lblOleDbUser       = new System.Windows.Forms.Label();
            this.txtOleDbUser       = new System.Windows.Forms.TextBox();
            this.lblOleDbPwd        = new System.Windows.Forms.Label();
            this.txtOleDbPwd        = new System.Windows.Forms.TextBox();

            // Preview e botoes
            this.grpPreview         = new System.Windows.Forms.GroupBox();
            this.txtPreview         = new System.Windows.Forms.TextBox();
            this.btnGerar           = new System.Windows.Forms.Button();
            this.btnTestarConexao   = new System.Windows.Forms.Button();
            this.btnUsar            = new System.Windows.Forms.Button();
            this.btnFechar          = new System.Windows.Forms.Button();

            // ── SuspendLayout ───────────────────────────────────────────────────────
            this.pnlSql.SuspendLayout();
            this.pnlOleDb.SuspendLayout();
            this.grpPreview.SuspendLayout();
            this.SuspendLayout();

            // ── lblName ─────────────────────────────────────────────────────────────
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(10, 15);
            this.lblName.Text     = "Name *:";

            // ── txtName ─────────────────────────────────────────────────────────────
            this.txtName.Location = new System.Drawing.Point(160, 12);
            this.txtName.Name     = "txtName";
            this.txtName.Size     = new System.Drawing.Size(350, 22);
            this.txtName.TabIndex = 0;

            // ── lblProvider ─────────────────────────────────────────────────────────
            this.lblProvider.AutoSize = true;
            this.lblProvider.Location = new System.Drawing.Point(10, 48);
            this.lblProvider.Text     = "Tipo de conexao:";

            // ── cmbProvider ─────────────────────────────────────────────────────────
            this.cmbProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvider.Items.AddRange(new object[] { "SQL Server  (SqlClient)", "OleDb  (Oracle, ODBC, Access)" });
            this.cmbProvider.Location = new System.Drawing.Point(160, 45);
            this.cmbProvider.Name     = "cmbProvider";
            this.cmbProvider.Size     = new System.Drawing.Size(240, 22);
            this.cmbProvider.TabIndex = 1;
            this.cmbProvider.SelectedIndexChanged += new System.EventHandler(this.cmbProvider_SelectedIndexChanged);

            // ────────────────────────────────────────────────────────────────────────
            // pnlSql
            // ────────────────────────────────────────────────────────────────────────
            this.pnlSql.Controls.Add(this.lblServer);
            this.pnlSql.Controls.Add(this.txtServer);
            this.pnlSql.Controls.Add(this.lblDatabase);
            this.pnlSql.Controls.Add(this.txtDatabase);
            this.pnlSql.Controls.Add(this.lblAuth);
            this.pnlSql.Controls.Add(this.rbWinAuth);
            this.pnlSql.Controls.Add(this.rbSqlAuth);
            this.pnlSql.Controls.Add(this.lblSqlUser);
            this.pnlSql.Controls.Add(this.txtSqlUser);
            this.pnlSql.Controls.Add(this.lblSqlPwd);
            this.pnlSql.Controls.Add(this.txtSqlPwd);
            this.pnlSql.Location = new System.Drawing.Point(10, 78);
            this.pnlSql.Name     = "pnlSql";
            this.pnlSql.Size     = new System.Drawing.Size(500, 128);

            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(0, 8);
            this.lblServer.Text     = "Servidor / Instancia:";

            this.txtServer.Location = new System.Drawing.Point(160, 5);
            this.txtServer.Name     = "txtServer";
            this.txtServer.Size     = new System.Drawing.Size(336, 22);
            this.txtServer.TabIndex = 0;

            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(0, 38);
            this.lblDatabase.Text     = "Banco de Dados:";

            this.txtDatabase.Location = new System.Drawing.Point(160, 35);
            this.txtDatabase.Name     = "txtDatabase";
            this.txtDatabase.Size     = new System.Drawing.Size(336, 22);
            this.txtDatabase.TabIndex = 1;

            this.lblAuth.AutoSize = true;
            this.lblAuth.Location = new System.Drawing.Point(0, 68);
            this.lblAuth.Text     = "Autenticacao:";

            this.rbWinAuth.AutoSize = true;
            this.rbWinAuth.Location = new System.Drawing.Point(160, 66);
            this.rbWinAuth.Name     = "rbWinAuth";
            this.rbWinAuth.Text     = "Windows (SSPI)";
            this.rbWinAuth.TabIndex = 2;
            this.rbWinAuth.CheckedChanged += new System.EventHandler(this.rbAuth_CheckedChanged);

            this.rbSqlAuth.AutoSize = true;
            this.rbSqlAuth.Location = new System.Drawing.Point(290, 66);
            this.rbSqlAuth.Name     = "rbSqlAuth";
            this.rbSqlAuth.Text     = "SQL Server";
            this.rbSqlAuth.TabIndex = 3;
            this.rbSqlAuth.CheckedChanged += new System.EventHandler(this.rbAuth_CheckedChanged);

            this.lblSqlUser.AutoSize = true;
            this.lblSqlUser.Location = new System.Drawing.Point(0, 98);
            this.lblSqlUser.Text     = "Usuario:";
            this.lblSqlUser.Visible  = false;

            this.txtSqlUser.Location = new System.Drawing.Point(160, 95);
            this.txtSqlUser.Name     = "txtSqlUser";
            this.txtSqlUser.Size     = new System.Drawing.Size(148, 22);
            this.txtSqlUser.TabIndex = 4;
            this.txtSqlUser.Visible  = false;

            this.lblSqlPwd.AutoSize = true;
            this.lblSqlPwd.Location = new System.Drawing.Point(318, 98);
            this.lblSqlPwd.Text     = "Senha:";
            this.lblSqlPwd.Visible  = false;

            this.txtSqlPwd.Location     = new System.Drawing.Point(366, 95);
            this.txtSqlPwd.Name         = "txtSqlPwd";
            this.txtSqlPwd.Size         = new System.Drawing.Size(130, 22);
            this.txtSqlPwd.TabIndex     = 5;
            this.txtSqlPwd.PasswordChar = '*';
            this.txtSqlPwd.Visible      = false;

            // ────────────────────────────────────────────────────────────────────────
            // pnlOleDb
            // ────────────────────────────────────────────────────────────────────────
            this.pnlOleDb.Controls.Add(this.lblOleDbProvider);
            this.pnlOleDb.Controls.Add(this.cmbOleDbProvider);
            this.pnlOleDb.Controls.Add(this.lblDataSource);
            this.pnlOleDb.Controls.Add(this.txtDataSource);
            this.pnlOleDb.Controls.Add(this.lblOleDbUser);
            this.pnlOleDb.Controls.Add(this.txtOleDbUser);
            this.pnlOleDb.Controls.Add(this.lblOleDbPwd);
            this.pnlOleDb.Controls.Add(this.txtOleDbPwd);
            this.pnlOleDb.Location = new System.Drawing.Point(10, 78);
            this.pnlOleDb.Name     = "pnlOleDb";
            this.pnlOleDb.Size     = new System.Drawing.Size(500, 98);
            this.pnlOleDb.Visible  = false;

            this.lblOleDbProvider.AutoSize = true;
            this.lblOleDbProvider.Location = new System.Drawing.Point(0, 8);
            this.lblOleDbProvider.Text     = "Provider OleDb:";

            this.cmbOleDbProvider.Location = new System.Drawing.Point(160, 5);
            this.cmbOleDbProvider.Name     = "cmbOleDbProvider";
            this.cmbOleDbProvider.Size     = new System.Drawing.Size(336, 22);
            this.cmbOleDbProvider.TabIndex = 0;
            this.cmbOleDbProvider.Items.AddRange(new object[] {
                "OraOLEDB.Oracle",
                "MSDAORA.1",
                "SQLNCLI11",
                "Microsoft.ACE.OLEDB.12.0",
                "MSDASQL"
            });

            this.lblDataSource.AutoSize = true;
            this.lblDataSource.Location = new System.Drawing.Point(0, 38);
            this.lblDataSource.Text     = "Data Source:";

            this.txtDataSource.Location = new System.Drawing.Point(160, 35);
            this.txtDataSource.Name     = "txtDataSource";
            this.txtDataSource.Size     = new System.Drawing.Size(336, 22);
            this.txtDataSource.TabIndex = 1;

            this.lblOleDbUser.AutoSize = true;
            this.lblOleDbUser.Location = new System.Drawing.Point(0, 68);
            this.lblOleDbUser.Text     = "Usuario (UID):";

            this.txtOleDbUser.Location = new System.Drawing.Point(160, 65);
            this.txtOleDbUser.Name     = "txtOleDbUser";
            this.txtOleDbUser.Size     = new System.Drawing.Size(148, 22);
            this.txtOleDbUser.TabIndex = 2;

            this.lblOleDbPwd.AutoSize = true;
            this.lblOleDbPwd.Location = new System.Drawing.Point(318, 68);
            this.lblOleDbPwd.Text     = "Senha (PWD):";

            this.txtOleDbPwd.Location     = new System.Drawing.Point(400, 65);
            this.txtOleDbPwd.Name         = "txtOleDbPwd";
            this.txtOleDbPwd.Size         = new System.Drawing.Size(96, 22);
            this.txtOleDbPwd.TabIndex     = 3;
            this.txtOleDbPwd.PasswordChar = '*';

            // ────────────────────────────────────────────────────────────────────────
            // grpPreview
            // ────────────────────────────────────────────────────────────────────────
            this.grpPreview.Controls.Add(this.txtPreview);
            this.grpPreview.Controls.Add(this.btnGerar);
            this.grpPreview.Controls.Add(this.btnTestarConexao);
            this.grpPreview.Location = new System.Drawing.Point(10, 218);
            this.grpPreview.Name     = "grpPreview";
            this.grpPreview.Size     = new System.Drawing.Size(500, 108);
            this.grpPreview.Text     = "Connection String XML gerada:";

            this.txtPreview.BackColor   = System.Drawing.SystemColors.Window;
            this.txtPreview.Font        = new System.Drawing.Font("Courier New", 8f);
            this.txtPreview.Location    = new System.Drawing.Point(8, 22);
            this.txtPreview.Multiline   = true;
            this.txtPreview.Name        = "txtPreview";
            this.txtPreview.ReadOnly    = true;
            this.txtPreview.ScrollBars  = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPreview.Size        = new System.Drawing.Size(370, 74);
            this.txtPreview.TabIndex    = 0;
            this.txtPreview.WordWrap    = true;

            this.btnGerar.Location = new System.Drawing.Point(386, 22);
            this.btnGerar.Name     = "btnGerar";
            this.btnGerar.Size     = new System.Drawing.Size(106, 30);
            this.btnGerar.TabIndex = 1;
            this.btnGerar.Text     = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click   += new System.EventHandler(this.btnGerar_Click);

            this.btnTestarConexao.Location = new System.Drawing.Point(386, 58);
            this.btnTestarConexao.Name     = "btnTestarConexao";
            this.btnTestarConexao.Size     = new System.Drawing.Size(106, 30);
            this.btnTestarConexao.TabIndex = 2;
            this.btnTestarConexao.Text     = "Testar Conexao";
            this.btnTestarConexao.UseVisualStyleBackColor = true;
            this.btnTestarConexao.Click   += new System.EventHandler(this.btnTestarConexao_Click);

            // ── btnUsar ─────────────────────────────────────────────────────────────
            this.btnUsar.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnUsar.ForeColor = System.Drawing.Color.White;
            this.btnUsar.Font      = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold);
            this.btnUsar.Location  = new System.Drawing.Point(10, 338);
            this.btnUsar.Name      = "btnUsar";
            this.btnUsar.Size      = new System.Drawing.Size(285, 30);
            this.btnUsar.TabIndex  = 10;
            this.btnUsar.Text      = "Usar na Aba Connection Strings";
            this.btnUsar.UseVisualStyleBackColor = false;
            this.btnUsar.Click    += new System.EventHandler(this.btnUsar_Click);

            // ── btnFechar ───────────────────────────────────────────────────────────
            this.btnFechar.Location = new System.Drawing.Point(405, 338);
            this.btnFechar.Name     = "btnFechar";
            this.btnFechar.Size     = new System.Drawing.Size(105, 30);
            this.btnFechar.TabIndex = 11;
            this.btnFechar.Text     = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click   += new System.EventHandler(this.btnFechar_Click);

            // ── ConnectionBuilderForm ────────────────────────────────────────────────
            this.AutoScaleDimensions  = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode        = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize           = new System.Drawing.Size(522, 380);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblProvider);
            this.Controls.Add(this.cmbProvider);
            this.Controls.Add(this.pnlSql);
            this.Controls.Add(this.pnlOleDb);
            this.Controls.Add(this.grpPreview);
            this.Controls.Add(this.btnUsar);
            this.Controls.Add(this.btnFechar);
            this.FormBorderStyle  = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox      = false;
            this.MinimizeBox      = false;
            this.Name             = "ConnectionBuilderForm";
            this.StartPosition    = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text             = "Montador de Connection String";

            // ── ResumeLayout ─────────────────────────────────────────────────────────
            this.grpPreview.ResumeLayout(false);
            this.grpPreview.PerformLayout();
            this.pnlOleDb.ResumeLayout(false);
            this.pnlOleDb.PerformLayout();
            this.pnlSql.ResumeLayout(false);
            this.pnlSql.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // ── Declaracoes de campo ──────────────────────────────────────────────────
        private System.Windows.Forms.Label     lblName;
        private System.Windows.Forms.TextBox   txtName;
        private System.Windows.Forms.Label     lblProvider;
        private System.Windows.Forms.ComboBox  cmbProvider;

        private System.Windows.Forms.Panel     pnlSql;
        private System.Windows.Forms.Label     lblServer;
        private System.Windows.Forms.TextBox   txtServer;
        private System.Windows.Forms.Label     lblDatabase;
        private System.Windows.Forms.TextBox   txtDatabase;
        private System.Windows.Forms.Label     lblAuth;
        private System.Windows.Forms.RadioButton rbWinAuth;
        private System.Windows.Forms.RadioButton rbSqlAuth;
        private System.Windows.Forms.Label     lblSqlUser;
        private System.Windows.Forms.TextBox   txtSqlUser;
        private System.Windows.Forms.Label     lblSqlPwd;
        private System.Windows.Forms.TextBox   txtSqlPwd;

        private System.Windows.Forms.Panel     pnlOleDb;
        private System.Windows.Forms.Label     lblOleDbProvider;
        private System.Windows.Forms.ComboBox  cmbOleDbProvider;
        private System.Windows.Forms.Label     lblDataSource;
        private System.Windows.Forms.TextBox   txtDataSource;
        private System.Windows.Forms.Label     lblOleDbUser;
        private System.Windows.Forms.TextBox   txtOleDbUser;
        private System.Windows.Forms.Label     lblOleDbPwd;
        private System.Windows.Forms.TextBox   txtOleDbPwd;

        private System.Windows.Forms.GroupBox  grpPreview;
        private System.Windows.Forms.TextBox   txtPreview;
        private System.Windows.Forms.Button    btnGerar;
        private System.Windows.Forms.Button    btnTestarConexao;
        private System.Windows.Forms.Button    btnUsar;
        private System.Windows.Forms.Button    btnFechar;
    }
}
