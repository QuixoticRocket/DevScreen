using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevScreen
{
    public partial class ImportantDisplayForm : Form
    {
        private bool run;
        private ITextGetter textGetter;

        public ImportantDisplayForm(ITextGetter textGetter)
        {
            InitializeComponent();

            this.textGetter = textGetter;
            run = true;

            Thread newthread = new Thread(new ThreadStart(Go));
            newthread.Start();
        }

        public void UpdateTextbox(TextBox box, string input)
        {
            if (!box.IsDisposed)
            {
                box.Invoke(new MethodInvoker(() => box.AppendText(input)));
            }
        }

        public void UpdateProgressbar(ProgressBar bar, int amount)
        {

            if (!bar.IsDisposed && bar.Value >= bar.Maximum)
            {
                bar.Invoke(new MethodInvoker(() => bar.Value = 0));
            }
            if (!bar.IsDisposed)
            {
                bar.Invoke(new MethodInvoker(() => bar.Increment(amount)));
            }
        }

        public void Go()
        {
            while (run)
            {
                UpdateProgressbar(bottomProgressBar, 10);
                UpdateTextbox(mainOutputTextbox, textGetter.GetText() + Environment.NewLine);

                if (!this.IsDisposed)
                {
                    this.Invoke(new MethodInvoker(delegate { this.Update(); }));
                    Thread.Sleep(500);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            run = false;
            Thread.Sleep(500);
        }
    }
}
