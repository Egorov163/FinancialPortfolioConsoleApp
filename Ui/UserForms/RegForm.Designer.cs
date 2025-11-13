namespace Ui
{
    partial class RegForm
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
            RegButton = new Button();
            label2 = new Label();
            label1 = new Label();
            RegPasswordTextBox = new TextBox();
            RegLoginTextBox = new TextBox();
            SuspendLayout();
            // 
            // RegButton
            // 
            RegButton.Location = new Point(12, 74);
            RegButton.Name = "RegButton";
            RegButton.Size = new Size(186, 29);
            RegButton.TabIndex = 9;
            RegButton.Text = "Зарегистрироваться";
            RegButton.UseVisualStyleBackColor = true;
            RegButton.Click += this.RegButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 41);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 8;
            label2.Text = "Пароль";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 7;
            label1.Text = "Логин";
            // 
            // RegPasswordTextBox
            // 
            RegPasswordTextBox.Location = new Point(80, 41);
            RegPasswordTextBox.Name = "RegPasswordTextBox";
            RegPasswordTextBox.Size = new Size(336, 27);
            RegPasswordTextBox.TabIndex = 6;
            RegPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // RegLoginTextBox
            // 
            RegLoginTextBox.Location = new Point(80, 6);
            RegLoginTextBox.Name = "RegLoginTextBox";
            RegLoginTextBox.Size = new Size(336, 27);
            RegLoginTextBox.TabIndex = 5;
            // 
            // RegForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(544, 183);
            Controls.Add(RegButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(RegPasswordTextBox);
            Controls.Add(RegLoginTextBox);
            Name = "RegForm";
            Text = "RegForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button RegButton;
        private Label label2;
        private Label label1;
        private TextBox RegPasswordTextBox;
        private TextBox RegLoginTextBox;
    }
}