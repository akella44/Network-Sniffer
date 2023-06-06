namespace Shell
{
    partial class PacketMonitoring
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PacketMonitoring));
            this.packetDataGrid = new System.Windows.Forms.DataGridView();
            this.ContextMenuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.formOfCaptureDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sessionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.udpSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcpSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paketsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.udpPacketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcpPacketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suspTrafficToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильтрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.scrollDown = new System.Windows.Forms.CheckBox();
            this.saveCsvFilesDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.autoscrollLabel = new System.Windows.Forms.Label();
            this.saveCsvFilesButton = new System.Windows.Forms.Button();
            this.filterButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.Nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SourcePort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DestinationPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proctocol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lenght = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.packetDataGrid)).BeginInit();
            this.ContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // packetDataGrid
            // 
            this.packetDataGrid.AllowUserToAddRows = false;
            this.packetDataGrid.AllowUserToDeleteRows = false;
            this.packetDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.packetDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.packetDataGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.packetDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.packetDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.packetDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.packetDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.packetDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nom,
            this.Source,
            this.SourcePort,
            this.Desination,
            this.DestinationPort,
            this.Proctocol,
            this.Lenght});
            this.packetDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.packetDataGrid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.packetDataGrid.Location = new System.Drawing.Point(0, 124);
            this.packetDataGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.packetDataGrid.Name = "packetDataGrid";
            this.packetDataGrid.ReadOnly = true;
            this.packetDataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.packetDataGrid.RowHeadersWidth = 51;
            this.packetDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.packetDataGrid.Size = new System.Drawing.Size(1344, 615);
            this.packetDataGrid.TabIndex = 2;
            // 
            // ContextMenuStrip
            // 
            this.ContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.statisticsMenu,
            this.фильтрыToolStripMenuItem});
            this.ContextMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.ContextMenuStrip.Name = "ContextMenuStrip";
            this.ContextMenuStrip.Size = new System.Drawing.Size(1344, 28);
            this.ContextMenuStrip.TabIndex = 3;
            this.ContextMenuStrip.Text = "Menu";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveFilesToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // saveFilesToolStripMenuItem
            // 
            this.saveFilesToolStripMenuItem.Name = "saveFilesToolStripMenuItem";
            this.saveFilesToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.saveFilesToolStripMenuItem.Text = "Сохранить CSV файлы";
            this.saveFilesToolStripMenuItem.Click += new System.EventHandler(this.saveFilesToolStripMenuItem_Click);
            // 
            // statisticsMenu
            // 
            this.statisticsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formOfCaptureDataToolStripMenuItem,
            this.suspTrafficToolStripMenuItem});
            this.statisticsMenu.Name = "statisticsMenu";
            this.statisticsMenu.Size = new System.Drawing.Size(98, 24);
            this.statisticsMenu.Text = "Статистика";
            // 
            // formOfCaptureDataToolStripMenuItem
            // 
            this.formOfCaptureDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sessionsToolStripMenuItem,
            this.paketsToolStripMenuItem});
            this.formOfCaptureDataToolStripMenuItem.Name = "formOfCaptureDataToolStripMenuItem";
            this.formOfCaptureDataToolStripMenuItem.Size = new System.Drawing.Size(266, 26);
            this.formOfCaptureDataToolStripMenuItem.Text = "Формат захвата данных";
            // 
            // sessionsToolStripMenuItem
            // 
            this.sessionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.udpSessionToolStripMenuItem,
            this.tcpSessionToolStripMenuItem});
            this.sessionsToolStripMenuItem.Name = "sessionsToolStripMenuItem";
            this.sessionsToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.sessionsToolStripMenuItem.Text = "Сессии";
            // 
            // udpSessionToolStripMenuItem
            // 
            this.udpSessionToolStripMenuItem.CheckOnClick = true;
            this.udpSessionToolStripMenuItem.Name = "udpSessionToolStripMenuItem";
            this.udpSessionToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.udpSessionToolStripMenuItem.Text = "Udp";
            this.udpSessionToolStripMenuItem.CheckedChanged += new System.EventHandler(this.udpSessionToolStripMenuItem_ChekedChanged);
            // 
            // tcpSessionToolStripMenuItem
            // 
            this.tcpSessionToolStripMenuItem.CheckOnClick = true;
            this.tcpSessionToolStripMenuItem.Name = "tcpSessionToolStripMenuItem";
            this.tcpSessionToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.tcpSessionToolStripMenuItem.Text = "Tcp";
            this.tcpSessionToolStripMenuItem.CheckedChanged += new System.EventHandler(this.tcpSessionToolStripMenuItem_ChekedChanged);
            // 
            // paketsToolStripMenuItem
            // 
            this.paketsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.udpPacketToolStripMenuItem,
            this.tcpPacketToolStripMenuItem});
            this.paketsToolStripMenuItem.Name = "paketsToolStripMenuItem";
            this.paketsToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.paketsToolStripMenuItem.Text = "Пакеты";
            // 
            // udpPacketToolStripMenuItem
            // 
            this.udpPacketToolStripMenuItem.CheckOnClick = true;
            this.udpPacketToolStripMenuItem.Name = "udpPacketToolStripMenuItem";
            this.udpPacketToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.udpPacketToolStripMenuItem.Text = "Udp";
            this.udpPacketToolStripMenuItem.CheckedChanged += new System.EventHandler(this.udpPacketToolStripMenuItem_ChekedChanged);
            // 
            // tcpPacketToolStripMenuItem
            // 
            this.tcpPacketToolStripMenuItem.CheckOnClick = true;
            this.tcpPacketToolStripMenuItem.Name = "tcpPacketToolStripMenuItem";
            this.tcpPacketToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.tcpPacketToolStripMenuItem.Text = "Tcp";
            this.tcpPacketToolStripMenuItem.CheckedChanged += new System.EventHandler(this.tcpPacketToolStripMenuItem_ChekedChanged);
            // 
            // suspTrafficToolStripMenuItem
            // 
            this.suspTrafficToolStripMenuItem.Name = "suspTrafficToolStripMenuItem";
            this.suspTrafficToolStripMenuItem.Size = new System.Drawing.Size(266, 26);
            this.suspTrafficToolStripMenuItem.Text = "Подозрительный трафик";
            this.suspTrafficToolStripMenuItem.Click += new System.EventHandler(this.suspTrafficToolStripMenuItem_Click);
            // 
            // фильтрыToolStripMenuItem
            // 
            this.фильтрыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FiltersToolStripMenuItem});
            this.фильтрыToolStripMenuItem.Name = "фильтрыToolStripMenuItem";
            this.фильтрыToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.фильтрыToolStripMenuItem.Text = "Фильтры";
            // 
            // FiltersToolStripMenuItem
            // 
            this.FiltersToolStripMenuItem.Name = "FiltersToolStripMenuItem";
            this.FiltersToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.FiltersToolStripMenuItem.Text = "Доступные фильтры";
            this.FiltersToolStripMenuItem.Click += new System.EventHandler(this.FiltersToolStripMenuItem_Click);
            // 
            // filterTextBox
            // 
            this.filterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterTextBox.Location = new System.Drawing.Point(13, 80);
            this.filterTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(1311, 22);
            this.filterTextBox.TabIndex = 4;
            this.filterTextBox.TextChanged += new System.EventHandler(this.filterTextBox_TextChanged);
            // 
            // scrollDown
            // 
            this.scrollDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scrollDown.AutoSize = true;
            this.scrollDown.Location = new System.Drawing.Point(1310, 57);
            this.scrollDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.scrollDown.Name = "scrollDown";
            this.scrollDown.Size = new System.Drawing.Size(18, 17);
            this.scrollDown.TabIndex = 5;
            this.scrollDown.UseVisualStyleBackColor = true;
            // 
            // autoscrollLabel
            // 
            this.autoscrollLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.autoscrollLabel.AutoSize = true;
            this.autoscrollLabel.Location = new System.Drawing.Point(1189, 57);
            this.autoscrollLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.autoscrollLabel.Name = "autoscrollLabel";
            this.autoscrollLabel.Size = new System.Drawing.Size(108, 16);
            this.autoscrollLabel.TabIndex = 6;
            this.autoscrollLabel.Text = "Автопрокрутка";
            // 
            // saveCsvFilesButton
            // 
            this.saveCsvFilesButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.saveCsvFilesButton.Image = global::Shell.Properties.Resources.Save;
            this.saveCsvFilesButton.Location = new System.Drawing.Point(47, 43);
            this.saveCsvFilesButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveCsvFilesButton.Name = "saveCsvFilesButton";
            this.saveCsvFilesButton.Size = new System.Drawing.Size(33, 31);
            this.saveCsvFilesButton.TabIndex = 8;
            this.saveCsvFilesButton.UseVisualStyleBackColor = true;
            this.saveCsvFilesButton.Click += new System.EventHandler(this.saveCsvFilesButton_Click);
            // 
            // filterButton
            // 
            this.filterButton.Image = global::Shell.Properties.Resources.Filter;
            this.filterButton.Location = new System.Drawing.Point(80, 43);
            this.filterButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(33, 31);
            this.filterButton.TabIndex = 7;
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.White;
            this.stopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.stopButton.FlatAppearance.BorderSize = 0;
            this.stopButton.ForeColor = System.Drawing.SystemColors.Window;
            this.stopButton.Image = global::Shell.Properties.Resources.Stop;
            this.stopButton.Location = new System.Drawing.Point(13, 43);
            this.stopButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(33, 31);
            this.stopButton.TabIndex = 1;
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_OnClick);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.SystemColors.Window;
            this.startButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.startButton.FlatAppearance.BorderSize = 0;
            this.startButton.Image = global::Shell.Properties.Resources.Start;
            this.startButton.Location = new System.Drawing.Point(16, 43);
            this.startButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(33, 31);
            this.startButton.TabIndex = 0;
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.strartButton_OnClick);
            // 
            // Nom
            // 
            this.Nom.HeaderText = "Номер";
            this.Nom.MinimumWidth = 6;
            this.Nom.Name = "Nom";
            this.Nom.ReadOnly = true;
            // 
            // Source
            // 
            this.Source.HeaderText = "Источник";
            this.Source.MinimumWidth = 50;
            this.Source.Name = "Source";
            this.Source.ReadOnly = true;
            // 
            // SourcePort
            // 
            this.SourcePort.HeaderText = "Порт источника";
            this.SourcePort.MinimumWidth = 6;
            this.SourcePort.Name = "SourcePort";
            this.SourcePort.ReadOnly = true;
            // 
            // Desination
            // 
            this.Desination.HeaderText = "Назначение";
            this.Desination.MinimumWidth = 50;
            this.Desination.Name = "Desination";
            this.Desination.ReadOnly = true;
            // 
            // DestinationPort
            // 
            this.DestinationPort.HeaderText = "Порт назначения";
            this.DestinationPort.MinimumWidth = 6;
            this.DestinationPort.Name = "DestinationPort";
            this.DestinationPort.ReadOnly = true;
            // 
            // Proctocol
            // 
            this.Proctocol.HeaderText = "Протокол";
            this.Proctocol.MinimumWidth = 20;
            this.Proctocol.Name = "Proctocol";
            this.Proctocol.ReadOnly = true;
            // 
            // Lenght
            // 
            this.Lenght.HeaderText = "Длина";
            this.Lenght.MinimumWidth = 10;
            this.Lenght.Name = "Lenght";
            this.Lenght.ReadOnly = true;
            // 
            // PacketMonitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1344, 740);
            this.Controls.Add(this.saveCsvFilesButton);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.autoscrollLabel);
            this.Controls.Add(this.scrollDown);
            this.Controls.Add(this.filterTextBox);
            this.Controls.Add(this.packetDataGrid);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.ContextMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.ContextMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1359, 777);
            this.Name = "PacketMonitoring";
            this.Text = "Система сетевого мониторинга";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PacketMonitoring_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.packetDataGrid)).EndInit();
            this.ContextMenuStrip.ResumeLayout(false);
            this.ContextMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.MenuStrip ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem statisticsMenu;
        public System.Windows.Forms.DataGridView packetDataGrid;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.CheckBox scrollDown;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formOfCaptureDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sessionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem udpSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tcpSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paketsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem udpPacketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tcpPacketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFilesToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveCsvFilesDialog1;
        private System.Windows.Forms.Label autoscrollLabel;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Button saveCsvFilesButton;
        private System.Windows.Forms.ToolStripMenuItem фильтрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FiltersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suspTrafficToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source;
        private System.Windows.Forms.DataGridViewTextBoxColumn SourcePort;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desination;
        private System.Windows.Forms.DataGridViewTextBoxColumn DestinationPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proctocol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lenght;
    }
}