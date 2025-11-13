using FinancialPortfolioConsoleApp.BL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ui
{
    public partial class RegForm : Form
    {
        AuthService _authService;
        public RegForm(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private void RegButton_Click(object sender, EventArgs e)
        {
            if (!_authService.Registration(RegLoginTextBox.Text, RegPasswordTextBox.Text))
            {
                MessageBox.Show("Не удалось зарегистрировать пользователя",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                Close();
            }
        }
    }
}
