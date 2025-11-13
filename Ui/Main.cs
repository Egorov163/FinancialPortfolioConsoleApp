using FinancialPortfolioConsoleApp.BL.Contexts;
using FinancialPortfolioConsoleApp.BL.Data;
using FinancialPortfolioConsoleApp.BL.Data.Repositories;
using FinancialPortfolioConsoleApp.BL.Services;

namespace Ui
{
    public partial class Main : Form
    {
        // Контексты.
        private readonly AppDbContext _appDbContext;
        private readonly UserContext _userContext;
        // Репозитории.
        private readonly UserRepository _userRepository;
        private readonly PortfolioRepository _portfolioRepository;
        private readonly PortfolioStocksRepository _portfolioStocksRepository;
        private readonly StockRepository _stockRepository;
        // Сервисы.
        private readonly AuthService _authService;
        private readonly UserService _userService;
        private readonly StockService _stockService;
        private readonly PortfolioService _portfolioService;
        private readonly PortfolioStocksService _portfolioStocksService;


        public Main()
        {
            // Контексты.
            _appDbContext = new AppDbContext();
            _userContext = new UserContext();
            // Репозитории.
            _userRepository = new UserRepository(_appDbContext);
            _portfolioRepository = new PortfolioRepository(_appDbContext);
            _portfolioStocksRepository = new PortfolioStocksRepository(_appDbContext);
            _stockRepository = new StockRepository(_appDbContext);
            // Сервисы.
            _authService = new AuthService(_userRepository, _userContext);
            _userService = new UserService(_userRepository, _authService, _userContext);
            _stockService = new StockService(_stockRepository, _portfolioStocksRepository);
            _portfolioStocksService = new PortfolioStocksService(_stockService, _portfolioStocksRepository);
            _portfolioService = new PortfolioService(_userContext, _stockService, _portfolioStocksService, _portfolioRepository);

            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void AuthButton_Click(object sender, EventArgs e)
        {
            var form = new LoginForm(_authService);
            form.ShowDialog();

            if (_userContext.CurrentUser is not null)
            {
                AuthLabel.Text = _userContext.CurrentUser.Name;
                Update();
            }
        }
    }
}
