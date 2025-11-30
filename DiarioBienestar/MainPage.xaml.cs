using System.ComponentModel;

namespace DiarioBienestar
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public string WelcomeText { get; set; }

        public MainPage()
        {
            InitializeComponent();
            WelcomeText = "Bienvenido a tu Diario de Bienestar";

            BindingContext = this;
        }
    }
}
