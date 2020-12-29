
namespace Latihan_08
{
    partial class FormSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbxWindowSize = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxTopM = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "WIndows Size";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbxWindowSize
            // 
            this.cbxWindowSize.FormattingEnabled = true;
            this.cbxWindowSize.Location = new System.Drawing.Point(271, 67);
            this.cbxWindowSize.Name = "cbxWindowSize";
            this.cbxWindowSize.Size = new System.Drawing.Size(121, 33);
            this.cbxWindowSize.TabIndex = 1;
            this.cbxWindowSize.SelectedIndexChanged += new System.EventHandler(this.cbxWindowSize_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 25);
            this.label2.TabIndex = 2;
            // 
            // cbxTopM
            // 
            this.cbxTopM.AutoSize = true;
            this.cbxTopM.Location = new System.Drawing.Point(271, 130);
            this.cbxTopM.Name = "cbxTopM";
            this.cbxTopM.Size = new System.Drawing.Size(128, 29);
            this.cbxTopM.TabIndex = 3;
            this.cbxTopM.Text = "Top Most";
            this.cbxTopM.UseVisualStyleBackColor = true;
            this.cbxTopM.CheckedChanged += new System.EventHandler(this.cbxTopM_CheckedChanged);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbxTopM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxWindowSize);
            this.Controls.Add(this.label1);
            this.Name = "FormSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxWindowSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbxTopM;
    }
}