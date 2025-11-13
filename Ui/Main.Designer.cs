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
            components = new System.ComponentModel.Container();
            AuthLabel = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            contextMenuStrip2 = new ContextMenuStrip(components);
            contextMenuStrip3 = new ContextMenuStrip(components);
            пользователиToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            сущностиToolStripMenuItem = new ToolStripMenuItem();
            пользователиToolStripMenuItem1 = new ToolStripMenuItem();
            авторизацияToolStripMenuItem = new ToolStripMenuItem();
            добавитьПользоватеяToolStripMenuItem = new ToolStripMenuItem();
            удалитьПользователяToolStripMenuItem = new ToolStripMenuItem();
            всеПользователиToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip3.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // AuthLabel
            // 
            AuthLabel.AutoSize = true;
            AuthLabel.Location = new Point(12, 28);
            AuthLabel.Name = "AuthLabel";
            AuthLabel.Size = new Size(167, 20);
            AuthLabel.TabIndex = 1;
            AuthLabel.Text = "Вы не авторизовались";
            AuthLabel.Click += AuthLabel_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.ImageScalingSize = new Size(20, 20);
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(61, 4);
            contextMenuStrip2.Text = "Сущности";
            // 
            // contextMenuStrip3
            // 
            contextMenuStrip3.ImageScalingSize = new Size(20, 20);
            contextMenuStrip3.Items.AddRange(new ToolStripItem[] { пользователиToolStripMenuItem });
            contextMenuStrip3.Name = "contextMenuStrip3";
            contextMenuStrip3.Size = new Size(178, 28);
            // 
            // пользователиToolStripMenuItem
            // 
            пользователиToolStripMenuItem.Name = "пользователиToolStripMenuItem";
            пользователиToolStripMenuItem.Size = new Size(177, 24);
            пользователиToolStripMenuItem.Text = "Пользователи";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { сущностиToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // сущностиToolStripMenuItem
            // 
            сущностиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { пользователиToolStripMenuItem1 });
            сущностиToolStripMenuItem.Name = "сущностиToolStripMenuItem";
            сущностиToolStripMenuItem.Size = new Size(91, 24);
            сущностиToolStripMenuItem.Text = "Сущности";
            // 
            // пользователиToolStripMenuItem1
            // 
            пользователиToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { авторизацияToolStripMenuItem, добавитьПользоватеяToolStripMenuItem, удалитьПользователяToolStripMenuItem, всеПользователиToolStripMenuItem });
            пользователиToolStripMenuItem1.Name = "пользователиToolStripMenuItem1";
            пользователиToolStripMenuItem1.Size = new Size(224, 26);
            пользователиToolStripMenuItem1.Text = "Пользователи";
            // 
            // авторизацияToolStripMenuItem
            // 
            авторизацияToolStripMenuItem.Name = "авторизацияToolStripMenuItem";
            авторизацияToolStripMenuItem.Size = new Size(259, 26);
            авторизацияToolStripMenuItem.Text = "Авторизация";
            авторизацияToolStripMenuItem.Click += AuthToolStripMenuItem_Click;
            // 
            // добавитьПользоватеяToolStripMenuItem
            // 
            добавитьПользоватеяToolStripMenuItem.Name = "добавитьПользоватеяToolStripMenuItem";
            добавитьПользоватеяToolStripMenuItem.Size = new Size(259, 26);
            добавитьПользоватеяToolStripMenuItem.Text = "Добавить пользователя";
            добавитьПользоватеяToolStripMenuItem.Click += RegistrationUserToolStripMenuItem_Click;
            // 
            // удалитьПользователяToolStripMenuItem
            // 
            удалитьПользователяToolStripMenuItem.Name = "удалитьПользователяToolStripMenuItem";
            удалитьПользователяToolStripMenuItem.Size = new Size(259, 26);
            удалитьПользователяToolStripMenuItem.Text = "Удалить пользователя";
            // 
            // всеПользователиToolStripMenuItem
            // 
            всеПользователиToolStripMenuItem.Name = "всеПользователиToolStripMenuItem";
            всеПользователиToolStripMenuItem.Size = new Size(259, 26);
            всеПользователиToolStripMenuItem.Text = "Все пользователи";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            Controls.Add(AuthLabel);
            MainMenuStrip = menuStrip1;
            Name = "Main";
            Text = "Main";
            Load += Main_Load;
            contextMenuStrip3.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label AuthLabel;
        private ContextMenuStrip contextMenuStrip1;
        private ContextMenuStrip contextMenuStrip2;
        private ContextMenuStrip contextMenuStrip3;
        private ToolStripMenuItem пользователиToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem сущностиToolStripMenuItem;
        private ToolStripMenuItem пользователиToolStripMenuItem1;
        private ToolStripMenuItem авторизацияToolStripMenuItem;
        private ToolStripMenuItem добавитьПользоватеяToolStripMenuItem;
        private ToolStripMenuItem удалитьПользователяToolStripMenuItem;
        private ToolStripMenuItem всеПользователиToolStripMenuItem;
    }
}