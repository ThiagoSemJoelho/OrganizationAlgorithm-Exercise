﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AlgoritimoOrganizacao_Antoanne
{
    class Algorithm
    {
        #region Properties
        Random random = new Random();
        Stopwatch stopwatch = new Stopwatch();
        private long elapsed;
        #endregion

        #region Methods
        private void AddRandomElements(int q, int min, int max, List<int> l)
        {
            int count = 0;
            while(count != q)
            {
                l.Add(random.Next(min, max));
                count++;
            }
        }

        private void BubbleSort(List<int> l)
        {
            stopwatch.Start();
            int temp = 0;
            int nxt = 0;

            for (int i = 0; i < l.Count; i++)
            {
                for (int j = 0; j < l.Count - 1; j++)
                {
                    nxt = j + 1;
                    if (l[j] > l[nxt]){
                        temp = l[nxt];
                        l[nxt] = l[j];
                        l[j] = temp;
                    }
                }
            }
            stopwatch.Stop();
            elapsed = stopwatch.ElapsedMilliseconds;
        }

        private string ToString(List<int> l)
        {
            string Elements = "";
            foreach (int number in l)
            {
                Elements += number.ToString() + ", ";
            }

            return Elements;
        }

        private string ToString(List<long> l)
        {
            string Elements = "";
            foreach (long number in l)
            {
                Elements += number.ToString() + ", ";
            }

            return Elements;
        }

        private void LinearSearch(List<int> l, int i)
        {
            long elp;
            stopwatch.Start();
            for (int c = 0; c < l.Count; c++)
            {
                if (l[c] == i)
                {
                    elp = stopwatch.ElapsedMilliseconds;
                    stopwatch.Stop();
                    Console.WriteLine("Elemento: " + i + "Posição: " + c + ", " + "Tempo de busca: " + elp);
                }
                else if(c == l.Count)
                {
                    stopwatch.Stop();
                    Console.WriteLine("Não encontrado!");
                }
            }
        }

        private void BinarySearch(List<int> l, int i)
        {
            long elp;
            stopwatch.Start();
            for (int c = 0; c < l.Count; c++)
            {
                if (l[c] == i)
                {
                    elp = stopwatch.ElapsedMilliseconds;
                    stopwatch.Stop();
                    Console.WriteLine("Elemento: " + i + "Posição: " + c + ", " + "Tempo de busca: " + elp);
                }
                else if (c == l.Count)
                {
                    stopwatch.Stop();
                    Console.WriteLine("Não encontrado!");
                }
            }
        }
        #endregion

        #region Antoanne Task
        public void AntoanneTask(Chart chr)
        {
            List<int> nbrs = new List<int>();
            List<long> elapseds = new List<long>();

            AddRandomElements(5, 0, 500, nbrs);
            BubbleSort(nbrs);
            elapseds.Add(elapsed);
            
            while(nbrs.Count != 2000)
            {
                AddRandomElements(5, 0, 500, nbrs);
                BubbleSort(nbrs);
                elapseds.Add(elapsed);
                chr.Series["BubbleSort"].Points.AddXY(nbrs.Count, elapsed);
                chr.Update();
            }

            Console.WriteLine("Elementos da lista: " + ToString(nbrs));
            Console.WriteLine("Tempo em milisegundos de cada ordenação: " + ToString(elapseds));
            LinearSearch(nbrs, random.Next(0,500));
        }
        #endregion
    }
}
