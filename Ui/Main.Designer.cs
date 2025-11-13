namespace Ui
{
    partial class Main
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
            AuthButton = new Button();
            AuthLabel = new Label();
            SuspendLayout();
            // 
            // AuthButton
            // 
            AuthButton.Location = new Point(12, 54);
            AuthButton.Name = "AuthButton";
            AuthButton.Size = new Size(172, 29);
            AuthButton.TabIndex = 0;
            AuthButton.Text = "Авторизация";
            AuthButton.UseVisualStyleBackColor = true;
            AuthButton.Click += AuthButton_Click;
            // 
            // AuthLabel
            // 
            AuthLabel.AutoSize = true;
            AuthLabel.Location = new Point(12, 9);
            AuthLabel.Name = "AuthLabel";
            AuthLabel.Size = new Size(167, 20);
            AuthLabel.TabIndex = 1;
            AuthLabel.Text = "Вы не авторизовались";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(AuthLabel);
            Controls.Add(AuthButton);
            Name = "Main";
            Text = "Main";
            Load += Main_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AuthButton;
        private Label AuthLabel;
    }
}