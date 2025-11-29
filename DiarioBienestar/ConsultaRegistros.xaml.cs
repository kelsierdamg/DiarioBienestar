using System.Collections.ObjectModel;

namespace DiarioBienestar;

public partial class ConsultaRegistros : ContentPage
{
    private ObservableCollection<EntradaDiaria> entradas;

    public ConsultaRegistros()
    {
        InitializeComponent();
    }

    protected async override void OnAppearing()
    {
        entradas = await ServicioDiario.LoadAsync();

        registrosList.ItemsSource = entradas
            .OrderByDescending(x => x.Date)
            .ToList();
    }

    private async void Eliminar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var item = button.CommandParameter as EntradaDiaria;

        bool confirm = await DisplayAlertAsync("Confirmar", "¿Eliminar este registro?", "Sí", "No");

        if (!confirm) return;

        entradas.Remove(item);
        await ServicioDiario.SaveAsync(entradas);

        registrosList.ItemsSource = entradas
            .OrderByDescending(x => x.Date)
            .ToList();
    }
}