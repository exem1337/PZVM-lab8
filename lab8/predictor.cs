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

            uResults.Add(_u);
            for (int i = 0; i < n - 1; i++)
            {
                _u = _u + _tao * mainFunc((_t + 0.5 * _tao), (_u + 0.5 * _tao * mainFunc(_t, _u)));
                _t = _t + _tao;
                uResults.Add(_u);
            }
        }

        private double mainFunc(double t, double u) => Convert.ToDouble(Math.Exp(3 * t) + 3 * (u - 1));
        private double accurateFunction(double t) => Convert.ToDouble(t * Math.Exp(3 * t) + 1);

    }
}
