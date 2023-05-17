namespace Shell.NTM.CommonUi
{
    partial class Filters
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
            this.filtersHandlerLabel = new System.Windows.Forms.Label();
            this.filtersLabel = new System.Windows.Forms.Label();
            this.filtersGroupBox = new System.Windows.Forms.GroupBox();
            this.filtersGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // filtersHandlerLabel
            // 
            this.filtersHandlerLabel.AutoSize = true;
            this.filtersHandlerLabel.Location = new System.Drawing.Point(12, 9);
            this.filtersHandlerLabel.Name = "filtersHandlerLabel";
            this.filtersHandlerLabel.Size = new System.Drawing.Size(112, 13);
            this.filtersHandlerLabel.TabIndex = 1;
            this.filtersHandlerLabel.Text = "Доступные фильтры";
            // 
            // filtersLabel
            // 
            this.filtersLabel.AutoSize = true;
            this.filtersLabel.Location = new System.Drawing.Point(6, 16);
            this.filtersLabel.Name = "filtersLabel";
            this.filtersLabel.Size = new System.Drawing.Size(0, 13);
            this.filtersLabel.TabIndex = 2;
            // 
            // filtersGroupBox
            // 
            this.filtersGroupBox.BackColor = System.Drawing.Color.White;
            this.filtersGroupBox.Controls.Add(this.filtersLabel);
            this.filtersGroupBox.Location = new System.Drawing.Point(12, 25);
            this.filtersGroupBox.Name = "filtersGroupBox";
            this.filtersGroupBox.Size = new System.Drawing.Size(351, 194);
            this.filtersGroupBox.TabIndex = 3;
            this.filtersGroupBox.TabStop = false;
            // 
            // Filters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(375, 255);
            this.Controls.Add(this.filtersGroupBox);
            this.Controls.Add(this.filtersHandlerLabel);
            this.Name = "Filters";
            this.Text = "Filters";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Filters_FormClosing);
            this.Load += new System.EventHandler(this.Filters_Load);
            this.filtersGroupBox.ResumeLayout(false);
            this.filtersGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label filtersHandlerLabel;
        private System.Windows.Forms.Label filtersLabel;
        private System.Windows.Forms.GroupBox filtersGroupBox;
    }
}