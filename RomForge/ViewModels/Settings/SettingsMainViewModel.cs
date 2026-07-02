using RomForge.Core;

namespace RomForge.ViewModels.Settings;

public class SettingsMainViewModel : MultiToolTabViewModel
{
    public PatchSettingsMainViewModel Patch { get; }

    public PS1SettingsMainViewModel PS1 { get; }

    public SettingsMainViewModel(AppConfig config)
    {
        Patch = new PatchSettingsMainViewModel(config);
        PS1 = new PS1SettingsMainViewModel(config);

        Tools.Add(Patch);
        Tools.Add(PS1);

        InitializeMultiTools();
    }
}