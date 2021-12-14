using System;
using System.Collections.Generic;

namespace lab8
{
    class RungeKutt4
    {
        double _t, _T, _u, _tao;
        public RungeKutt4(double t0, double T, double u0, double tao)
        {
            this._T = T;
            this._t = t0;
            this._u = u0;
            this._tao = tao;
        }
        public List<double> uResults = new List<double>();
        public void doRunge()
        {
            int n = Convert.ToInt32((_T - _t) / _tao);
            string precision = "";
            uResults.Add(_u);
            precision += (_u - accurateFunction(_t)).ToString() + "\n";
            for (int i = 0; i < n - 1; i++)
            {
                double k1 = mainFunc(_t, _u);
                double k2 = mainFunc(_t + _tao / 2, _u + _tao / 2 * k1);
                double k3 = mainFunc(_t + _tao / 2, _u + _tao / 2 * k2);
                double k4 = mainFunc(_t + _tao, _u + _tao * k3);

                _u = _u + _tao / 6 * (k1 + 2 * k2 + 2 * k3 + k4);
                uResults.Add(_u);
                precision += (_u - accurateFunction(_t)).ToString() + "\n";
                _t = _t + _tao;

            }
            string sPath = $"precRungeKutt({_tao}).txt";
            System.IO.StreamWriter SaveFile3 = new System.IO.StreamWriter(sPath);
            SaveFile3.Write(precision);
            SaveFile3.ToString();
            SaveFile3.Close();
        }

        private double mainFunc(double t, double u) => -2 * u - 3 * t + 2;
        private double accurateFunction(double t) => 1.75 - 1.5 * t - 1.75 * Math.Exp(-2 * t);

    }
}
