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
        private Random random;
        private Thread mainlineThread;

        
        public delegate void ProgressBarCompleteDelegate(ProgressBar bar);

        /// <summary>
        /// Fires when the progressbar completes
        /// </summary>
        public event ProgressBarCompleteDelegate ProgressbarComplete;

        public ImportantDisplayForm(ITextGetter textGetter)
        {
            InitializeComponent();

            ProgressbarComplete += On_ProgressBarComplete;

            random = new Random(DateTime.Now.Millisecond + DateTime.Now.Second);

            this.textGetter = textGetter;
            run = true;

            mainlineThread = new Thread(new ThreadStart(RunUpdateLoop));
            mainlineThread.Start();
        }

        /// <summary>
        /// Thread Safe method for appending text to a textbox
        /// </summary>
        /// <param name="box">The textbox to invoke</param>
        /// <param name="input">The text to append</param>
        public void UpdateTextbox(TextBox box, string input)
        {
            if (!box.IsDisposed)
            {
                box.Invoke(new MethodInvoker(() => box.AppendText(input)));
            }
        }

        /// <summary>
        /// Thread Safe method for incrementing the progress bar by an amount
        /// </summary>
        /// <param name="bar">The progressbar to invoke</param>
        /// <param name="amount">the amount to increment by</param>
        public void UpdateProgressbar(ProgressBar bar, int amount)
        {

            if (!bar.IsDisposed && bar.Value >= bar.Maximum)
            {
                if(ProgressbarComplete != null)
                {
                    ProgressbarComplete(bar);
                }
            }
            if (!bar.IsDisposed)
            {
                bar.Invoke(new MethodInvoker(() => bar.Increment(amount)));
            }
        }

        /// <summary>
        /// Handles the ProgressBarComplete Event
        /// </summary>
        /// <param name="bar">the completed bar</param>
        private void On_ProgressBarComplete(ProgressBar bar)
        {
            //reset to zero
            bar.Invoke(new MethodInvoker(() => bar.Value = 0));
            UpdateTextbox(mainOutputTextbox, textGetter.GetText() + Environment.NewLine);
        }

        /// <summary>
        /// Kicks off the main loop. adds the first line of tects and starts updating the progress bar randomly with random sleeps
        /// </summary>
        public void RunUpdateLoop()
        {
            UpdateTextbox(mainOutputTextbox, textGetter.GetText() + Environment.NewLine);
            while (run)
            {
                UpdateProgressbar(bottomProgressBar, random.Next(1,20));

                if (!this.IsDisposed)
                {
                    this.Invoke(new MethodInvoker(delegate { this.Update(); }));
                    Thread.Sleep(random.Next(100,800));
                }
            }
        }

        /// <summary>
        /// Sets run to false and aborts the main thread.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            run = false;
            if (mainlineThread != null && mainlineThread.IsAlive)
            {
                mainlineThread.Abort();
            }
        }
    }
}
