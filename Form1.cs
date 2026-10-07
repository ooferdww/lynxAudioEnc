using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lynxAudioEnc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            cobBitrate.SelectedIndex = 5;
            cobSampleRate.SelectedIndex = 3;
            cobEncoder.SelectedIndex = 2;
            cobRateControl.SelectedIndex = 0;
            txtOutLoc.Enabled = false;
            btOutLoc.Enabled = false;
            txtThreadCount.Text = Environment.ProcessorCount.ToString();
        }

        private List<string> sourceFilePaths = new List<string>();
        private AudioConverter converter = new AudioConverter();
        private ToolManager tools = new ToolManager();

        private void txtCustomBitrate_TextChanged(object sender, EventArgs e)
        {
            cobBitrate.Enabled = string.IsNullOrWhiteSpace(txtCustomBitrate.Text);
        }

        private void txtCustomBitrate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCustomSampleRate_TextChanged(object sender, EventArgs e)
        {
            cobSampleRate.Enabled = string.IsNullOrWhiteSpace(txtCustomSampleRate.Text);
        }

        private void txtCustomSampleRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHardCutoff_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtThreadCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtThreadCount_Leave(object sender, EventArgs e)
        {
            int maxSystemThreads = Environment.ProcessorCount;

            if (!int.TryParse(txtThreadCount.Text, out int parsedValue) || parsedValue < 1)
            {
                txtThreadCount.Text = "1";
            }
            else if (parsedValue > maxSystemThreads)
            {
                txtThreadCount.Text = maxSystemThreads.ToString();
            }
        }

        private void txtHardCutoff_Leave(object sender, EventArgs e)
        {
            int sampleRT = GetActiveSampleRate();
            if (!int.TryParse(txtHardCutoff.Text, out int parsedCutoff) || parsedCutoff > sampleRT / 2)
            {
                txtHardCutoff.Text = (sampleRT / 2).ToString();
            }
        }

        private void cbSameDirAsInput_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = cbSameDirAsInput.Checked;

            txtOutLoc.Enabled = !isChecked;
            btOutLoc.Enabled = !isChecked;
        }

        private int GetActiveBitrate()
        {
            string activeBitrateText;

            if (!string.IsNullOrWhiteSpace(txtCustomBitrate.Text))
            {
                activeBitrateText = txtCustomBitrate.Text?.Trim() ?? "128";
            }
            else
            {
                activeBitrateText = cobBitrate.SelectedItem?.ToString() ?? "128";
            }

            return int.Parse(activeBitrateText);
        }

        private int GetActiveSampleRate()
        {
            string activeSampleRateText;

            if (!string.IsNullOrWhiteSpace(txtCustomSampleRate.Text))
            {
                activeSampleRateText = txtCustomSampleRate.Text?.Trim() ?? "44100";
            }
            else
            {
                activeSampleRateText = cobSampleRate.SelectedItem?.ToString() ?? "44100";
            }

            return int.Parse(activeSampleRateText);
        }

        private int GetActiveThreadCount()
        {
            int maxSystemThreads = Environment.ProcessorCount;

            if (int.TryParse(txtThreadCount.Text?.Trim(), out int threads))
            {
                return Math.Max(1, Math.Min(threads, maxSystemThreads));
            }

            return maxSystemThreads; // fallback
        }

        private void btAddFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select source audio files";
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "Audio Files (*.wav;*.flac;*.mp3;*.m4a;*.m4b;*.aif;*.aiff;*.wv;*.ape;*.shn;*.tta;*.aac;*.ogg;*.opus;*.mpc;*.wma;*.spx)|*.wav;*.flac;*.mp3;*.m4a;*.m4b;*.aif;*.aiff;*.wv;*.ape;*.shn;*.tta;*.aac;*.ogg;*.opus;*.mpc;*.wma;*.spx|All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fullPath in openFileDialog.FileNames)
                    {
                        if (!sourceFilePaths.Contains(fullPath))
                        {
                            sourceFilePaths.Add(fullPath);
                            lstAudioFiles.Items.Add(Path.GetFileName(fullPath));
                        }
                    }
                }
            }
        }

        private void btRmFile_Click(object sender, EventArgs e)
        {
            if (lstAudioFiles.SelectedIndices.Count > 0)
            {
                for (int i = lstAudioFiles.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    int indexForRemoval = lstAudioFiles.SelectedIndices[i];
                    sourceFilePaths.RemoveAt(indexForRemoval);
                    lstAudioFiles.Items.RemoveAt(indexForRemoval);
                }
            }
        }

        private void btOutLoc_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select output folder";
                folderDialog.ShowNewFolderButton = true;
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtOutLoc.Text = folderDialog.SelectedPath;
                }
            }
        }

        private enum AudioEncoder
        {
            Qaac = 0,
            FdkAac = 1,
            VacEnc = 2,
            OggEnc = 3,
            FhgMp3 = 4,
            LameMp3 = 5
        }

        private enum RateControlMode
        {
            Vbr = 0,
            Cvbr = 1,
            Tvbr = 2,
            Abr = 3,
            Cbr = 4
        }

        private async void btStartEnc_Click(object sender, EventArgs e)
        {
            if (sourceFilePaths.Count == 0)
            {
                MessageBox.Show("Please add at least one file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!cbSameDirAsInput.Checked && string.IsNullOrWhiteSpace(txtOutLoc.Text))
            {
                MessageBox.Show("Please select an output location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string outFolder = txtOutLoc.Text;

            int ActiveSR = GetActiveSampleRate();
            float ActiveSR_khz = ActiveSR / 1000.0f;

            int ActiveCutoff = int.Parse(txtHardCutoff?.Text ?? "20000");
            int CutoffMax = ActiveSR / 2;
            if (ActiveCutoff > CutoffMax)
            {
                ActiveCutoff = CutoffMax;
            }
            // float ActiveCutoffF = (float)ActiveCutoff / (float)CutoffMax;

            // active bitrate fix for mp3
            int ActiveBitrate = GetActiveBitrate();
            int ActiveBitrateMP3 = GetActiveBitrate();
            if (ActiveSR > 11026 && ActiveSR < 22051 && ActiveBitrateMP3 > 160)
            {
                ActiveBitrateMP3 = 160;
            }
            else if (ActiveSR < 11026 && ActiveBitrateMP3 > 64)
            {
                ActiveBitrateMP3 = 64;
            }

            int ActiveThreadCount = GetActiveThreadCount();

            string qaacRC = "--tvbr 127";
            switch ((RateControlMode)cobRateControl.SelectedIndex)
            {
                case RateControlMode.Vbr:
                case RateControlMode.Cvbr:
                    qaacRC = $"--cvbr {ActiveBitrate}";
                    break;
                case RateControlMode.Tvbr:
                    qaacRC = $"--tvbr {cobTVBR.SelectedItem}";
                    break;
                case RateControlMode.Abr:
                case RateControlMode.Cbr:
                    qaacRC = $"--cbr {ActiveBitrate}";
                    break;
            }

            string fdkRC = $"-b {ActiveBitrate}";
            if (cobRateControl.SelectedIndex == 2) {
                fdkRC = $"-m {cobTVBR.SelectedIndex + 1}";
            }

            string oggRC = $"-b {ActiveBitrate}";
            if (cobRateControl.SelectedIndex == 2) {
                oggRC = $"-q {cobTVBR.SelectedIndex}";
            }

            string lameRC = $"-b {ActiveBitrateMP3}";
            if (cobRateControl.SelectedIndex == 2)
            {
                lameRC = $"-V {10 - cobTVBR.SelectedIndex}";
            } else if (cobRateControl.SelectedIndex == 3)
            {
                lameRC = $"--abr {ActiveBitrateMP3}";
            }

            string encToolsName;
            string encSupportFormat;
            string encSupportDepth;
            string encExtension;
            Func<string, string, string> buildParamsFunc;

            switch ((AudioEncoder)cobEncoder.SelectedIndex)
            {
                case AudioEncoder.Qaac: // qaac lc
                    encToolsName = tools.qaac;
                    encSupportFormat = "pcm_s24le";
                    encSupportDepth = "s32";
                    encExtension = ".m4a";
                    buildParamsFunc = (inWav, outTemp) => $"{qaacRC} -q 2 -r {ActiveSR} --no-delay --threading -o {tools.Quote(outTemp)} -R --raw-channels 2 --raw-rate {ActiveSR} --raw-format S24L {tools.Quote(inWav)}";
                    break;

                case AudioEncoder.FdkAac: // fdk lc
                    encToolsName = tools.fdkaac;
                    encSupportFormat = "pcm_s24le";
                    encSupportDepth = "s32";
                    encExtension = ".m4a";
                    buildParamsFunc = (inWav, outTemp) => $"{fdkRC} -w {ActiveCutoff} -G 1 {tools.Quote(inWav)} -o {tools.Quote(outTemp)}";
                    break;

                case AudioEncoder.VacEnc: // vac-enc
                    encToolsName = tools.vac;
                    encSupportFormat = "pcm_f32le";
                    encSupportDepth = "flt";
                    encExtension = ".ogg";
                    ActiveSR = 48000;
                    buildParamsFunc = (inWav, outTemp) => $"-b {ActiveBitrate} {tools.Quote(inWav)} {tools.Quote(outTemp)}";
                    break;

                case AudioEncoder.OggEnc: // oggenc
                    encToolsName = tools.oggenc;
                    encSupportFormat = "pcm_s16le";
                    encSupportDepth = "s16";
                    encExtension = ".ogg";
                    buildParamsFunc = (inWav, outTemp) => $"-r -B 16 -C 2 -R {ActiveSR} {oggRC} --ignorelength {tools.Quote(inWav)} -o {tools.Quote(outTemp)}";
                    break;

                case AudioEncoder.FhgMp3: // fhg mp3
                    encToolsName = tools.MP3ENC301;
                    encSupportFormat = "pcm_s16le";
                    encSupportDepth = "s16";
                    encExtension = ".mp3";
                    buildParamsFunc = (inWav, outTemp) => $"-if {tools.Quote(inWav)} -of {tools.Quote(outTemp)} -iss 16 -sr {ActiveSR} -nc 2 -br {ActiveBitrateMP3 * 1000} -esr {ActiveSR} -qual 9 -crc";
                    break;

                case AudioEncoder.LameMp3: // lame mp3
                    encToolsName = tools.lame;
                    encSupportFormat = "pcm_s24le";
                    encSupportDepth = "s32";
                    encExtension = ".mp3";
                    buildParamsFunc = (inWav, outTemp) => $"-r -s {ActiveSR_khz} --bitwidth 24 -q 2 {lameRC} -p --strictly-enforce-ISO {tools.Quote(inWav)} {tools.Quote(outTemp)}";
                    break;

                default:
                    MessageBox.Show("Unable to launch selected encoder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            await EncodeMT(
                outFolder,
                ActiveSR,
                ActiveCutoff,
                encToolsName,
                encSupportFormat,
                encSupportDepth,
                encExtension,
                buildParamsFunc,
                ActiveThreadCount
            );
        }

        private async Task EncodeMT(
            string outFolder,
            int activeSR,
            int activeCutoff,
            string encToolsName,
            string encSupportFormat,
            string encSupportDepth,
            string encExtension,
            Func<string, string, string> buildParamsFunc,
            int maxThreads
            )
        {
            int totalFiles = sourceFilePaths.Count;
            int successCount = 0;
            int processedCount = 0;

            ProgressForm progressDialog = new ProgressForm(totalFiles);
            progressDialog.Show(this);

            this.Enabled = false;

            try
            {
                using (SemaphoreSlim semaphore = new SemaphoreSlim(maxThreads))
                {
                    var tasks = sourceFilePaths.Select(async inputFile =>
                    {
                        await semaphore.WaitAsync();
                        try
                        {
                            bool success = await Task.Run(() => EncodeST(
                                inputFile,
                                outFolder,
                                activeSR,
                                activeCutoff,
                                encToolsName,
                                encSupportFormat,
                                encSupportDepth,
                                encExtension,
                                buildParamsFunc
                                ));

                            if (success)
                            {
                                Interlocked.Increment(ref successCount);
                            }

                            int currentProcessed = Interlocked.Increment(ref processedCount);
                            string currentFileName = Path.GetFileName(inputFile);

                            if (!progressDialog.IsDisposed && progressDialog.IsHandleCreated)
                            {
                                progressDialog.Invoke((MethodInvoker)delegate
                                {
                                    progressDialog.UpdateProgress(currentProcessed, totalFiles, currentFileName);
                                });
                            }
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    });

                    await Task.WhenAll(tasks);
                }
            }
            finally
            {
                this.Enabled = true;
                if (!progressDialog.IsDisposed)
                {
                    progressDialog.Close();
                }
            }

            MessageBox.Show($"Successfully processed {successCount} of {totalFiles} files.", "Nice", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool EncodeST(
            string inputFile,
            string outFolder,
            int activeSR,
            int activeCutoff,
            string encToolsName,
            string encSupportFormat,
            string encSupportDepth,
            string encExtension,
            Func<string, string, string> buildParamsFunc
            )
        {
            string tempWavPath = null;
            string tempOutputFilePath = null;

            try
            {
                tempWavPath = converter.ConvToTempWav(inputFile, activeSR, encSupportDepth, encSupportFormat, activeCutoff);

                string targetFolder = cbSameDirAsInput.Checked
                    ? Path.GetDirectoryName(inputFile)
                    : outFolder;

                string inputFileNoExtension = Path.GetFileNameWithoutExtension(inputFile);
                string finalOutputFilePath = Path.Combine(targetFolder, inputFileNoExtension + encExtension);

                string tempOutputFileName = $"temp_out_{Guid.NewGuid():N}{encExtension}";
                tempOutputFilePath = Path.Combine(targetFolder, tempOutputFileName);

                string encParams = buildParamsFunc(tempWavPath, tempOutputFilePath);

                ProcessStartInfo encProcessInfo = new ProcessStartInfo
                {
                    FileName = encToolsName,
                    Arguments = encParams,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process encProcess = Process.Start(encProcessInfo))
                {
                    if (encProcess == null)
                    {
                        return false;
                    }

                    encProcess.WaitForExit();

                    if (encProcess.ExitCode == 0 && File.Exists(tempOutputFilePath))
                    {
                        if (File.Exists(finalOutputFilePath))
                        {
                            File.Delete(finalOutputFilePath);
                        }

                        if (cbKeepMeta.Checked)
                        {
                            bool tagSuccess = tools.MuxMeta(inputFile, tempOutputFilePath, finalOutputFilePath);

                            if (tagSuccess)
                            {
                                if (File.Exists(tempOutputFilePath))
                                {
                                    File.Delete(tempOutputFilePath);
                                }
                            }
                            else
                            {
                                File.Move(tempOutputFilePath, finalOutputFilePath);
                            }
                        }
                        else
                        {
                            File.Move(tempOutputFilePath, finalOutputFilePath);
                        }

                        return true;
                    }
                }

                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (tempWavPath != null)
                {
                    tools.CleanupTempFile(inputFile, tempWavPath);
                }

                if (tempOutputFilePath != null && File.Exists(tempOutputFilePath))
                {
                    try { File.Delete(tempOutputFilePath); } catch { }
                }
            }
        }

        private void UpdateRateControlUI()
        {
            cobTVBR.BeginUpdate();
            cobTVBR.Items.Clear();

            bool isTvbrMode = (cobRateControl.SelectedIndex == 2);
            AudioEncoder currentEncoder = (AudioEncoder)cobEncoder.SelectedIndex;

            switch (currentEncoder)
            {
                case AudioEncoder.Qaac: // qaac lc
                    if (isTvbrMode)
                    {
                        txtCustomBitrate.Enabled = false;
                        cobBitrate.Enabled = false;

                        cobTVBR.Enabled = true;
                        cobTVBR.Items.AddRange(new object[]
                        {
                        "0", "9", "18", "27", "36", "45", "54", "64",
                        "73", "82", "91", "100", "109", "118", "127"
                        });
                        cobTVBR.SelectedIndex = 14;
                    } else
                    {
                        cobTVBR.Enabled = false;
                        txtCustomBitrate.Enabled = true;
                        cobBitrate.Enabled = true;
                    }
                    break;

                case AudioEncoder.FdkAac: // fdk lc
                    if (isTvbrMode)
                    {
                        txtCustomBitrate.Enabled = false;
                        cobBitrate.Enabled = false;

                        cobTVBR.Enabled = true;
                        cobTVBR.Items.AddRange(new object[]
                        {
                        "Quality 1", "Quality 2", "Quality 3",
                        "Quality 4", "Quality 5"
                        });
                        cobTVBR.SelectedIndex = 4;
                    }
                    else
                    {
                        cobTVBR.Enabled = false;
                        txtCustomBitrate.Enabled = true;
                        cobBitrate.Enabled = true;
                    }
                    break;

                case AudioEncoder.VacEnc: // vac-enc
                    cobTVBR.Enabled = false;
                    txtCustomBitrate.Enabled = true;
                    cobBitrate.Enabled = true;
                    break;

                case AudioEncoder.OggEnc: // oggenc
                    if (isTvbrMode)
                    {
                        txtCustomBitrate.Enabled = false;
                        cobBitrate.Enabled = false;

                        cobTVBR.Enabled = true;
                        cobTVBR.Items.AddRange(new object[]
                        {
                        "Quality 1", "Quality 2", "Quality 3",
                        "Quality 4", "Quality 5", "Quality 6",
                        "Quality 7", "Quality 8", "Quality 9",
                        "Quality 10", "Quality 11"
                        });
                        cobTVBR.SelectedIndex = 10;
                    }
                    else
                    {
                        cobTVBR.Enabled = false;
                        txtCustomBitrate.Enabled = true;
                        cobBitrate.Enabled = true;
                    }
                    break;

                case AudioEncoder.FhgMp3: // fhg mp3
                    cobTVBR.Enabled = false;
                    txtCustomBitrate.Enabled = true;
                    cobBitrate.Enabled = true;
                    break;

                case AudioEncoder.LameMp3: // lame mp3
                    if (isTvbrMode)
                    {
                        txtCustomBitrate.Enabled = false;
                        cobBitrate.Enabled = false;

                        cobTVBR.Enabled = true;
                        cobTVBR.Items.AddRange(new object[]
                        {
                        "Quality 1", "Quality 2", "Quality 3",
                        "Quality 4", "Quality 5", "Quality 6",
                        "Quality 7", "Quality 8", "Quality 9",
                        "Quality 10", "Quality 11"
                        });
                        cobTVBR.SelectedIndex = 10;
                    }
                    else
                    {
                        cobTVBR.Enabled = false;
                        txtCustomBitrate.Enabled = true;
                        cobBitrate.Enabled = true;
                    }
                    break;

                default:
                    cobTVBR.Enabled = false;
                    txtCustomBitrate.Enabled = true;
                    cobBitrate.Enabled = true;
                    break;
            }

            cobTVBR.EndUpdate();
        }

        private void cobEncoder_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRateControlUI();
        }

        private void cobRateControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRateControlUI();
        }
    }
}
