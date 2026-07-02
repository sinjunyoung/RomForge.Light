using System.IO;

namespace RomForge.Core.Services;

public static class ProcessExtensions
{
    public static void OpenFolder(this string folder)
    {
        if (Directory.Exists(folder))
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = folder,
                UseShellExecute = true
            });
        }
    }
}