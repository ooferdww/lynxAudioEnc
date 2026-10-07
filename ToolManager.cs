using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lynxAudioEnc
{
    public class ToolManager
    {
        public string ToolsFolderPath => Path.Combine(Application.StartupPath, "Data");

        public string FFmpeg => Path.Combine(ToolsFolderPath, "ffmpeg", "ffmpeg.exe");
        public string MP3ENC301 => Path.Combine(ToolsFolderPath, "mp3enc301", "mp3enc.exe");
        public string qaac => Path.Combine(ToolsFolderPath, "qaac", "qaac64.exe");
        public string lame => Path.Combine(ToolsFolderPath, "lame", "lame.exe");
        public string vac => Path.Combine(ToolsFolderPath, "vac-enc", "vac-enc.exe");
        public string oggenc => Path.Combine(ToolsFolderPath, "oggenc", "oggenc.exe");
        public string fdkaac => Path.Combine(ToolsFolderPath, "fdkaac", "fdkaac.exe");

        public string Quote(string uqpath)
        {
            return $"\"{uqpath}\"";
        }

        // le cleanup crew
        public void CleanupTempFile(
            string originalInputPath,
            string currentWavPath
            )
        {
            // this is a spaghetti attempt at bug fixing
            if (!originalInputPath.Equals(currentWavPath, StringComparison.OrdinalIgnoreCase))
            {
                if (File.Exists(currentWavPath))
                {
                    try
                    {
                        File.Delete(currentWavPath);
                    }
                    catch
                    {
                        //
                    }
                }
            }
        }

        // metadata muxing
        public bool MuxMeta(
            string sourcePath,
            string tempEncodedPath,
            string finalOutputPath
            )
        {
            if (!File.Exists(sourcePath) || !File.Exists(tempEncodedPath))
                return false;

            try
            {
                using (var sourceFile = TagLib.File.Create(sourcePath))
                using (var targetFile = TagLib.File.Create(tempEncodedPath))
                {
                    targetFile.Tag.Title = sourceFile.Tag.Title;
                    targetFile.Tag.Performers = sourceFile.Tag.Performers;
                    targetFile.Tag.Album = sourceFile.Tag.Album;
                    targetFile.Tag.AlbumArtists = sourceFile.Tag.AlbumArtists;
                    targetFile.Tag.Genres = sourceFile.Tag.Genres;
                    targetFile.Tag.Year = sourceFile.Tag.Year;
                    targetFile.Tag.Track = sourceFile.Tag.Track;
                    targetFile.Tag.TrackCount = sourceFile.Tag.TrackCount;
                    targetFile.Tag.Disc = sourceFile.Tag.Disc;
                    targetFile.Tag.DiscCount = sourceFile.Tag.DiscCount;
                    targetFile.Tag.Comment = sourceFile.Tag.Comment;

                    if (sourceFile.Tag.Pictures != null && sourceFile.Tag.Pictures.Length > 0)
                    {
                        targetFile.Tag.Pictures = sourceFile.Tag.Pictures;
                    }

                    targetFile.Save();
                }

                if (File.Exists(finalOutputPath))
                {
                    File.Delete(finalOutputPath);
                }

                File.Move(tempEncodedPath, finalOutputPath);

                return File.Exists(finalOutputPath);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Metadata muxing failed: {ex.Message}");
                return false;
            }

            // old ffmpeg function

            /* string extension = Path.GetExtension(finalOutputPath).ToLowerInvariant();
            // ffmpeg -i "source" -i "temp_encoded" -map 1:a:0 -map_metadata 0 -map 0:v:0? -c copy -y "final_output"
            string args = (extension == ".ogg")
        ? $"-i {Quote(sourcePath)} -i {Quote(tempEncodedPath)} -map 1:a:0 -map_metadata 0 -c copy -id3v2_version 0 -y {Quote(finalOutputPath)}"
        : $"-i {Quote(sourcePath)} -i {Quote(tempEncodedPath)} -map 1:a:0 -map_metadata 0 -map 0:v:0? -c copy -y {Quote(finalOutputPath)}";

            ProcessStartInfo FFmpeg_metamux = new ProcessStartInfo
            {
                FileName = FFmpeg,
                Arguments = args,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process FFmpeg_metamuxP = Process.Start(FFmpeg_metamux);
            if (FFmpeg_metamuxP == null) return false;

            using (FFmpeg_metamuxP)
            {
                FFmpeg_metamuxP.WaitForExit();

                // exit check
                return FFmpeg_metamuxP.ExitCode == 0 && File.Exists(finalOutputPath);
            } */
        }
    }
}
