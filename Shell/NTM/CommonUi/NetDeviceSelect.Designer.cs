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
            this.deviceSelectText = new System.Windows.Forms.Label();
            this.devicesList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // deviceSelectText
            // 
            this.deviceSelectText.AutoSize = true;
            this.deviceSelectText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deviceSelectText.Location = new System.Drawing.Point(125, 96);
            this.deviceSelectText.Name = "deviceSelectText";
            this.deviceSelectText.Size = new System.Drawing.Size(248, 18);
            this.deviceSelectText.TabIndex = 0;
            this.deviceSelectText.Text = "Выберите устройство для захвата";
            this.deviceSelectText.Click += new System.EventHandler(this.DevicesList_DoubleClick);
            // 
            // devicesList
            // 
            this.devicesList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.devicesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.devicesList.ForeColor = System.Drawing.SystemColors.MenuText;
            this.devicesList.FormattingEnabled = true;
            this.devicesList.ItemHeight = 18;
            this.devicesList.Location = new System.Drawing.Point(128, 121);
            this.devicesList.Name = "devicesList";
            this.devicesList.Size = new System.Drawing.Size(768, 468);
            this.devicesList.TabIndex = 1;
            this.devicesList.SelectedIndexChanged += new System.EventHandler(this.DevicesList_SelectedIndexChanged);
            // 
            // NetDeviceSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1008, 601);
            this.Controls.Add(this.devicesList);
            this.Controls.Add(this.deviceSelectText);
            this.MinimumSize = new System.Drawing.Size(1024, 640);
            this.Name = "NetDeviceSelect";
            this.Text = "NTM System";
            this.Load += new System.EventHandler(this.NetDeviceSelect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label deviceSelectText;
        private System.Windows.Forms.ListBox devicesList;
    }
}

