using System.Collections.ObjectModel;
using System.Text.Json;

namespace DiarioBienestar;

public static class ServicioDiario
{
    private static readonly string FilePath =
        Path.Combine(FileSystem.AppDataDirectory, "diary.json");

    public static async Task SaveAsync(ObservableCollection<EntradaDiaria> entradas)
    {
        var json = JsonSerializer.Serialize(entradas);
        await File.WriteAllTextAsync(FilePath, json);
    }

    public static async Task<ObservableCollection<EntradaDiaria>> LoadAsync()
    {
        if (!File.Exists(FilePath))
            return new ObservableCollection<EntradaDiaria>();

        var json = await File.ReadAllTextAsync(FilePath);
        return JsonSerializer.Deserialize<ObservableCollection<EntradaDiaria>>(json)
               ?? new ObservableCollection<EntradaDiaria>();
    }
}