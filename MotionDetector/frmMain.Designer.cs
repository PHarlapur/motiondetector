namespace Detector
{
    partial class frmMain
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
            this.btnDetect = new System.Windows.Forms.Button();
            this.lblMotionTimeValue = new System.Windows.Forms.Label();
            this.lblMotionTime = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDetect
            // 
            this.btnDetect.Location = new System.Drawing.Point(12, 31);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.Size = new System.Drawing.Size(139, 23);
            this.btnDetect.TabIndex = 0;
            this.btnDetect.Text = "Start Motion Detection";
            this.btnDetect.UseVisualStyleBackColor = true;
            this.btnDetect.Click += new System.EventHandler(this.btnDetect_Click);
            // 
            // lblMotionTimeValue
            // 
            this.lblMotionTimeValue.AutoSize = true;
            this.lblMotionTimeValue.Location = new System.Drawing.Point(181, 67);
            this.lblMotionTimeValue.Name = "lblMotionTimeValue";
            this.lblMotionTimeValue.Size = new System.Drawing.Size(0, 13);
            this.lblMotionTimeValue.TabIndex = 1;
            // 
            // lblMotionTime
            // 
            this.lblMotionTime.AutoSize = true;
            this.lblMotionTime.Location = new System.Drawing.Point(15, 67);
            this.lblMotionTime.Name = "lblMotionTime";
            this.lblMotionTime.Size = new System.Drawing.Size(112, 13);
            this.lblMotionTime.TabIndex = 2;
            this.lblMotionTime.Text = "Last Motion Detected:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(175, 31);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close Motion Detection";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 104);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblMotionTime);
            this.Controls.Add(this.lblMotionTimeValue);
            this.Controls.Add(this.btnDetect);
            this.Name = "frmMain";
            this.Text = "Motion Detector";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDetect;
        private System.Windows.Forms.Label lblMotionTimeValue;
        private System.Windows.Forms.Label lblMotionTime;
        private System.Windows.Forms.Button btnClose;
    }
}

