using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace lynxAudioEnc
{
    public class AudioConverter
    {
        private ToolManager tools = new ToolManager();

        public string ConvToTempWav(
            string inputFilePath,
            int chosenSampleRate,
            string encSupportedDepth,
            string encSupportedFormat,
            int chosenHardCutoff
            )
        {
            string tempWavPath = Path.Combine(Path.GetTempPath(), $"lynx_temp_{Guid.NewGuid():N}.wav");

            ProcessStartInfo FFmpeg_tmpconv = new ProcessStartInfo()
            {
                FileName = tools.FFmpeg,
                Arguments = $"-i {tools.Quote(inputFilePath)} -vn -sn -dn -map_metadata -1 -af \"aresample={chosenSampleRate}:resampler=soxr:cheby=1:dither_method=shibata:precision=33:osf={encSupportedDepth},firequalizer=gain='if(gte(f,{chosenHardCutoff}), -120, 0)'\" -c:a {encSupportedFormat} -y {tools.Quote(tempWavPath)}",
                // Arguments = $"-i {tools.Quote(inputFilePath)} -vn -sn -dn -map_metadata -1 -af \"aresample={chosenSampleRate}:resampler=soxr:cheby=1:dither_method=shibata:precision=33:osf={encSupportedDepth}:cutoff={chosenHardCutoff}\" -c:a {encSupportedFormat} -y {tools.Quote(tempWavPath)}",
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process FFmpeg_tmpconvP = Process.Start(FFmpeg_tmpconv);
            if (FFmpeg_tmpconvP == null)
            {
                throw new InvalidOperationException($"Failed to launch FFmpeg from path: {tools.FFmpeg}");
            }

            using (FFmpeg_tmpconvP)
            {
                FFmpeg_tmpconvP.WaitForExit();

                if (FFmpeg_tmpconvP.ExitCode != 0 || !File.Exists(tempWavPath))
                {
                    throw new Exception($"FFmpeg failed to decode file (Exit code {FFmpeg_tmpconvP.ExitCode}): {Path.GetFileName(inputFilePath)}");
                }
            }

            return tempWavPath;
        }
    }
}

