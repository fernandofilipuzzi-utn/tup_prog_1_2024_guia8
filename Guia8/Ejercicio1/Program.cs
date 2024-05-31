using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    internal class Program
    {
        #region dominio
        static int[] numeros = new int[100];
        static double[] notas = new double[100];
        static string[] nombres=new string[100];
        static int contador;

        static int[] numerosMP = new int[100];
        static double[] notasMP = new double[100];
        static string[] nombresMP = new string[100];
        static int contadorMP;

        static double CalcularPromedio()
        {
            double promedio = 0;
            for (int n = 0; n < contador; n++)
            {
                promedio += notas[n];
            }
            return promedio;
        }

        static void CalcularAlumnosNotasMayorPromedio()
        {
            double promedio = CalcularPromedio();
            for (int n = 0; n < contador; n++)
            {
                if (notas[n] > promedio)
                {
                    nombresMP[n] = nombresMP[n];
                    notasMP[n] = notasMP[n];
                    contadorMP++;
                }
            }
        }

        static void OrdenarAlumnosNotasMayorPromedio()
        {
            double promedio = CalcularPromedio();
            for (int n = 0; n < contadorMP-1; n++)
            {
                for (int m = n+1; m < contadorMP; m++)
                {
                    if (numeros[n] < numeros[m])
                    {
                        int auxLU= numerosMP[n];
                        numerosMP[n] = numerosMP[m];
                        numerosMP[m] = auxLU;

                        double auxN = notasMP[n];
                        notasMP[n] = notasMP[m];
                        notasMP[m] = auxN;

                        string auxM = nombresMP[n];
                        nombresMP[n] = nombresMP[m];
                        nombresMP[m] = auxM;
                    }
                }
            }
        }

        static public int  BuscarAlumnoPorNumeroLibreta(int lu) 
        {
            int idx = -1;

            int n = 0;
            while (n < contador && idx!=-1)
            {
                if (numeros[n] == lu)
                {
                    idx = n;
                }
            }

            return idx;
        }
        #endregion

        #region vista
        static void IngresarDatos()
        {
            Console.Clear();

            double nota=Convert.ToDouble(Console.ReadLine());
            while (nota>=0)
            {
                string nombre=Console.ReadLine();

                notas[contador] = nota;
                nombres[contador] = nombre;
                contador++;

                nota = Convert.ToDouble(Console.ReadLine());
            }

            Console.WriteLine("presione una tecla");
            Console.ReadKey();
        }
        static void MostrarPromedio()
        {
            Console.Clear();

            Console.WriteLine("{0:f2}", CalcularPromedio());

            Console.WriteLine("presione una tecla");
            Console.ReadKey();
        }

        static void MostrarAlumnosSuperaronPromedio()
        {
            Console.Clear();

            CalcularAlumnosNotasMayorPromedio();
            OrdenarAlumnosNotasMayorPromedio();
            for (int n = 0; n < contadorMP; n++)
            {
                Console.WriteLine("{0} {1:f2}", nombresMP[n], notasMP[n]);
            }

            Console.WriteLine("presione una tecla");
            Console.ReadKey();
        }

        static void MostrarCuadroBusqueda()
        {
            Console.Clear();

            int numero = Convert.ToInt32(Console.ReadLine());

            int idx = BuscarAlumnoPorNumeroLibreta(numero);

            if (idx > -1)
                Console.WriteLine("{0}{1}{2}", numeros[idx], nombres[idx], notas[idx]);
            else
                Console.WriteLine("no se encontró");

            Console.WriteLine("presione una tecla");
            Console.ReadKey();
        }


        static void Menu()
        {
            Console.Clear();

            Console.WriteLine("1- ingresar datos");
            Console.WriteLine("2- calcular promedio");
            Console.WriteLine("3- superaron el promedio");
            Console.WriteLine("4- mostrar cuadro de busqueda");

            Console.WriteLine("presione una tecla");
            Console.ReadKey();
        }

        #endregion

        static void Main(string[] args)
        {
            
            int op = 0;

            Menu();
            op = Convert.ToInt32(Console.ReadLine());
            while (op!=0)
            {
                switch (op)
                {
                    case 1:
                        { 
                            IngresarDatos();
                        } break;
                    case 2:
                        { 
                            MostrarPromedio();
                        }; break;
                    case 3:
                        { 
                            MostrarAlumnosSuperaronPromedio();
                        }; break;
                    case 4:
                        {
                            MostrarCuadroBusqueda();
                        }; break;
                    default: op = 0; break;
                }

        }
    }
}
