namespace lynxAudioEnc
{
    partial class ProgressForm
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
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.lblEncodeStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(12, 46);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(832, 23);
            this.pbProgress.TabIndex = 0;
            // 
            // lblEncodeStatus
            // 
            this.lblEncodeStatus.AutoSize = true;
            this.lblEncodeStatus.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncodeStatus.ForeColor = System.Drawing.Color.White;
            this.lblEncodeStatus.Location = new System.Drawing.Point(7, 9);
            this.lblEncodeStatus.Name = "lblEncodeStatus";
            this.lblEncodeStatus.Size = new System.Drawing.Size(181, 25);
            this.lblEncodeStatus.TabIndex = 1;
            this.lblEncodeStatus.Text = "Encoding File 0 of 0:";
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(856, 84);
            this.ControlBox = false;
            this.Controls.Add(this.lblEncodeStatus);
            this.Controls.Add(this.pbProgress);
            this.Name = "ProgressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Encoding...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Label lblEncodeStatus;
    }
}