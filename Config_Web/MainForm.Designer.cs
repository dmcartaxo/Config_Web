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
            this.lblFileLabel = new System.Windows.Forms.Label();
            this.txtConfigPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabConnectionStrings = new System.Windows.Forms.TabPage();
            this.pnlCsWarning = new System.Windows.Forms.Panel();
            this.lblCsWarning = new System.Windows.Forms.Label();
            this.lblConnectionsList = new System.Windows.Forms.Label();
            this.lvConnections = new System.Windows.Forms.ListView();
            this.colCsName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCsProvider = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCsString = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblPasteInstruction = new System.Windows.Forms.Label();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.btnAddUpdate = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.btnSaveCS = new System.Windows.Forms.Button();
            this.tabApiConfig = new System.Windows.Forms.TabPage();
            this.pnlApiWarning = new System.Windows.Forms.Panel();
            this.lblApiWarning = new System.Windows.Forms.Label();
            this.lblApiKeyLabel = new System.Windows.Forms.Label();
            this.txtApiKey = new System.Windows.Forms.TextBox();
            this.lblApiKeyLength = new System.Windows.Forms.Label();
            this.btnGenerateKey = new System.Windows.Forms.Button();
            this.btnSaveApi = new System.Windows.Forms.Button();
            this.tabEncryption = new System.Windows.Forms.TabPage();
            this.grpCsEncryption = new System.Windows.Forms.GroupBox();
            this.lblCsEncStatus = new System.Windows.Forms.Label();
            this.btnEncryptCS = new System.Windows.Forms.Button();
            this.btnDecryptCS = new System.Windows.Forms.Button();
            this.grpApiEncryption = new System.Windows.Forms.GroupBox();
            this.lblApiEncStatus = new System.Windows.Forms.Label();
            this.btnEncryptApi = new System.Windows.Forms.Button();
            this.btnDecryptApi = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabConnectionStrings.SuspendLayout();
            this.pnlCsWarning.SuspendLayout();
            this.tabApiConfig.SuspendLayout();
            this.pnlApiWarning.SuspendLayout();
            this.tabEncryption.SuspendLayout();
            this.grpCsEncryption.SuspendLayout();
            this.grpApiEncryption.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFileLabel
            // 
            this.lblFileLabel.AutoSize = true;
            this.lblFileLabel.Location = new System.Drawing.Point(12, 15);
            this.lblFileLabel.Name = "lblFileLabel";
            this.lblFileLabel.Size = new System.Drawing.Size(105, 13);
            this.lblFileLabel.TabIndex = 0;
            this.lblFileLabel.Text = "Arquivo Web.Config:";
            // 
            // txtConfigPath
            // 
            this.txtConfigPath.BackColor = System.Drawing.SystemColors.Window;
            this.txtConfigPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtConfigPath.Location = new System.Drawing.Point(135, 12);
            this.txtConfigPath.Name = "txtConfigPath";
            this.txtConfigPath.ReadOnly = true;
            this.txtConfigPath.Size = new System.Drawing.Size(610, 20);
            this.txtConfigPath.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(753, 10);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(115, 25);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Selecionar...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabConnectionStrings);
            this.tabControl.Controls.Add(this.tabApiConfig);
            this.tabControl.Controls.Add(this.tabEncryption);
            this.tabControl.Enabled = false;
            this.tabControl.Location = new System.Drawing.Point(12, 46);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(858, 459);
            this.tabControl.TabIndex = 2;
            // 
            // tabConnectionStrings
            // 
            this.tabConnectionStrings.Controls.Add(this.pnlCsWarning);
            this.tabConnectionStrings.Controls.Add(this.lblConnectionsList);
            this.tabConnectionStrings.Controls.Add(this.lvConnections);
            this.tabConnectionStrings.Controls.Add(this.lblPasteInstruction);
            this.tabConnectionStrings.Controls.Add(this.txtConnectionString);
            this.tabConnectionStrings.Controls.Add(this.btnAddUpdate);
            this.tabConnectionStrings.Controls.Add(this.btnRemove);
            this.tabConnectionStrings.Controls.Add(this.btnTestConnection);
            this.tabConnectionStrings.Controls.Add(this.btnSaveCS);
            this.tabConnectionStrings.Location = new System.Drawing.Point(4, 22);
            this.tabConnectionStrings.Name = "tabConnectionStrings";
            this.tabConnectionStrings.Padding = new System.Windows.Forms.Padding(3);
            this.tabConnectionStrings.Size = new System.Drawing.Size(850, 433);
            this.tabConnectionStrings.TabIndex = 0;
            this.tabConnectionStrings.Text = "  Connection Strings  ";
            // 
            // pnlCsWarning
            // 
            this.pnlCsWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(195)))));
            this.pnlCsWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCsWarning.Controls.Add(this.lblCsWarning);
            this.pnlCsWarning.Location = new System.Drawing.Point(6, 6);
            this.pnlCsWarning.Name = "pnlCsWarning";
            this.pnlCsWarning.Size = new System.Drawing.Size(836, 32);
            this.pnlCsWarning.TabIndex = 0;
            this.pnlCsWarning.Visible = false;
            // 
            // lblCsWarning
            // 
            this.lblCsWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCsWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCsWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(90)))), ((int)(((byte)(0)))));
            this.lblCsWarning.Location = new System.Drawing.Point(0, 0);
            this.lblCsWarning.Name = "lblCsWarning";
            this.lblCsWarning.Size = new System.Drawing.Size(834, 30);
            this.lblCsWarning.TabIndex = 0;
            this.lblCsWarning.Text = "  [!]  Secao \'connectionStrings\' CRIPTOGRAFADA  —  Acesse a aba Criptografia para" +
    " descriptografar antes de editar.";
            this.lblCsWarning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblConnectionsList
            // 
            this.lblConnectionsList.AutoSize = true;
            this.lblConnectionsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblConnectionsList.Location = new System.Drawing.Point(6, 47);
            this.lblConnectionsList.Name = "lblConnectionsList";
            this.lblConnectionsList.Size = new System.Drawing.Size(132, 13);
            this.lblConnectionsList.TabIndex = 1;
            this.lblConnectionsList.Text = "Conexoes registradas:";
            // 
            // lvConnections
            // 
            this.lvConnections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCsName,
            this.colCsProvider,
            this.colCsString});
            this.lvConnections.FullRowSelect = true;
            this.lvConnections.GridLines = true;
            this.lvConnections.HideSelection = false;
            this.lvConnections.Location = new System.Drawing.Point(6, 66);
            this.lvConnections.MultiSelect = false;
            this.lvConnections.Name = "lvConnections";
            this.lvConnections.Size = new System.Drawing.Size(836, 210);
            this.lvConnections.TabIndex = 0;
            this.lvConnections.UseCompatibleStateImageBehavior = false;
            this.lvConnections.View = System.Windows.Forms.View.Details;
            this.lvConnections.SelectedIndexChanged += new System.EventHandler(this.lvConnections_SelectedIndexChanged);
            // 
            // colCsName
            // 
            this.colCsName.Text = "Name";
            this.colCsName.Width = 100;
            // 
            // colCsProvider
            // 
            this.colCsProvider.Text = "Provider";
            this.colCsProvider.Width = 190;
            // 
            // colCsString
            // 
            this.colCsString.Text = "Connection String";
            this.colCsString.Width = 536;
            // 
            // lblPasteInstruction
            // 
            this.lblPasteInstruction.AutoSize = true;
            this.lblPasteInstruction.Location = new System.Drawing.Point(6, 286);
            this.lblPasteInstruction.Name = "lblPasteInstruction";
            this.lblPasteInstruction.Size = new System.Drawing.Size(435, 13);
            this.lblPasteInstruction.TabIndex = 2;
            this.lblPasteInstruction.Text = "Cole ou edite a string de conexao no formato XML  (selecione uma linha acima para" +
    " editar):";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.txtConnectionString.Location = new System.Drawing.Point(6, 304);
            this.txtConnectionString.Multiline = true;
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConnectionString.Size = new System.Drawing.Size(836, 68);
            this.txtConnectionString.TabIndex = 1;
            this.txtConnectionString.WordWrap = false;
            // 
            // btnAddUpdate
            // 
            this.btnAddUpdate.Location = new System.Drawing.Point(6, 382);
            this.btnAddUpdate.Name = "btnAddUpdate";
            this.btnAddUpdate.Size = new System.Drawing.Size(175, 30);
            this.btnAddUpdate.TabIndex = 2;
            this.btnAddUpdate.Text = "Adicionar / Atualizar";
            this.btnAddUpdate.UseVisualStyleBackColor = true;
            this.btnAddUpdate.Click += new System.EventHandler(this.btnAddUpdate_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(191, 382);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(175, 30);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remover Selecionada";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(376, 382);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(175, 30);
            this.btnTestConnection.TabIndex = 4;
            this.btnTestConnection.Text = "Testar Conexao";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // btnSaveCS
            // 
            this.btnSaveCS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSaveCS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSaveCS.ForeColor = System.Drawing.Color.White;
            this.btnSaveCS.Location = new System.Drawing.Point(667, 382);
            this.btnSaveCS.Name = "btnSaveCS";
            this.btnSaveCS.Size = new System.Drawing.Size(175, 30);
            this.btnSaveCS.TabIndex = 5;
            this.btnSaveCS.Text = "Salvar";
            this.btnSaveCS.UseVisualStyleBackColor = false;
            this.btnSaveCS.Click += new System.EventHandler(this.btnSaveCS_Click);
            // 
            // tabApiConfig
            // 
            this.tabApiConfig.Controls.Add(this.pnlApiWarning);
            this.tabApiConfig.Controls.Add(this.lblApiKeyLabel);
            this.tabApiConfig.Controls.Add(this.txtApiKey);
            this.tabApiConfig.Controls.Add(this.lblApiKeyLength);
            this.tabApiConfig.Controls.Add(this.btnGenerateKey);
            this.tabApiConfig.Controls.Add(this.btnSaveApi);
            this.tabApiConfig.Location = new System.Drawing.Point(4, 22);
            this.tabApiConfig.Name = "tabApiConfig";
            this.tabApiConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabApiConfig.Size = new System.Drawing.Size(850, 433);
            this.tabApiConfig.TabIndex = 1;
            this.tabApiConfig.Text = "  API Config  ";
            // 
            // pnlApiWarning
            // 
            this.pnlApiWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(195)))));
            this.pnlApiWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlApiWarning.Controls.Add(this.lblApiWarning);
            this.pnlApiWarning.Location = new System.Drawing.Point(6, 6);
            this.pnlApiWarning.Name = "pnlApiWarning";
            this.pnlApiWarning.Size = new System.Drawing.Size(836, 32);
            this.pnlApiWarning.TabIndex = 0;
            this.pnlApiWarning.Visible = false;
            // 
            // lblApiWarning
            // 
            this.lblApiWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblApiWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblApiWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(90)))), ((int)(((byte)(0)))));
            this.lblApiWarning.Location = new System.Drawing.Point(0, 0);
            this.lblApiWarning.Name = "lblApiWarning";
            this.lblApiWarning.Size = new System.Drawing.Size(834, 30);
            this.lblApiWarning.TabIndex = 0;
            this.lblApiWarning.Text = "  [!]  Secao \'apiConfig\' CRIPTOGRAFADA  —  Acesse a aba Criptografia para descrip" +
    "tografar antes de editar.";
            this.lblApiWarning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblApiKeyLabel
            // 
            this.lblApiKeyLabel.AutoSize = true;
            this.lblApiKeyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblApiKeyLabel.Location = new System.Drawing.Point(6, 47);
            this.lblApiKeyLabel.Name = "lblApiKeyLabel";
            this.lblApiKeyLabel.Size = new System.Drawing.Size(341, 13);
            this.lblApiKeyLabel.TabIndex = 1;
            this.lblApiKeyLabel.Text = "Chave API atual  (elemento: ApiKey-DGS_ApiServiceRest):";
            // 
            // txtApiKey
            // 
            this.txtApiKey.Font = new System.Drawing.Font("Courier New", 9F);
            this.txtApiKey.Location = new System.Drawing.Point(6, 66);
            this.txtApiKey.Multiline = true;
            this.txtApiKey.Name = "txtApiKey";
            this.txtApiKey.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtApiKey.Size = new System.Drawing.Size(836, 46);
            this.txtApiKey.TabIndex = 0;
            this.txtApiKey.WordWrap = false;
            this.txtApiKey.TextChanged += new System.EventHandler(this.txtApiKey_TextChanged);
            // 
            // lblApiKeyLength
            // 
            this.lblApiKeyLength.AutoSize = true;
            this.lblApiKeyLength.Location = new System.Drawing.Point(6, 122);
            this.lblApiKeyLength.Name = "lblApiKeyLength";
            this.lblApiKeyLength.Size = new System.Drawing.Size(133, 13);
            this.lblApiKeyLength.TabIndex = 2;
            this.lblApiKeyLength.Text = "Comprimento: 0 caracteres";
            // 
            // btnGenerateKey
            // 
            this.btnGenerateKey.Location = new System.Drawing.Point(6, 150);
            this.btnGenerateKey.Name = "btnGenerateKey";
            this.btnGenerateKey.Size = new System.Drawing.Size(190, 30);
            this.btnGenerateKey.TabIndex = 1;
            this.btnGenerateKey.Text = "Gerar Nova Chave (128 chars)";
            this.btnGenerateKey.UseVisualStyleBackColor = true;
            this.btnGenerateKey.Click += new System.EventHandler(this.btnGenerateKey_Click);
            // 
            // btnSaveApi
            // 
            this.btnSaveApi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSaveApi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSaveApi.ForeColor = System.Drawing.Color.White;
            this.btnSaveApi.Location = new System.Drawing.Point(667, 150);
            this.btnSaveApi.Name = "btnSaveApi";
            this.btnSaveApi.Size = new System.Drawing.Size(175, 30);
            this.btnSaveApi.TabIndex = 2;
            this.btnSaveApi.Text = "Salvar";
            this.btnSaveApi.UseVisualStyleBackColor = false;
            this.btnSaveApi.Click += new System.EventHandler(this.btnSaveApi_Click);
            // 
            // tabEncryption
            // 
            this.tabEncryption.Controls.Add(this.grpCsEncryption);
            this.tabEncryption.Controls.Add(this.grpApiEncryption);
            this.tabEncryption.Location = new System.Drawing.Point(4, 22);
            this.tabEncryption.Name = "tabEncryption";
            this.tabEncryption.Padding = new System.Windows.Forms.Padding(3);
            this.tabEncryption.Size = new System.Drawing.Size(850, 433);
            this.tabEncryption.TabIndex = 2;
            this.tabEncryption.Text = "  Criptografia  ";
            // 
            // grpCsEncryption
            // 
            this.grpCsEncryption.Controls.Add(this.lblCsEncStatus);
            this.grpCsEncryption.Controls.Add(this.btnEncryptCS);
            this.grpCsEncryption.Controls.Add(this.btnDecryptCS);
            this.grpCsEncryption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpCsEncryption.Location = new System.Drawing.Point(8, 8);
            this.grpCsEncryption.Name = "grpCsEncryption";
            this.grpCsEncryption.Size = new System.Drawing.Size(834, 105);
            this.grpCsEncryption.TabIndex = 0;
            this.grpCsEncryption.TabStop = false;
            this.grpCsEncryption.Text = " Secao: connectionStrings ";
            // 
            // lblCsEncStatus
            // 
            this.lblCsEncStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblCsEncStatus.Location = new System.Drawing.Point(10, 25);
            this.lblCsEncStatus.Name = "lblCsEncStatus";
            this.lblCsEncStatus.Size = new System.Drawing.Size(810, 20);
            this.lblCsEncStatus.TabIndex = 0;
            this.lblCsEncStatus.Text = "Status: Selecione um arquivo Web.Config";
            // 
            // btnEncryptCS
            // 
            this.btnEncryptCS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnEncryptCS.Location = new System.Drawing.Point(10, 58);
            this.btnEncryptCS.Name = "btnEncryptCS";
            this.btnEncryptCS.Size = new System.Drawing.Size(175, 30);
            this.btnEncryptCS.TabIndex = 1;
            this.btnEncryptCS.Text = "Criptografar";
            this.btnEncryptCS.UseVisualStyleBackColor = true;
            this.btnEncryptCS.Click += new System.EventHandler(this.btnEncryptCS_Click);
            // 
            // btnDecryptCS
            // 
            this.btnDecryptCS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnDecryptCS.Location = new System.Drawing.Point(195, 58);
            this.btnDecryptCS.Name = "btnDecryptCS";
            this.btnDecryptCS.Size = new System.Drawing.Size(175, 30);
            this.btnDecryptCS.TabIndex = 2;
            this.btnDecryptCS.Text = "Descriptografar";
            this.btnDecryptCS.UseVisualStyleBackColor = true;
            this.btnDecryptCS.Click += new System.EventHandler(this.btnDecryptCS_Click);
            // 
            // grpApiEncryption
            // 
            this.grpApiEncryption.Controls.Add(this.lblApiEncStatus);
            this.grpApiEncryption.Controls.Add(this.btnEncryptApi);
            this.grpApiEncryption.Controls.Add(this.btnDecryptApi);
            this.grpApiEncryption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpApiEncryption.Location = new System.Drawing.Point(8, 125);
            this.grpApiEncryption.Name = "grpApiEncryption";
            this.grpApiEncryption.Size = new System.Drawing.Size(834, 105);
            this.grpApiEncryption.TabIndex = 1;
            this.grpApiEncryption.TabStop = false;
            this.grpApiEncryption.Text = " Secao: apiConfig ";
            // 
            // lblApiEncStatus
            // 
            this.lblApiEncStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblApiEncStatus.Location = new System.Drawing.Point(10, 25);
            this.lblApiEncStatus.Name = "lblApiEncStatus";
            this.lblApiEncStatus.Size = new System.Drawing.Size(810, 20);
            this.lblApiEncStatus.TabIndex = 0;
            this.lblApiEncStatus.Text = "Status: Selecione um arquivo Web.Config";
            // 
            // btnEncryptApi
            // 
            this.btnEncryptApi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnEncryptApi.Location = new System.Drawing.Point(10, 58);
            this.btnEncryptApi.Name = "btnEncryptApi";
            this.btnEncryptApi.Size = new System.Drawing.Size(175, 30);
            this.btnEncryptApi.TabIndex = 1;
            this.btnEncryptApi.Text = "Criptografar";
            this.btnEncryptApi.UseVisualStyleBackColor = true;
            this.btnEncryptApi.Click += new System.EventHandler(this.btnEncryptApi_Click);
            // 
            // btnDecryptApi
            // 
            this.btnDecryptApi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnDecryptApi.Location = new System.Drawing.Point(195, 58);
            this.btnDecryptApi.Name = "btnDecryptApi";
            this.btnDecryptApi.Size = new System.Drawing.Size(175, 30);
            this.btnDecryptApi.TabIndex = 2;
            this.btnDecryptApi.Text = "Descriptografar";
            this.btnDecryptApi.UseVisualStyleBackColor = true;
            this.btnDecryptApi.Click += new System.EventHandler(this.btnDecryptApi_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 643);
            this.Controls.Add(this.lblFileLabel);
            this.Controls.Add(this.txtConfigPath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.tabControl);
            this.MinimumSize = new System.Drawing.Size(898, 682);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Config Web  —  Configurador de Web.Config para IIS";
            this.tabControl.ResumeLayout(false);
            this.tabConnectionStrings.ResumeLayout(false);
            this.tabConnectionStrings.PerformLayout();
            this.pnlCsWarning.ResumeLayout(false);
            this.tabApiConfig.ResumeLayout(false);
            this.tabApiConfig.PerformLayout();
            this.pnlApiWarning.ResumeLayout(false);
            this.tabEncryption.ResumeLayout(false);
            this.grpCsEncryption.ResumeLayout(false);
            this.grpApiEncryption.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // ── Declaracoes de campo ──────────────────────────────────────────────────
        private System.Windows.Forms.Label    lblFileLabel;
        private System.Windows.Forms.TextBox  txtConfigPath;
        private System.Windows.Forms.Button   btnBrowse;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage  tabConnectionStrings;
        private System.Windows.Forms.TabPage  tabApiConfig;
        private System.Windows.Forms.TabPage  tabEncryption;

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
        private System.Windows.Forms.Button   btnSaveCS;

        private System.Windows.Forms.Panel    pnlApiWarning;
        private System.Windows.Forms.Label    lblApiWarning;
        private System.Windows.Forms.Label    lblApiKeyLabel;
        private System.Windows.Forms.TextBox  txtApiKey;
        private System.Windows.Forms.Label    lblApiKeyLength;
        private System.Windows.Forms.Button   btnGenerateKey;
        private System.Windows.Forms.Button   btnSaveApi;

        private System.Windows.Forms.GroupBox grpCsEncryption;
        private System.Windows.Forms.Label    lblCsEncStatus;
        private System.Windows.Forms.Button   btnEncryptCS;
        private System.Windows.Forms.Button   btnDecryptCS;
        private System.Windows.Forms.GroupBox grpApiEncryption;
        private System.Windows.Forms.Label    lblApiEncStatus;
        private System.Windows.Forms.Button   btnEncryptApi;
        private System.Windows.Forms.Button   btnDecryptApi;
    }
}
