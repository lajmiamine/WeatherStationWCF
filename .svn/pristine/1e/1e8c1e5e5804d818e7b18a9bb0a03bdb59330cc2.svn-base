using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherStation.Models
{
    public class Operations
    {
        public Double StrToDouble(string sVal, char Separator)
        {
            string[] sDouble;
            Double Val;

            sDouble = sVal.Split(new char[1] { Separator });
            long Precision = 1;

            #region
            if (Convert.ToInt64(sDouble[1]) > 100000000000000)
            {
                Precision = 1000000000000000;
            }
            else if (Convert.ToInt64(sDouble[1]) > 100000000000000)
            {
                Precision = 1000000000000000;
            }
            else if (Convert.ToInt64(sDouble[1]) > 10000000000000)
            {
                Precision = 100000000000000;
            }
            else if (Convert.ToInt64(sDouble[1]) > 1000000000000)
            {
                Precision = 10000000000000;
            }
            else if (Convert.ToInt64(sDouble[1]) > 100000000000)
            {
                Precision = 1000000000000;
            }
            else if (Convert.ToInt64(sDouble[1]) > 10000000000)
            {
                Precision = 100000000000;
            }
            else if (Convert.ToInt64(sDouble[1]) > 1000000000)
            {
                Precision = 10000000000;
            }
            else if (Convert.ToInt64(sDouble[1]) > 100000000)
            {
                Precision = 1000000000;
            }
            else if (Convert.ToInt64(sDouble[1]) > 10000000)
            {
                Precision = 100000000;
            }
            else if (Convert.ToInt64(sDouble[1]) > 10000000)
            {
                Precision = 100000000;
            }
            else if (Convert.ToInt64(sDouble[1]) > 1000000)
            {
                Precision = 10000000;
            }
            else if (Convert.ToInt64(sDouble[1]) > 100000)
            {
                Precision = 1000000;
            }
            else if (Convert.ToInt64(sDouble[1]) > 10000)
            {
                Precision = 100000;
            }
            else if (Convert.ToInt64(sDouble[1]) > 1000)
            {
                Precision = 10000;
            }
            else if (Convert.ToInt64(sDouble[1]) > 100)
            {
                Precision = 1000;
            }
            else if (Convert.ToInt64(sDouble[1]) > 10)
            {
                Precision = 100;
            }
            else if (Convert.ToInt64(sDouble[1]) > 1)
            {
                Precision = 10;
            }
            #endregion

            Val = Convert.ToInt64(sDouble[0]) * Precision + Convert.ToInt64(sDouble[1]);
            return Val / Precision;
        }
    }
}