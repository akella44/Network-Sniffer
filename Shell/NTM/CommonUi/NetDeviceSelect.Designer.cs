namespace Shell
{
    partial class NetDeviceSelect
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetDeviceSelect));
            this.devicesList = new System.Windows.Forms.ListBox();
            this.deviceSelectText = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // devicesList
            // 
            this.devicesList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.devicesList.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.devicesList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.devicesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.devicesList.ForeColor = System.Drawing.SystemColors.MenuText;
            this.devicesList.FormattingEnabled = true;
            this.devicesList.ItemHeight = 18;
            this.devicesList.Location = new System.Drawing.Point(12, 100);
            this.devicesList.Name = "devicesList";
            this.devicesList.Size = new System.Drawing.Size(660, 342);
            this.devicesList.TabIndex = 1;
            // 
            // deviceSelectText
            // 
            this.deviceSelectText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.deviceSelectText.AutoSize = true;
            this.deviceSelectText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deviceSelectText.Location = new System.Drawing.Point(219, 56);
            this.deviceSelectText.Name = "deviceSelectText";
            this.deviceSelectText.Size = new System.Drawing.Size(248, 18);
            this.deviceSelectText.TabIndex = 0;
            this.deviceSelectText.Text = "Выберите устройство для захвата";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.deviceSelectText);
            this.groupBox1.Controls.Add(this.devicesList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(684, 461);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // NetDeviceSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "NetDeviceSelect";
            this.Text = "NTM System";
            this.Load += new System.EventHandler(this.NetDeviceSelect_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox devicesList;
        private System.Windows.Forms.Label deviceSelectText;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

