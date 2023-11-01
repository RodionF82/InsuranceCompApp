using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompApp.Classes
{
    internal class ArrayKBM
    {
        public double ArrayGet(int nowKBM, int numCrash)
        {
            double[,] arrayKBM = new double[15, 15];

            // Если КБМ - М 
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    if (j == 0)
                        arrayKBM[i, j] = 1; //  КБМ - 0
                    else
                    {
                        arrayKBM[i, j] = 0;
                    }
                }
            }
            // Если КБМ - 0 
            for (int i = 1; i < 2; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    if (j == 0)
                        arrayKBM[i, j] = 2; // КБМ - 1
                    else
                        arrayKBM[i, j] = 0;
                }
            }
            // Если КБМ - 1
            for (int i = 2; i < 3; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    if (j == 0)
                        arrayKBM[i, j] = 3; // КБМ - 2
                    else
                        arrayKBM[i, j] = 0;
                }
            }
            // Если КБМ - 2
            for (int i = 3; i < 4; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    if (j == 0)
                        arrayKBM[i, j] = 4; // КБМ - 3 
                    else if (j == 1)
                        arrayKBM[i, j] = 2; // КБМ - 1
                    else
                        arrayKBM[i, j] = 0;
                }
            }
            // Если КБМ - 3
            for (int i = 4; i < 5; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    if (j == 0)
                        arrayKBM[i, j] = 5; // КБМ - 4 
                    else if (j == 1)
                        arrayKBM[i, j] = 2; // КБМ - 1
                    else
                        arrayKBM[i, j] = 0;
                }
            }
            // Если КБМ - 4
            for (int i = 5; i < 6; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    if (j == 0)
                        arrayKBM[i, j] = 6; // КБМ - 5
                    else if (j == 1)
                        arrayKBM[i, j] = 3; // КБМ - 2 
                    else if (j == 2)
                        arrayKBM[i, j] = 2; // КБМ - 1
                    else
                        arrayKBM[i, j] = 0;
                }
            }
            // Если КБМ - 5
            for (int i = 6; i < 7; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    if (j == 0)
                        arrayKBM[i, j] = 7; // КБМ - 6
                    else if (j == 1)
                        arrayKBM[i, j] = 4; // КБМ - 3
                    else if (j == 2)
                        arrayKBM[i, j] = 2; // КБМ - 1
                    else
                        arrayKBM[i, j] = 0;
                }
            }
            // Если КБМ - 6
            for (int i = 7; i < 8; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    if (j == 0)
                        arrayKBM[i, j] = 8; // КБМ - 7
                    else if (j == 1)
                        arrayKBM[i, j] = 5; // КБМ - 4
                    else if (j == 1)
                        arrayKBM[i, j] = 3; // КБМ - 2
                    else
                        arrayKBM[i, j] = 0;
                }
            }
            // Если КБМ - 7
            for (int i = 8; i < 9; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    if (j == 0)
                        arrayKBM[i, j] = 9; // КБМ - 8
                    else if (j == 1)
                        arrayKBM[i, j] = 5; // КБМ - 4
                    else if (j == 2)
                        arrayKBM[i, j] = 3; // КБМ - 2
                    else
                        arrayKBM[i, j] = 0;
                }
            }
            // Если КБМ - 8 
            for (int i = 9; i < 10; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    if (j == 0)
                        arrayKBM[i, j] = 10; // КБМ - 9
                    else if (j == 1)
                        arrayKBM[i, j] = 6; // КБМ - 5
                    else if (j == 2)
                        arrayKBM[i, j] = 3; // КБМ - 2
                    else
                        arrayKBM[i, j] = 0;
                }
            }
            // Если КБМ - 9
            for (int i = 10; i < 11; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    if (j == 0)
                        arrayKBM[i, j] = 11; // КБМ - 10
                    else if (j == 1)
                        arrayKBM[i, j] = 6; // КБМ - 5
                    else if (j == 2)
                        arrayKBM[i, j] = 3; // КБМ - 2
                    else if (j == 3)
                        arrayKBM[i, j] = 2; // КБМ - 1
                    else
                        arrayKBM[i, j] = 0;
                }
            }
            // Если КБМ - 10
            for (int i = 11; i < 12; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    if (j == 0)
                        arrayKBM[i, j] = 12; // КБМ - 11
                    else if(j == 1)
                        arrayKBM[i, j] = 7; // КБМ - 6
                    else if(j == 2)
                        arrayKBM[i, j] = 4; // КБМ - 3
                    else if(j == 3)
                        arrayKBM[i, j] = 2; // КБМ - 1
                    else
                        arrayKBM[i, j] = 0;
                }
            }
            // Если КБМ - 11
            for (int i = 12; i < 13; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    if (j == 0)
                        arrayKBM[i, j] = 13; // КБМ - 12
                    else if(j == 1)
                        arrayKBM[i, j] = 7; // КБМ - 6
                    else if(j == 2)
                        arrayKBM[i, j] = 4; // КБМ - 3
                    else if(j == 3)
                        arrayKBM[i, j] = 2; // КБМ - 1
                    else
                        arrayKBM[i, j] = 0;
                }
            }
            // Если КБМ - 12
            for (int i = 13; i < 14; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    if (j == 0)
                        arrayKBM[i, j] = 14; // КБМ - 13
                    else if(j == 1)
                        arrayKBM[i, j] = 7; // КБМ - 6
                    else if(j == 2)
                        arrayKBM[i, j] = 4; // КБМ - 3
                    else if(j == 3)
                        arrayKBM[i, j] = 2; // КБМ - 1
                    else
                        arrayKBM[i, j] = 0;
                }
            }
            // Если КБМ - 13
            for (int i = 14; i < 15; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    if (j == 0)
                        arrayKBM[i, j] = 13; // КБМ - 12
                    else if(j == 1)
                        arrayKBM[i, j] = 8; // КБМ - 7
                    else if(j == 2)
                        arrayKBM[i, j] = 4; // КБМ - 3
                    else if(j == 3)
                        arrayKBM[i, j] = 2; // КБМ - 1
                    else
                        arrayKBM[i, j] = 0;
                }
            }
            return arrayKBM[nowKBM, numCrash];


            /*double[,] KBMarray = new double[14, 15];
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j <= 14; j++)
                {
                    if (j == 0)
                    {
                        KBMarray[i, j] = 1;
                    }
                    else
                    {
                        KBMarray[i, j] = 0;
                    }
                }
            }

            for (int i = 1; i < 2; i++)
            {
                for (int j = 0; j <= 14; j++)
                {
                    if (j == 0)
                    {
                        KBMarray[i, j] = 2;
                    }
                    else
                    {
                        KBMarray[i, j] = 0;
                    }
                }
            }*/
        }
    }
}
