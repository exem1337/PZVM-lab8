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

            Ailer a1 = new Ailer(t0, T, u0, Convert.ToDouble(comboBox1.Items[1].ToString()));
            a1.doAiler();
            List<double> a1Results = a1.uResults;

            Ailer a2 = new Ailer(t0, T, u0, Convert.ToDouble(comboBox1.SelectedItem.ToString()) / 3);
            a2.doAiler();
            List<double> a2Results = a2.uResults;

            //string a1Res = "";
            //for (int i = 0; i < a1Results.Count; i++)
            //{
            //    a1Res += a1Results[i].ToString() + "\n";
            //}

            //string aPath = $"shit({Convert.ToDouble(comboBox1.SelectedItem.ToString())}).txt";
            //System.IO.StreamWriter SaveFileaa = new System.IO.StreamWriter(aPath);
            //SaveFileaa.Write(a1Res);
            //SaveFileaa.ToString();
            //SaveFileaa.Close();

            string a1diff = ""; string a2diff = "";
            int o = 0;
            for (int i = 0; i < AilerResults.Count; i++)
            {
                a1diff += (a1Results[i + o] - AilerResults[i]).ToString() + "\n";
                o++;
            }
            o = 0;
            Console.WriteLine(a2Results.Count);
            for (int i = 0; i < a1Results.Count; i++)
            {
                a2diff += (a2Results[i + o] - a1Results[i]).ToString() + "\n"; //КАКОГО ХУЯ
                o++;
            }

            string Path = $"difference1Ailer.txt";
            System.IO.StreamWriter SaveFilea = new System.IO.StreamWriter(Path);
            SaveFilea.Write(a1diff);
            SaveFilea.ToString();
            SaveFilea.Close();

            Path = $"difference2Ailer.txt";
            System.IO.StreamWriter SaveFileb = new System.IO.StreamWriter(Path);
            SaveFileb.Write(a2diff);
            SaveFileb.ToString();
            SaveFileb.Close();

            foreach (double res in AilerResults) {
                listBox1.Items.Add(res);
            }

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

            predictor pred1 = new predictor(t0, T, u0, Convert.ToDouble(comboBox1.Items[1].ToString()));
            pred1.doPredictor();
            List<double> pred1Results = pred1.uResults;

            predictor pred2 = new predictor(t0, T, u0, Convert.ToDouble(comboBox1.SelectedItem.ToString()) / 3);
            pred2.doPredictor();
            List<double> pred2Results = pred2.uResults;
            string pred1diff = ""; string pred2diff = "";
            o = 0;
            for (int i = 0; i < predResults.Count; i++)
            {
                pred1diff += (pred1Results[i + o] - predResults[i]).ToString() + "\n";
                o++;
            }
            o = 0;
            for (int i = 0; i < pred1Results.Count; i++)
            {
                pred2diff += (pred2Results[i + o] - pred1Results[i]).ToString() + "\n";
                o += 2;
            }

            Path = $"difference1Predictor.txt";
            System.IO.StreamWriter SaveFilevv = new System.IO.StreamWriter(Path);
            SaveFilevv.Write(pred1diff);
            SaveFilevv.ToString();
            SaveFilevv.Close();

            Path = $"difference2Predictor.txt";
            System.IO.StreamWriter SaveFileaaa = new System.IO.StreamWriter(Path);
            SaveFileaaa.Write(pred2diff);
            SaveFileaaa.ToString();
            SaveFileaaa.Close();

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

            Runge run1 = new Runge(t0, T, u0, Convert.ToDouble(comboBox1.Items[1].ToString()));
            run1.doRunge();
            List<double> run1Results = run1.uResults;

            Runge run2 = new Runge(t0, T, u0, Convert.ToDouble(comboBox1.SelectedItem.ToString()) / 3);
            run2.doRunge();
            List<double> run2Results = run2.uResults;
            string run1diff = ""; string run2diff = "";
            o = 0;
            for (int i = 0; i < runResults.Count; i++)
            {
                run1diff += (run1Results[i + o] - runResults[i]).ToString() + "\n";
                o++;
            }
            o = 0;
            for (int i = 0; i < run1Results.Count; i++)
            {
                run2diff += (run2Results[i + o] - run1Results[i]).ToString() + "\n";
                o += 2;
            }

            Path = $"difference1Runge.txt";
            System.IO.StreamWriter SaveFilevb = new System.IO.StreamWriter(Path);
            SaveFilevb.Write(run1diff);
            SaveFilevb.ToString();
            SaveFilevb.Close();

            Path = $"difference2Runge.txt";
            System.IO.StreamWriter SaveFileav = new System.IO.StreamWriter(Path);
            SaveFileav.Write(run2diff);
            SaveFileav.ToString();
            SaveFileav.Close();

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

            RungeKutt4 rk1 = new RungeKutt4(t0, T, u0, Convert.ToDouble(comboBox1.Items[1].ToString()));
            run1.doRunge();
            List<double> rk1Results = rk1.uResults;

            RungeKutt4 rk2 = new RungeKutt4(t0, T, u0, Convert.ToDouble(comboBox1.SelectedItem.ToString()) / 3);
            run2.doRunge();
            List<double> rk2Results = rk2.uResults;
            string rk1diff = ""; string rk2diff = "";
            o = 0;
            for (int i = 0; i < rkResults.Count; i++)
            {
                rk1diff += (rk1Results[i + o] - rkResults[i]).ToString() + "\n";
                o++;
            }
            o = 0;
            for (int i = 0; i < rk1Results.Count; i++)
            {
                rk2diff += (rk2Results[i + o] - rk1Results[i]).ToString() + "\n";
                o += 2;
            }

            Path = $"difference1RungeKutt.txt";
            System.IO.StreamWriter SaveFilevf = new System.IO.StreamWriter(Path);
            SaveFilevf.Write(rk1diff);
            SaveFilevf.ToString();
            SaveFilevf.Close();

            Path = $"difference2RungeKutt.txt";
            System.IO.StreamWriter SaveFileavawd = new System.IO.StreamWriter(Path);
            SaveFileavawd.Write(rk2diff);
            SaveFileavawd.ToString();
            SaveFileavawd.Close();


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
