namespace MockClassroomProject
{
    partial class Form1
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
            this.btnGetUserInput = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetUserInput
            // 
            this.btnGetUserInput.Location = new System.Drawing.Point(95, 114);
            this.btnGetUserInput.Name = "btnGetUserInput";
            this.btnGetUserInput.Size = new System.Drawing.Size(89, 23);
            this.btnGetUserInput.TabIndex = 0;
            this.btnGetUserInput.Text = "Get User Input";
            this.btnGetUserInput.UseVisualStyleBackColor = true;
            this.btnGetUserInput.Click += new System.EventHandler(this.btnGetUserInput_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnGetUserInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetUserInput;
    }
}

