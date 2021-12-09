using System;
using System.Collections.Generic;
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
            List<string> tempResults = new List<string>();
            Ailer a = new Ailer(t0, T, u0, Convert.ToDouble(comboBox1.SelectedItem.ToString()));
            a.doAiler();
            List<double> AilerResults = a.uResults;
            foreach (double res in AilerResults) {
                listBox1.Items.Add(res);
            }
            //File.WriteAllText($"ailer{comboBox1.SelectedItem.ToString()}.txt", tempResults.ToString());

            string sPath = $"ailer{comboBox1.SelectedItem.ToString()}.txt";

            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);
            foreach (var item in listBox1.Items)
            {
                SaveFile.WriteLine(item);
            }
            SaveFile.ToString();
            SaveFile.Close();

            predictor pred = new predictor(t0, T, u0, Convert.ToDouble(comboBox1.SelectedItem.ToString()));
            pred.doPredictor();
            List<double> predResults = pred.uResults;
            foreach (double res in predResults) listBox2.Items.Add(res);

            sPath = $"predictor{comboBox1.SelectedItem.ToString()}.txt";

            System.IO.StreamWriter SaveFile1 = new System.IO.StreamWriter(sPath);
            foreach (var item in listBox2.Items)
            {
                SaveFile1.WriteLine(item);
            }
            SaveFile1.ToString();
            SaveFile1.Close();

            Runge run = new Runge(t0, T, u0, Convert.ToDouble(comboBox1.SelectedItem.ToString()));
            run.doRunge();
            List<double> runResults = run.uResults;
            foreach (double res in runResults) listBox3.Items.Add(res);

            sPath = $"runge{comboBox1.SelectedItem.ToString()}.txt";

            System.IO.StreamWriter SaveFile2 = new System.IO.StreamWriter(sPath);
            foreach (var item in listBox3.Items)
            {
                SaveFile2.WriteLine(item);
            }
            SaveFile2.ToString();
            SaveFile2.Close();

            RungeKutt4 rk = new RungeKutt4(t0, T, u0, Convert.ToDouble(comboBox1.SelectedItem.ToString()));
            rk.doRunge();
            List<double> rkResults = rk.uResults;
            foreach (double res in rkResults) listBox4.Items.Add(res);

            sPath = $"rungeKutt4{comboBox1.SelectedItem.ToString()}.txt";

            System.IO.StreamWriter SaveFile3 = new System.IO.StreamWriter(sPath);
            foreach (var item in listBox4.Items)
            {
                SaveFile3.WriteLine(item);
            }
            SaveFile3.ToString();
            SaveFile3.Close();
        }
    }
}
