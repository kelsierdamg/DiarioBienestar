using System.ComponentModel;

namespace DiarioBienestar
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public string WelcomeText { get; set; }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            WelcomeText = "Bienvenido a tu Diario de Bienestar";
        }
    }
}
