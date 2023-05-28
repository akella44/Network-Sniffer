namespace Shell.NTM.CommonUi
{
    partial class SuspTrafficForm
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
            this.suspTrafficGridView = new System.Windows.Forms.DataGridView();
            this.IpAdress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PacketsPerSecond = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.suspTrafficGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // suspTrafficGridView
            // 
            this.suspTrafficGridView.AllowDrop = true;
            this.suspTrafficGridView.AllowUserToOrderColumns = true;
            this.suspTrafficGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.suspTrafficGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.suspTrafficGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.suspTrafficGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.suspTrafficGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.suspTrafficGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.suspTrafficGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IpAdress,
            this.PacketsPerSecond});
            this.suspTrafficGridView.GridColor = System.Drawing.SystemColors.Window;
            this.suspTrafficGridView.Location = new System.Drawing.Point(12, 12);
            this.suspTrafficGridView.Name = "suspTrafficGridView";
            this.suspTrafficGridView.Size = new System.Drawing.Size(319, 378);
            this.suspTrafficGridView.TabIndex = 0;
            // 
            // IpAdress
            // 
            this.IpAdress.HeaderText = "Ip адрес";
            this.IpAdress.Name = "IpAdress";
            this.IpAdress.ReadOnly = true;
            // 
            // PacketsPerSecond
            // 
            this.PacketsPerSecond.HeaderText = "Пакеты/сек";
            this.PacketsPerSecond.Name = "PacketsPerSecond";
            this.PacketsPerSecond.ReadOnly = true;
            // 
            // SuspTrafficForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 415);
            this.Controls.Add(this.suspTrafficGridView);
            this.Name = "SuspTrafficForm";
            this.Text = "Подозрительный трафик";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SuspTrafficForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.suspTrafficGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView suspTrafficGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpAdress;
        private System.Windows.Forms.DataGridViewTextBoxColumn PacketsPerSecond;
    }
}