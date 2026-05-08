namespace Config_Web
{
    partial class MainForm
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
            this.lblFileLabel          = new System.Windows.Forms.Label();
            this.txtConfigPath         = new System.Windows.Forms.TextBox();
            this.btnBrowse             = new System.Windows.Forms.Button();
            this.lblTempFileLabel      = new System.Windows.Forms.Label();
            this.txtTempFile           = new System.Windows.Forms.TextBox();
            this.tabControl            = new System.Windows.Forms.TabControl();
            this.tabConnectionStrings  = new System.Windows.Forms.TabPage();
            this.tabApiConfig          = new System.Windows.Forms.TabPage();
            this.btnSalvarOriginal     = new System.Windows.Forms.Button();

            // Connection Strings tab
            this.pnlCsWarning          = new System.Windows.Forms.Panel();
            this.lblCsWarning          = new System.Windows.Forms.Label();
            this.lblConnectionsList    = new System.Windows.Forms.Label();
            this.lvConnections         = new System.Windows.Forms.ListView();
            this.colCsName             = new System.Windows.Forms.ColumnHeader();
            this.colCsProvider         = new System.Windows.Forms.ColumnHeader();
            this.colCsString           = new System.Windows.Forms.ColumnHeader();
            this.lblPasteInstruction   = new System.Windows.Forms.Label();
            this.txtConnectionString   = new System.Windows.Forms.TextBox();
            this.btnAddUpdate          = new System.Windows.Forms.Button();
            this.btnRemove             = new System.Windows.Forms.Button();
            this.btnTestConnection     = new System.Windows.Forms.Button();
            this.btnBuilderCS          = new System.Windows.Forms.Button();
            this.chkEncryptCS          = new System.Windows.Forms.CheckBox();

            // API Config tab
            this.pnlApiWarning         = new System.Windows.Forms.Panel();
            this.lblApiWarning         = new System.Windows.Forms.Label();
            this.lblApiKeyLabel        = new System.Windows.Forms.Label();
            this.txtApiKey             = new System.Windows.Forms.TextBox();
            this.lblApiKeyLength       = new System.Windows.Forms.Label();
            this.btnGenerateKey        = new System.Windows.Forms.Button();
            this.chkEncryptApi         = new System.Windows.Forms.CheckBox();

            // ── SuspendLayout ───────────────────────────────────────────────────────
            this.tabControl.SuspendLayout();
            this.tabConnectionStrings.SuspendLayout();
            this.tabApiConfig.SuspendLayout();
            this.pnlCsWarning.SuspendLayout();
            this.pnlApiWarning.SuspendLayout();
            this.SuspendLayout();

            // ── lblFileLabel ────────────────────────────────────────────────────────
            this.lblFileLabel.AutoSize = true;
            this.lblFileLabel.Location = new System.Drawing.Point(12, 15);
            this.lblFileLabel.Name     = "lblFileLabel";
            this.lblFileLabel.Text     = "Arquivo Web.Config:";

            // ── txtConfigPath ───────────────────────────────────────────────────────
            this.txtConfigPath.BackColor  = System.Drawing.SystemColors.Window;
            this.txtConfigPath.Location   = new System.Drawing.Point(135, 12);
            this.txtConfigPath.Name       = "txtConfigPath";
            this.txtConfigPath.ReadOnly   = true;
            this.txtConfigPath.Size       = new System.Drawing.Size(610, 20);
            this.txtConfigPath.TabIndex   = 0;
            this.txtConfigPath.Font       = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold);

            // ── btnBrowse ───────────────────────────────────────────────────────────
            this.btnBrowse.Location  = new System.Drawing.Point(753, 10);
            this.btnBrowse.Name      = "btnBrowse";
            this.btnBrowse.Size      = new System.Drawing.Size(115, 25);
            this.btnBrowse.TabIndex  = 1;
            this.btnBrowse.Text      = "Selecionar...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click    += new System.EventHandler(this.btnBrowse_Click);

            // ── lblTempFileLabel ────────────────────────────────────────────────────
            this.lblTempFileLabel.AutoSize = true;
            this.lblTempFileLabel.Location = new System.Drawing.Point(12, 42);
            this.lblTempFileLabel.Name     = "lblTempFileLabel";
            this.lblTempFileLabel.Text     = "Arquivo temporario:";
            this.lblTempFileLabel.ForeColor = System.Drawing.Color.DimGray;

            // ── txtTempFile ─────────────────────────────────────────────────────────
            this.txtTempFile.BackColor   = System.Drawing.SystemColors.Control;
            this.txtTempFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTempFile.Font        = new System.Drawing.Font("Courier New", 7.5f);
            this.txtTempFile.ForeColor   = System.Drawing.Color.DimGray;
            this.txtTempFile.Location    = new System.Drawing.Point(135, 41);
            this.txtTempFile.Name        = "txtTempFile";
            this.txtTempFile.ReadOnly    = true;
            this.txtTempFile.Size        = new System.Drawing.Size(735, 17);
            this.txtTempFile.TabIndex    = 0;
            this.txtTempFile.TabStop     = false;

            // ── tabControl ──────────────────────────────────────────────────────────
            this.tabControl.Controls.Add(this.tabConnectionStrings);
            this.tabControl.Controls.Add(this.tabApiConfig);
            this.tabControl.Enabled        = false;
            this.tabControl.Location       = new System.Drawing.Point(12, 66);
            this.tabControl.Name           = "tabControl";
            this.tabControl.SelectedIndex  = 0;
            this.tabControl.Size           = new System.Drawing.Size(858, 470);
            this.tabControl.TabIndex       = 2;

            // ────────────────────────────────────────────────────────────────────────
            // tabConnectionStrings
            // ────────────────────────────────────────────────────────────────────────
            this.tabConnectionStrings.Controls.Add(this.pnlCsWarning);
            this.tabConnectionStrings.Controls.Add(this.lblConnectionsList);
            this.tabConnectionStrings.Controls.Add(this.lvConnections);
            this.tabConnectionStrings.Controls.Add(this.lblPasteInstruction);
            this.tabConnectionStrings.Controls.Add(this.txtConnectionString);
            this.tabConnectionStrings.Controls.Add(this.btnAddUpdate);
            this.tabConnectionStrings.Controls.Add(this.btnRemove);
            this.tabConnectionStrings.Controls.Add(this.btnTestConnection);
            this.tabConnectionStrings.Controls.Add(this.btnBuilderCS);
            this.tabConnectionStrings.Controls.Add(this.chkEncryptCS);
            this.tabConnectionStrings.Location  = new System.Drawing.Point(4, 22);
            this.tabConnectionStrings.Name      = "tabConnectionStrings";
            this.tabConnectionStrings.Padding   = new System.Windows.Forms.Padding(3);
            this.tabConnectionStrings.Size      = new System.Drawing.Size(850, 559);
            this.tabConnectionStrings.TabIndex  = 0;
            this.tabConnectionStrings.Text      = "  Connection Strings  ";

            // pnlCsWarning  (faixa amarela - visivel apenas quando descriptografia falha)
            this.pnlCsWarning.BackColor    = System.Drawing.Color.FromArgb(255, 248, 195);
            this.pnlCsWarning.BorderStyle  = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCsWarning.Controls.Add(this.lblCsWarning);
            this.pnlCsWarning.Location     = new System.Drawing.Point(6, 6);
            this.pnlCsWarning.Name         = "pnlCsWarning";
            this.pnlCsWarning.Size         = new System.Drawing.Size(836, 32);
            this.pnlCsWarning.Visible      = false;

            this.lblCsWarning.AutoSize    = false;
            this.lblCsWarning.Dock        = System.Windows.Forms.DockStyle.Fill;
            this.lblCsWarning.ForeColor   = System.Drawing.Color.FromArgb(180, 90, 0);
            this.lblCsWarning.Font        = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold);
            this.lblCsWarning.Text        = "  [!]  Secao 'connectionStrings' CRIPTOGRAFADA  —  Nao foi possivel descriptografar. O arquivo pode ter sido criptografado em outra maquina.";
            this.lblCsWarning.TextAlign   = System.Drawing.ContentAlignment.MiddleLeft;

            // lblConnectionsList
            this.lblConnectionsList.AutoSize  = true;
            this.lblConnectionsList.Font      = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold);
            this.lblConnectionsList.Location  = new System.Drawing.Point(6, 47);
            this.lblConnectionsList.Name      = "lblConnectionsList";
            this.lblConnectionsList.Text      = "Conexoes registradas:";

            // lvConnections
            this.lvConnections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colCsName, this.colCsProvider, this.colCsString });
            this.lvConnections.FullRowSelect   = true;
            this.lvConnections.GridLines       = true;
            this.lvConnections.HideSelection   = false;
            this.lvConnections.Location        = new System.Drawing.Point(6, 66);
            this.lvConnections.MultiSelect     = false;
            this.lvConnections.Name            = "lvConnections";
            this.lvConnections.Size            = new System.Drawing.Size(836, 210);
            this.lvConnections.TabIndex        = 0;
            this.lvConnections.UseCompatibleStateImageBehavior = false;
            this.lvConnections.View            = System.Windows.Forms.View.Details;
            this.lvConnections.SelectedIndexChanged += new System.EventHandler(this.lvConnections_SelectedIndexChanged);

            this.colCsName.Text    = "Name";
            this.colCsName.Width   = 100;
            this.colCsProvider.Text  = "Provider";
            this.colCsProvider.Width = 190;
            this.colCsString.Text  = "Connection String";
            this.colCsString.Width = 536;

            // lblPasteInstruction
            this.lblPasteInstruction.AutoSize  = true;
            this.lblPasteInstruction.Location  = new System.Drawing.Point(6, 286);
            this.lblPasteInstruction.Name      = "lblPasteInstruction";
            this.lblPasteInstruction.Text      = "Cole ou edite a string de conexao no formato XML  (selecione uma linha acima para editar):";

            // txtConnectionString
            this.txtConnectionString.Font        = new System.Drawing.Font("Courier New", 8.25f);
            this.txtConnectionString.Location    = new System.Drawing.Point(6, 304);
            this.txtConnectionString.Multiline   = true;
            this.txtConnectionString.Name        = "txtConnectionString";
            this.txtConnectionString.ScrollBars  = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConnectionString.Size        = new System.Drawing.Size(836, 60);
            this.txtConnectionString.TabIndex    = 1;
            this.txtConnectionString.WordWrap    = true;

            // btnAddUpdate
            this.btnAddUpdate.Location  = new System.Drawing.Point(6, 374);
            this.btnAddUpdate.Name      = "btnAddUpdate";
            this.btnAddUpdate.Size      = new System.Drawing.Size(175, 30);
            this.btnAddUpdate.TabIndex  = 2;
            this.btnAddUpdate.Text      = "Adicionar / Atualizar";
            this.btnAddUpdate.UseVisualStyleBackColor = true;
            this.btnAddUpdate.Click    += new System.EventHandler(this.btnAddUpdate_Click);

            // btnRemove
            this.btnRemove.Location  = new System.Drawing.Point(191, 374);
            this.btnRemove.Name      = "btnRemove";
            this.btnRemove.Size      = new System.Drawing.Size(175, 30);
            this.btnRemove.TabIndex  = 3;
            this.btnRemove.Text      = "Remover Selecionada";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click    += new System.EventHandler(this.btnRemove_Click);

            // btnTestConnection
            this.btnTestConnection.Location  = new System.Drawing.Point(376, 374);
            this.btnTestConnection.Name      = "btnTestConnection";
            this.btnTestConnection.Size      = new System.Drawing.Size(175, 30);
            this.btnTestConnection.TabIndex  = 4;
            this.btnTestConnection.Text      = "Testar Conexao";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click    += new System.EventHandler(this.btnTestConnection_Click);

            // btnBuilderCS
            this.btnBuilderCS.Location  = new System.Drawing.Point(561, 374);
            this.btnBuilderCS.Name      = "btnBuilderCS";
            this.btnBuilderCS.Size      = new System.Drawing.Size(275, 30);
            this.btnBuilderCS.TabIndex  = 5;
            this.btnBuilderCS.Text      = "Montar Connection String...";
            this.btnBuilderCS.UseVisualStyleBackColor = true;
            this.btnBuilderCS.Click    += new System.EventHandler(this.btnBuilderCS_Click);

            // chkEncryptCS
            this.chkEncryptCS.AutoSize  = true;
            this.chkEncryptCS.Location  = new System.Drawing.Point(8, 414);
            this.chkEncryptCS.Name      = "chkEncryptCS";
            this.chkEncryptCS.TabIndex  = 6;
            this.chkEncryptCS.Text      = "Criptografar secao 'connectionStrings' ao salvar no arquivo original";

            // ────────────────────────────────────────────────────────────────────────
            // tabApiConfig
            // ────────────────────────────────────────────────────────────────────────
            this.tabApiConfig.Controls.Add(this.pnlApiWarning);
            this.tabApiConfig.Controls.Add(this.lblApiKeyLabel);
            this.tabApiConfig.Controls.Add(this.txtApiKey);
            this.tabApiConfig.Controls.Add(this.lblApiKeyLength);
            this.tabApiConfig.Controls.Add(this.btnGenerateKey);
            this.tabApiConfig.Controls.Add(this.chkEncryptApi);
            this.tabApiConfig.Location  = new System.Drawing.Point(4, 22);
            this.tabApiConfig.Name      = "tabApiConfig";
            this.tabApiConfig.Padding   = new System.Windows.Forms.Padding(3);
            this.tabApiConfig.Size      = new System.Drawing.Size(850, 559);
            this.tabApiConfig.TabIndex  = 1;
            this.tabApiConfig.Text      = "  API Config  ";

            // pnlApiWarning
            this.pnlApiWarning.BackColor    = System.Drawing.Color.FromArgb(255, 248, 195);
            this.pnlApiWarning.BorderStyle  = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlApiWarning.Controls.Add(this.lblApiWarning);
            this.pnlApiWarning.Location     = new System.Drawing.Point(6, 6);
            this.pnlApiWarning.Name         = "pnlApiWarning";
            this.pnlApiWarning.Size         = new System.Drawing.Size(836, 32);
            this.pnlApiWarning.Visible      = false;

            this.lblApiWarning.AutoSize    = false;
            this.lblApiWarning.Dock        = System.Windows.Forms.DockStyle.Fill;
            this.lblApiWarning.ForeColor   = System.Drawing.Color.FromArgb(180, 90, 0);
            this.lblApiWarning.Font        = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold);
            this.lblApiWarning.Text        = "  [!]  Secao 'apiConfig' CRIPTOGRAFADA  —  Nao foi possivel descriptografar. O arquivo pode ter sido criptografado em outra maquina.";
            this.lblApiWarning.TextAlign   = System.Drawing.ContentAlignment.MiddleLeft;

            // lblApiKeyLabel
            this.lblApiKeyLabel.AutoSize  = true;
            this.lblApiKeyLabel.Font      = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold);
            this.lblApiKeyLabel.Location  = new System.Drawing.Point(6, 47);
            this.lblApiKeyLabel.Name      = "lblApiKeyLabel";
            this.lblApiKeyLabel.Text      = "Chave API atual  (elemento: ApiKey-DGS_ApiServiceRest):";

            // txtApiKey
            this.txtApiKey.Font        = new System.Drawing.Font("Courier New", 9f);
            this.txtApiKey.Location    = new System.Drawing.Point(6, 66);
            this.txtApiKey.Multiline   = true;
            this.txtApiKey.Name        = "txtApiKey";
            this.txtApiKey.ScrollBars  = System.Windows.Forms.ScrollBars.Vertical;
            this.txtApiKey.Size        = new System.Drawing.Size(836, 46);
            this.txtApiKey.TabIndex    = 0;
            this.txtApiKey.WordWrap    = true;
            this.txtApiKey.TextChanged += new System.EventHandler(this.txtApiKey_TextChanged);

            // lblApiKeyLength
            this.lblApiKeyLength.AutoSize  = true;
            this.lblApiKeyLength.Location  = new System.Drawing.Point(6, 122);
            this.lblApiKeyLength.Name      = "lblApiKeyLength";
            this.lblApiKeyLength.Text      = "Comprimento: 0 caracteres";

            // btnGenerateKey
            this.btnGenerateKey.Location  = new System.Drawing.Point(6, 150);
            this.btnGenerateKey.Name      = "btnGenerateKey";
            this.btnGenerateKey.Size      = new System.Drawing.Size(190, 30);
            this.btnGenerateKey.TabIndex  = 1;
            this.btnGenerateKey.Text      = "Gerar Nova Chave (128 chars)";
            this.btnGenerateKey.UseVisualStyleBackColor = true;
            this.btnGenerateKey.Click    += new System.EventHandler(this.btnGenerateKey_Click);

            // chkEncryptApi
            this.chkEncryptApi.AutoSize  = true;
            this.chkEncryptApi.Location  = new System.Drawing.Point(8, 190);
            this.chkEncryptApi.Name      = "chkEncryptApi";
            this.chkEncryptApi.TabIndex  = 3;
            this.chkEncryptApi.Text      = "Criptografar secao 'apiConfig' ao salvar no arquivo original";

            // ── btnSalvarOriginal ────────────────────────────────────────────────────
            this.btnSalvarOriginal.BackColor  = System.Drawing.Color.FromArgb(0, 128, 0);
            this.btnSalvarOriginal.ForeColor  = System.Drawing.Color.White;
            this.btnSalvarOriginal.Font       = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold);
            this.btnSalvarOriginal.Location   = new System.Drawing.Point(12, 545);
            this.btnSalvarOriginal.Name       = "btnSalvarOriginal";
            this.btnSalvarOriginal.Size       = new System.Drawing.Size(858, 35);
            this.btnSalvarOriginal.TabIndex   = 3;
            this.btnSalvarOriginal.Text       = "Salvar no Arquivo Selecionado  (aplica criptografia conforme checkboxes acima)";
            this.btnSalvarOriginal.UseVisualStyleBackColor = false;
            this.btnSalvarOriginal.Enabled    = false;
            this.btnSalvarOriginal.Click     += new System.EventHandler(this.btnSalvarOriginal_Click);

            // ── MainForm ─────────────────────────────────────────────────────────────
            this.AutoScaleDimensions  = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode        = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize           = new System.Drawing.Size(882, 592);
            this.FormBorderStyle      = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox          = false;
            this.Controls.Add(this.lblFileLabel);
            this.Controls.Add(this.txtConfigPath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblTempFileLabel);
            this.Controls.Add(this.txtTempFile);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnSalvarOriginal);
            this.MinimumSize          = new System.Drawing.Size(898, 631);
            this.Name                 = "MainForm";
            this.StartPosition        = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                 = "Config Web  —  Configurador de Web.Config para IIS";

            // ── ResumeLayout ─────────────────────────────────────────────────────────
            this.pnlApiWarning.ResumeLayout(false);
            this.tabApiConfig.ResumeLayout(false);
            this.tabApiConfig.PerformLayout();
            this.pnlCsWarning.ResumeLayout(false);
            this.tabConnectionStrings.ResumeLayout(false);
            this.tabConnectionStrings.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // ── Declaracoes de campo ──────────────────────────────────────────────────
        private System.Windows.Forms.Label    lblFileLabel;
        private System.Windows.Forms.TextBox  txtConfigPath;
        private System.Windows.Forms.Button   btnBrowse;
        private System.Windows.Forms.Label    lblTempFileLabel;
        private System.Windows.Forms.TextBox  txtTempFile;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage  tabConnectionStrings;
        private System.Windows.Forms.TabPage  tabApiConfig;
        private System.Windows.Forms.Button   btnSalvarOriginal;

        private System.Windows.Forms.Panel    pnlCsWarning;
        private System.Windows.Forms.Label    lblCsWarning;
        private System.Windows.Forms.Label    lblConnectionsList;
        private System.Windows.Forms.ListView lvConnections;
        private System.Windows.Forms.ColumnHeader colCsName;
        private System.Windows.Forms.ColumnHeader colCsProvider;
        private System.Windows.Forms.ColumnHeader colCsString;
        private System.Windows.Forms.Label    lblPasteInstruction;
        private System.Windows.Forms.TextBox  txtConnectionString;
        private System.Windows.Forms.Button   btnAddUpdate;
        private System.Windows.Forms.Button   btnRemove;
        private System.Windows.Forms.Button   btnTestConnection;
        private System.Windows.Forms.Button   btnBuilderCS;
        private System.Windows.Forms.CheckBox chkEncryptCS;

        private System.Windows.Forms.Panel    pnlApiWarning;
        private System.Windows.Forms.Label    lblApiWarning;
        private System.Windows.Forms.Label    lblApiKeyLabel;
        private System.Windows.Forms.TextBox  txtApiKey;
        private System.Windows.Forms.Label    lblApiKeyLength;
        private System.Windows.Forms.Button   btnGenerateKey;
        private System.Windows.Forms.CheckBox chkEncryptApi;
    }
}
