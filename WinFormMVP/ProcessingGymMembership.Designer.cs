namespace WinFormMVP
{
    partial class ProcessingGymMembership
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
            this.lblMemberDetails = new System.Windows.Forms.Label();
            this.btnProceed = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMemberDetails
            // 
            this.lblMemberDetails.AutoSize = true;
            this.lblMemberDetails.Location = new System.Drawing.Point(13, 13);
            this.lblMemberDetails.Name = "lblMemberDetails";
            this.lblMemberDetails.Size = new System.Drawing.Size(80, 13);
            this.lblMemberDetails.TabIndex = 0;
            this.lblMemberDetails.Text = "Member Details";
            // 
            // btnProceed
            // 
            this.btnProceed.Location = new System.Drawing.Point(16, 86);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(142, 23);
            this.btnProceed.TabIndex = 1;
            this.btnProceed.Text = "Proceed with Renewal";
            this.btnProceed.UseVisualStyleBackColor = true;
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(13, 116);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 2;
            // 
            // ProcessingGymMembership
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 163);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnProceed);
            this.Controls.Add(this.lblMemberDetails);
            this.Name = "ProcessingGymMembership";
            this.Text = "ProcessingGymMembership";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMemberDetails;
        private System.Windows.Forms.Button btnProceed;
        private System.Windows.Forms.Label lblMessage;
    }
}