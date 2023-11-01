using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompApp.Classes
{
    public class ArrayCAE
    {
        public double ArrayGet(int n1, int n2)
        {
            double[,] KVSopt = new double[84, 84];
            // ВОЗРАСТ 16 - 21, СТАЖ 0 - 6
            for (int i = 0; i <= 5; i++)
            {
                for (int j = 0; j <= 6; j++)
                {
                    KVSopt[i, j] = 2.27;
                    if (j == 1)
                    {
                        KVSopt[i, j] = 1.92;
                    }
                    else if (j == 2)
                    {
                        KVSopt[i, j] = 1.84;
                    }
                    else if (j == 3 || j == 4)
                    {
                        KVSopt[i, j] = 1.65;
                    }
                    else if (j == 5 || j == 6)
                    {
                        KVSopt[i, j] = 1.62;
                    }
                }
            }
            // ВОЗРАСТ 22 - 24, СТАЖ 0 - 9
            for (int i = 22 - 16; i <= 24 - 16; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    KVSopt[i, j] = 1.88;
                    if (j == 1)
                    {
                        KVSopt[i, j] = 1.72;
                    }
                    else if (j == 2)
                    {
                        KVSopt[i, j] = 1.71;
                    }
                    else if (j == 3 || j == 4)
                    {
                        KVSopt[i, j] = 1.13;
                    }
                    else if (j == 5 || j == 6)
                    {
                        KVSopt[i, j] = 1.10;
                    }
                    else if (j == 7 || j == 8 || j == 9)
                    {
                        KVSopt[i, j] = 1.09;
                    }
                }
            }
            // ВОЗРАСТ 25 - 29, СТАЖ 0 - 14
            for (int i = 25 - 16; i <= 29 - 16; i++)
            {
                for (int j = 0; j <= 13; j++)
                {
                    KVSopt[i, j] = 1.72;
                    if (j == 1)
                    {
                        KVSopt[i, j] = 1.6;
                    }
                    else if (j == 2)
                    {
                        KVSopt[i, j] = 1.54;
                    }
                    else if (j == 3 || j == 4)
                    {
                        KVSopt[i, j] = 1.09;
                    }
                    else if (j == 5 || j == 6)
                    {
                        KVSopt[i, j] = 1.08;
                    }
                    else if (j == 7 || j == 8 || j == 9)
                    {
                        KVSopt[i, j] = 1.07;
                    }
                    else if (j <= i)
                    {
                        KVSopt[i, j] = 1.02;
                    }
                }
            }
            // ВОЗРАСТ 30 - 34, СТАЖ 0 - 14+
            for (int i = 30 - 16; i <= 34 - 16; i++)
            {
                for (int j = 0; j <= 18; j++)
                {
                    KVSopt[i, j] = 1.56;
                    if (j == 1)
                    {
                        KVSopt[i, j] = 1.5;
                    }
                    if (j == 2)
                    {
                        KVSopt[i, j] = 1.48;
                    }
                    else if (j == 3 || j == 4)
                    {
                        KVSopt[i, j] = 1.05;
                    }
                    else if (j == 5 || j == 6)
                    {
                        KVSopt[i, j] = 1.04;
                    }
                    else if (j == 7 || j == 8 || j == 9)
                    {
                        KVSopt[i, j] = 1.01;
                    }
                    else if (j == 10 || j == 11 || j == 12 || j == 13 || j == 14)
                    {
                        KVSopt[i, j] = 0.97;
                    }
                    else if (j <= i)
                    {
                        KVSopt[i, j] = 0.95;
                    }
                }
            }
            // ВОЗРАСТ 35 - 39, СТАЖ 0 - 14+
            for (int i = 35 - 16; i <= 39 - 16; i++)
            {
                for (int j = 0; j <= 23; j++)
                {
                    KVSopt[i, j] = 1.54;
                    if (j == 1)
                    {
                        KVSopt[i, j] = 1.47;
                    }
                    else if (j == 2)
                    {
                        KVSopt[i, j] = 1.46;
                    }
                    else if (j == 3 || j == 4)
                    {
                        KVSopt[i, j] = 1;
                    }
                    else if (j == 5 || j == 6)
                    {
                        KVSopt[i, j] = 0.97;
                    }
                    else if (j == 7 || j == 8 || j == 9)
                    {
                        KVSopt[i, j] = 0.95;
                    }
                    else if (j == 10 || j == 11 || j == 12 || j == 13 || j == 14)
                    {
                        KVSopt[i, j] = 0.94;
                    }
                    else if (j <= i)
                    {
                        KVSopt[i, j] = 0.93;
                    }
                }
            }
            // ВОЗРАСТ 40 - 49, СТАЖ 0 - 14+
            for (int i = 40 - 16; i <= 49 - 16; i++)
            {
                for (int j = 0; j <= 33; j++)
                {
                    KVSopt[i, j] = 1.5;
                    if (j == 1)
                    {
                        KVSopt[i, j] = 1.44;
                    }
                    else if (j == 2)
                    {
                        KVSopt[i, j] = 1.43;
                    }
                    else if (j == 3 || j == 4)
                    {
                        KVSopt[i, j] = 0.96;
                    }
                    else if (j == 5 || j == 6)
                    {
                        KVSopt[i, j] = 0.95;
                    }
                    else if (j == 7 || j == 8 || j == 9)
                    {
                        KVSopt[i, j] = 0.94;
                    }
                    else if (j == 10 || j == 11 || j == 12 || j == 13 || j == 14)
                    {
                        KVSopt[i, j] = 0.93;
                    }
                    else if (j <= i)
                    {
                        KVSopt[i, j] = 0.91;
                    }
                }
            }
            // ВОЗРАСТ 50 - 59, СТАЖ 0 - 14+
            for (int i = 50 - 16; i <= 59 - 16; i++)
            {
                for (int j = 0; j <= 43; j++)
                {
                    KVSopt[i, j] = 1.46;
                    if (j == 1)
                    {
                        KVSopt[i, j] = 1.4;
                    }
                    else if (j == 2)
                    {
                        KVSopt[i, j] = 1.39;
                    }
                    else if (j == 3 || j == 4)
                    {
                        KVSopt[i, j] = 0.93;
                    }
                    else if (j == 5 || j == 6)
                    {
                        KVSopt[i, j] = 0.92;
                    }
                    else if (j == 7 || j == 8 || j == 9)
                    {
                        KVSopt[i, j] = 0.91;
                    }
                    else if (j == 10 || j == 11 || j == 12 || j == 13 || j == 14)
                    {
                        KVSopt[i, j] = 0.9;
                    }
                    else if (j <= i)
                    {
                        KVSopt[i, j] = 0.86;
                    }
                }
            }
            // ВОЗРАСТ 60+, СТАЖ 0 - 14+
            for (int i = 60 - 16; i <= 84 - 16; i++)
            {
                for (int j = 0; j <= 67; j++)
                {
                    KVSopt[i, j] = 1.43;
                    if (j == 1)
                    {
                        KVSopt[i, j] = 1.36;
                    }
                    else if (j == 2)
                    {
                        KVSopt[i, j] = 1.35;
                    }
                    else if (j == 3 || j == 4)
                    {
                        KVSopt[i, j] = 0.91;
                    }
                    else if (j == 5 || j == 6)
                    {
                        KVSopt[i, j] = 0.9;
                    }
                    else if (j == 7 || j == 8 || j == 9)
                    {
                        KVSopt[i, j] = 0.89;
                    }
                    else if (j == 10 || j == 11 || j == 12 || j == 13 || j == 14)
                    {
                        KVSopt[i, j] = 0.88;
                    }
                    else if (j <= i)
                    {
                        KVSopt[i, j] = 0.83;
                    }
                }
            }
            return KVSopt[n1, n2];
        }
    }
}
