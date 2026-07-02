using System.ComponentModel;

namespace RomForge.ViewModels.Util;

public class UtilMainViewModel : MultiToolTabViewModel
{
    public HashMainViewModel HashVM { get; } = new();

    public UtilMainViewModel()
    {
        Tools.Add(HashVM);

        foreach (var tool in Tools)
            tool.PropertyChanged += Child_PropertyChanged;

        InitializeMultiTools();
    }

    private static bool CheckAdmin()
    {
        var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
        var principal = new System.Security.Principal.WindowsPrincipal(identity);

        return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
    }

    private void Child_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(IsLocked) || e.PropertyName == nameof(IsIdle))
            OnPropertyChanged(nameof(IsIdle));
    }
}