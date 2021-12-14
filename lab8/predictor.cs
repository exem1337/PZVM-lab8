using System;
using System.Collections.Generic;

namespace lab8
{
    class predictor
    {
        double _t, _T, _u, _tao;
        public predictor(double t0, double T, double u0, double tao)
        {
            this._T = T;
            this._t = t0;
            this._u = u0;
            this._tao = tao;
        }
        public List<double> uResults = new List<double>();
        public void doPredictor()
        {
            int n = Convert.ToInt32((_T - _t) / _tao);
            string precision = "";
            uResults.Add(_u);
            precision += (_u - accurateFunction(_t)).ToString() + "\n";
            for (int i = 0; i < n - 1; i++)
            {
                _u = _u + _tao * mainFunc((_t + 0.5 * _tao), (_u + 0.5 * _tao * mainFunc(_t, _u)));
                precision += (_u - accurateFunction(_t)).ToString() + "\n";
                _t = _t + _tao;
                uResults.Add(_u);
            }
            string sPath = $"precPredictor({_tao}).txt";
            System.IO.StreamWriter SaveFile3 = new System.IO.StreamWriter(sPath);
            SaveFile3.Write(precision);
            SaveFile3.ToString();
            SaveFile3.Close();
        }

        private double mainFunc(double t, double u) => -2 * u - 3 * t + 2;
        private double accurateFunction(double t) => 1.75 - 1.5 * t - 1.75 * Math.Exp(-2 * t);

    }
}
