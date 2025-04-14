using ClientScheduler.Forms;
using ClientScheduler.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace ClientScheduler
{
    public partial class LoginScreen : Form
    {
        private readonly AuthService _authService;
        private readonly IServiceProvider _serviceProvider;
        
        public LoginScreen(AuthService authService, IServiceProvider serviceProvider)
        {
            _authService = authService;
           
            _serviceProvider = serviceProvider;
            InitializeComponent();


            
           
        }

        private async void loginBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTxt.Text;
            string password = passwordTxt.Text;

            try
            {
                if (await _authService.ValidateUser(username, password))
                {



                    // Retrieve MainForm from the service provider
                    var mainScreen = _serviceProvider.GetRequiredService<MainScreen>();
                    mainScreen.FormClosed += (s, args) => this.Close();

                    this.Hide();

                    mainScreen.Show();



                }
                else
                {
                    CultureInfo culture = CultureInfo.CurrentCulture;

                    if (culture.TwoLetterISOLanguageName.ToUpper() == "ES" || culture.TwoLetterISOLanguageName.ToUpper() == "MX")
                    {
                        throw new Exception("Credenciales incorrectas");
                    }
                    else 
                    {
                        throw new Exception("Incorrect credentials");
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
            finally 
            {
                usernameTxt.Text = "";
                passwordTxt.Text = "";
            }

        }
    }
}
