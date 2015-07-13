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
    public partial class Form1 : Form
    {
        private bool run;
        private ITextGetter textGetter;

        public Form1(ITextGetter textGetter)
        {
            InitializeComponent();

            this.textGetter = textGetter;
            run = true;

            Thread newthread = new Thread(new ThreadStart(Go));
            newthread.Start();
        }

        public void UpdateTextbox(string input)
        {
            if (!textBox1.IsDisposed)
            {
                textBox1.Invoke(new MethodInvoker(delegate { textBox1.AppendText(input); }));
            }
        }

        public void UpdateProgressbar(int amount)
        {

            if (!progressBar1.IsDisposed && progressBar1.Value >= progressBar1.Maximum)
            {
                progressBar1.Invoke(new MethodInvoker(delegate { progressBar1.Value = 0; }));
            }
            if (!progressBar1.IsDisposed)
            {
                progressBar1.Invoke(new MethodInvoker(delegate { progressBar1.Increment(amount); }));
            }
        }

        public void Go()
        {
            while (run)
            {
                UpdateProgressbar(10);
                UpdateTextbox(textGetter.GetText() + Environment.NewLine);

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
        }
    }
}
