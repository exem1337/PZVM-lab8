using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double t0 = 0, T = 1, u0 = 1;

        private void button1_Click(object sender, EventArgs e)
        {
            Ailer a = new Ailer(t0, T, u0, Convert.ToDouble(comboBox1.SelectedItem.ToString()));
            a.doAiler();
            List<double> AilerResults = a.uResults;
            foreach (double res in AilerResults) listBox1.Items.Add(res);

            predictor pred = new predictor(t0, T, u0, Convert.ToDouble(comboBox1.SelectedItem.ToString()));
            pred.doPredictor();
            List<double> predResults = pred.uResults;
            foreach (double res in predResults) listBox2.Items.Add(res);

            Runge run = new Runge(t0, T, u0, Convert.ToDouble(comboBox1.SelectedItem.ToString()));
            run.doRunge();
            List<double> runResults = run.uResults;
            foreach (double res in runResults) listBox3.Items.Add(res);

            RungeKutt4 rk = new RungeKutt4(t0, T, u0, Convert.ToDouble(comboBox1.SelectedItem.ToString()));
            rk.doRunge();
            List<double> rkResults = rk.uResults;
            foreach (double res in rkResults) listBox4.Items.Add(res);
        }
    }
}
