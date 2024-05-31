using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    internal class Program
    {
        #region variables y metodos del dominio

        #region datos de alumnos
        static int[] lus = new int[100];
        static string[] nombres = new string[100];
        static double[] notas = new double[100];
        static int contador = 0;
        #endregion

        #region datos Mayores al Promedio MP
        static int[] lusMAP = new int[100];
        static string[] nombresMAP = new string[100];
        static double[] notasMAP = new double[100];
        static int contadorMAP = 0;
        #endregion

        static void CargarValor(int lu, string nombre, double nota)
        {
            lus[contador] = lu;
            nombres[contador] = nombre;
            notas[contador] = nota;
            contador++;
        }

        static double CalcularPromedio()
        {
            double promedio = 0;
            for (int n = 0; n < contador; n++)
            {
                promedio += notas[n];
            }
            if (contador > 0)
                promedio /= contador;
            return promedio;
        }

        static void DeterminarAlumnosMayoresAlPromedio() 
        {
            double promedioGeneral = CalcularPromedio();
            for (int n = 0; n < contador; n++)
            {
                if (notas[n] >= promedioGeneral)
                {
                    AgregarAlumnoMayorAlPromedio( n);
                }
            }
        }

        static void AgregarAlumnoMayorAlPromedio(int idx)
        {
            lusMAP[idx] = lus[idx];
            nombresMAP[idx] = nombres[idx];
            notasMAP[idx] = notas[idx];

            contadorMAP++;
        }

        static void OrdenarListadoMayorAlPromedio() 
        {
            for (int actual = 0; actual < contadorMAP-1; actual++) 
            {
                for (int sig = actual+1; sig < contadorMAP; sig++)
                {
                    if (notasMAP[actual] < notasMAP[sig])
                    {
                        int auxlu = lusMAP[actual];
                        lusMAP[actual] = lusMAP[sig];
                        lusMAP[sig] = auxlu;

                        string auxNombre = nombresMAP[actual];
                        nombresMAP[actual] = nombresMAP[sig];
                        nombresMAP[sig] = auxNombre;

                        double auxNota = notasMAP[actual];
                        notasMAP[actual] = notasMAP[sig];
                        notasMAP[sig] = auxNota;
                    }
                }
            }
        }

        #endregion

        #region variables y metodos de la vista
        static int MostrarMenuYSolicitarOpcion()
        {
            Console.Clear();
            Console.WriteLine("\t\tMenú principal");

            Console.WriteLine("\t1- Solicitar listado");
            Console.WriteLine("\t2- Mostrar promedio general");
            Console.WriteLine("\t3- Mostrar alumnos que superaron al promedio");

            int op = Convert.ToInt32(Console.ReadLine());
            return op;
        }

        static void MostrarSolicitudCargaValores()
        {
            Console.Clear();
            Console.WriteLine("\t\t Solicitud de listado de valores");

            Console.WriteLine("-------------------");
            Console.WriteLine("Ingrese Libreta universitaria (-1 termina el listado)");
            int lu = Convert.ToInt32(Console.ReadLine());
            while (lu > -1)
            {
                Console.WriteLine("\tIngrese ahora nombre y nota:");
                string nombre = Console.ReadLine();
                double nota = Convert.ToDouble(Console.ReadLine());

                CargarValor(lu, nombre, nota);

                Console.WriteLine("-------------------");
                Console.WriteLine("\n\nIngrese lu (-1 termina el listado)");
                lu = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("presione una tecla para volver al menú principal");
            Console.ReadKey();
        }

        static void MostrarPromedioGeneral()
        {
            Console.Clear();
            Console.WriteLine("\t\t Mostrar promedio general:\n");

            if (contador == 0)
            {
                Console.WriteLine("\t\t\tNo se han ingresado notas aún!");
            }
            else
            {
                Console.WriteLine("\t\t\tPromedio general: {0:f2}", CalcularPromedio());
            }

            Console.WriteLine("presione una tecla para volver al menú principal");
            Console.ReadKey();
        }

        static void MostrarListadoMayoresAlPromedio() 
        {
            Console.Clear();
            Console.WriteLine("\t\t Listado de alumnos Mayores al Promedio\actual\actual");

            DeterminarAlumnosMayoresAlPromedio();
            OrdenarListadoMayorAlPromedio();

            Console.WriteLine("|{0,-10}|{1,20}{2,10}|","LU","Nombre","Nota");
            Console.WriteLine("---------------------------------------");
            for (int n = 0; n < contadorMAP; n++)
            {
                Console.WriteLine("|{0,-10}|{1,20}|{2,10:f2}|",
                    lusMAP[n], nombresMAP[n], notasMAP[n]);
            }
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("\n");

            Console.WriteLine("presione una tecla para volver al menú principal");
            Console.ReadKey();
        }
        #endregion

        static void Main(string[] args)
        {
            int op = 0;

            op = MostrarMenuYSolicitarOpcion();
            while (op != 0)
            {
                switch (op)
                {
                    case 1:
                        {
                            MostrarSolicitudCargaValores();
                        }
                        break;
                    case 2:
                        {
                            MostrarPromedioGeneral();
                        }
                        break;
                    case 3:
                        {
                            MostrarListadoMayoresAlPromedio();
                        }
                        break;
                    default:
                        { op = 0; }
                        break;
                }

                op = MostrarMenuYSolicitarOpcion();
            }
        }
    }
}
