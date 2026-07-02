using CHD.Core.Services;
using Common;
using RomForge.Core.Models.Compression;
using System.IO;

namespace RomForge.Core.Services.Patch;

public class CompressKnownConverter(Action<string, LogLevel> log, Action<int> setProgress, Action<string> setStatus)
{
    public async Task ConvertAsync(DetectResult detected, string outputPath, string? outputCuePath, List<string> copiedTrackPaths, CancellationToken ct)
    {
        switch (detected.Format)
        {
            case RomFormat.Bin:
                {
                    setStatus("CHD 변환 중...");
                    setProgress(0);

                    FileConverter converter = new();
                    converter.LogMessage += (_, e) => log(e.Message, e.Level);
                    converter.ProgressChanged += (_, e) => setProgress(e.Progress);

                    var chdResult = await converter.ConvertFileAsync(outputCuePath!, ct);

                    if (!chdResult.Success)
                        throw new Exception($"CHD 변환 실패: {chdResult.Message}");

                    File.Delete(outputPath);
                    File.Delete(outputCuePath!);

                    foreach (var trackPath in copiedTrackPaths)
                        if (File.Exists(trackPath))
                            File.Delete(trackPath);

                    copiedTrackPaths.Clear();
                    break;
                }
            case RomFormat.Iso:
                {
                    setStatus("CHD 변환 중...");
                    setProgress(0);

                    FileConverter converter = new();
                    converter.LogMessage += (_, e) => log(e.Message, e.Level);
                    converter.ProgressChanged += (_, e) => setProgress(e.Progress);

                    var chdResult = await converter.ConvertFileAsync(outputPath, ct);

                    if (!chdResult.Success)
                        throw new Exception($"CHD 변환 실패: {chdResult.Message}");

                    File.Delete(outputPath);
                    break;
                }
        }
    }
}