using System.Collections.ObjectModel;

namespace DiarioBienestar;

public partial class EstadisticasPage : ContentPage
{
    private ObservableCollection<EntradaDiaria> entradas;

    public EstadisticasPage()
    {
        InitializeComponent();
    }

    protected async override void OnAppearing()
    {
        entradas = await ServicioDiario.LoadAsync();

        var semana = entradas
            .Where(x => x.Date >= DateTime.Now.AddDays(-7))
            .ToList();

        if (semana.Count == 0)
        {
            lblPromedioActividad.Text = "Sin datos esta semana.";
            return;
        }

        double promActividad = semana.Average(x => x.Activity);
        double promEnergia = semana.Average(x => x.Energy);

        lblPromedioActividad.Text = $"Promedio Actividad: {promActividad:F1}";
        lblPromedioEnergia.Text = $"Promedio Energía: {promEnergia:F1}";

        overallProgress.Progress = promActividad / 10.0;
    }
}