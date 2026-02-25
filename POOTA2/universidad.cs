using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOTA2
{
    internal class universidad
    {
        private Carrera[] carreras;
        private Random rnd;

        public universidad(string[] nombresCarreras)
        {
            carreras = new Carrera[12];
            rnd = new Random();

            for (int i = 0; i < 12; i++)
            {
                int codigo = i + 1; // 1..12
                carreras[i] = new Carrera(codigo, nombresCarreras[i]);
            }
        }

        public void GenerarDatosAleatorios(int min, int max)
        {
            for (int i = 0; i < carreras.Length; i++)
            {
                for (int s = 1; s <= 10; s++)
                {
                    int valor = rnd.Next(min, max + 1);
                    carreras[i].SetCostoSemestre(s, valor);
                }
            }
        }

        public long[] TotalesPorSemestre()
        {
            long[] totales = new long[10];

            for (int s = 0; s < 10; s++)
            {
                long suma = 0;
                for (int c = 0; c < carreras.Length; c++)
                {
                    suma += carreras[c].GetCostosSemestre()[s];
                }
                totales[s] = suma;
            }

            return totales;
        }

        public double[] PromediosPorSemestre()
        {
            long[] totales = TotalesPorSemestre();
            double[] promedios = new double[10];

            for (int s = 0; s < 10; s++)
            {
                promedios[s] = totales[s] / (double)carreras.Length;
            }

            return promedios;
        }

        public long CostoGlobal()
        {
            long total = 0;
            for (int i = 0; i < carreras.Length; i++)
                total += carreras[i].Total();
            return total;
        }

        public int SemestreMenosCuantioso()
        {
            long[] totales = TotalesPorSemestre();

            int posMin = 0;
            long min = totales[0];

            for (int i = 1; i < totales.Length; i++)
            {
                if (totales[i] < min)
                {
                    min = totales[i];
                    posMin = i;
                }
            }

            return posMin + 1;
        }

        public Carrera[] CarrerasOrdenadasPorCostoDesc()
        {
            Carrera[] copia = new Carrera[carreras.Length];
            for (int i = 0; i < carreras.Length; i++)
                copia[i] = carreras[i];

            for (int i = 0; i < copia.Length - 1; i++)
            {
                for (int j = 0; j < copia.Length - 1 - i; j++)
                {
                    if (copia[j].Total() < copia[j + 1].Total())
                    {
                        Carrera temp = copia[j];
                        copia[j] = copia[j + 1];
                        copia[j + 1] = temp;
                    }
                }
            }

            return copia;
        }
    }
}