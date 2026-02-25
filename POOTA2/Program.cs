using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOTA2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nombresCarreras = new string[]
            {
                "Ingeniería de Sistemas",
                "Ingeniería Industrial",
                "Ingeniería Civil",
                "Medicina",
                "Enfermería",
                "Derecho",
                "Administración",
                "Ingenieria Financiera",
                "Psicología",
                "Arquitectura",
                "Comunicación Social",
                "Neogocios Internacionales"
            };

            universidad u = new universidad(nombresCarreras);
            u.GenerarDatosAleatorios(1_000_000, 3_000_000);

            Console.WriteLine("███ TOTALES Y PROMEDIOS POR SEMESTRE (todas las carreras) ███");
            long[] totalesSem = u.TotalesPorSemestre();
            double[] promediosSem = u.PromediosPorSemestre();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Semestre {i + 1}: Total = {totalesSem[i]:N0} | Promedio = {promediosSem[i]:N2}");
            }

            Console.WriteLine("\n███ COSTOS POR CADA CARRERA (Descendente) ███");
            Carrera[] ordenadas = u.CarrerasOrdenadasPorCostoDesc();
            foreach (var c in ordenadas)
            {
                Console.WriteLine($"Código {c.Codigo:00} - {c.Nombre}: Total = {c.Total():N0}");
            }

            Console.WriteLine($"\n███ COSTO GLOBAL UNIVERSIDAD ███\n{u.CostoGlobal():N0}");

            int semMenor = u.SemestreMenosCuantioso();
            Console.WriteLine($"\n███ SEMESTRE MENOS CUANTIOSO ███\nSemestre {semMenor} (Total = {totalesSem[semMenor - 1]:N0})");

            Console.WriteLine("\nPresiona una tecla para salir...");
            Console.ReadKey();
        }
    }
}

