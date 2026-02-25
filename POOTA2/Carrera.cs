using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOTA2
{
    internal class Carrera
    {
        public int Codigo { get; }
        public string Nombre { get; }
        private int[] costosSemestre;

        public Carrera(int codigo, string nombre)
        {
            Codigo = codigo;
            Nombre = nombre;
            costosSemestre = new int[10];
        }

        public int[] GetCostosSemestre()
        {
            return costosSemestre;
        }

        public void SetCostoSemestre(int semestre1a10, int valor)
        {
            costosSemestre[semestre1a10 - 1] = valor;
        }

        public long Total()
        {
            long suma = 0;
            for (int i = 0; i < costosSemestre.Length; i++)
                suma += costosSemestre[i];
            return suma;
        }
    }
}
