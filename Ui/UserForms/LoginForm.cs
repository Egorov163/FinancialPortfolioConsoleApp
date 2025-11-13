using FinancialPortfolioConsoleApp.BL.Services;

namespace Ui
{
    public partial class LoginForm : Form
    {
        private AuthService _authService;

        public LoginForm(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (!_authService.Login(LoginTextBox.Text, PasswordTextBox.Text))
            {
                MessageBox.Show("Не удалось войти",
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
