using System.Collections.ObjectModel;

namespace DiarioBienestar;

public partial class RegistroPage : ContentPage
{
    private ObservableCollection<EntradaDiaria> entradas;

    public RegistroPage()
    {
        InitializeComponent();
    }

    protected async override void OnAppearing()
    {
        entradas = await ServicioDiario.LoadAsync();
    }

    private void activitySlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        activityProgress.Progress = e.NewValue / 10.0;
    }

    private async void Guardar_Clicked(object sender, EventArgs e)
    {
        var entrada = new EntradaDiaria
        {
            Date = (DateTime)datePicker.Date,
            Description = entryEditor.Text,
            Activity = activitySlider.Value,
            Energy = (int)energyStepper.Value
        };

        entradas.Add(entrada);
        await ServicioDiario.SaveAsync(entradas);

        await DisplayAlert("Éxito", "Registro guardado.", "OK");

        entryEditor.Text = "";
        activitySlider.Value = 0;
        energyStepper.Value = 1;
        datePicker.Date = DateTime.Now;
    }
}