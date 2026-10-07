using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lynxAudioEnc
{
    public partial class ProgressForm : Form
    {
        public ProgressForm(int totalFiles)
        {
            InitializeComponent();

            pbProgress.Minimum = 0;
            pbProgress.Maximum = totalFiles;
            pbProgress.Value = 0;
            lblEncodeStatus.Text = $"Encoding File 0 of {totalFiles}:";
        }

        public void UpdateProgress(
            int completedCount,
            int totalFiles,
            string currentFileName
            )
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateProgress(
                    completedCount,
                    totalFiles,
                    currentFileName
                    )));
                return;
            }

            pbProgress.Value = completedCount;

            if (completedCount < totalFiles)
            {
                lblEncodeStatus.Text = $"Encoding File {completedCount + 1} of {totalFiles}: {currentFileName}";
            }
            else
            {
                lblEncodeStatus.Text = "Completed.";
            }
        }
    }
}
