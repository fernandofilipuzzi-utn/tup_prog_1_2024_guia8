using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    internal class Program
    {
        #region variables y métodos del dominio
        static int[] numeros=new int[100];
        static int contador = 0;

        static void CargarValor(int valor)
        {
            numeros[contador++] = valor;
        }
        #endregion

        #region variables y métodos
        static int MostrarMenuYSolicitarOpcion()
        {
            Console.Clear();

            Console.WriteLine("1- Solicitar listado");
            Console.WriteLine("2- Mostrar listado ordenado");
            Console.WriteLine("3- Buscar valor");

            int op =Convert.ToInt32(Console.ReadLine());
            return op;
        }

        static void MostrarSolicitudCargaValores()
        {
            Console.Clear();
            Console.WriteLine("\t\t Solicitud de listado de valores");

            Console.WriteLine("ingrese valor(-1 sale)");
            int val = Convert.ToInt32(Console.ReadLine());
            while (val>-1)
            {
                CargarValor(valor);

                Console.WriteLine("ingrese valor(-1 sale)");
                val = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("presione una tecla para salir");
            Console.ReadKey();
        }

        static void MostrarListadoOrdenado() 
        {
            Console.Clear();
            Console.WriteLine("\t\t listado ordenado");

            Console.WriteLine("presione una tecla para salir");
            Console.ReadKey();
        }
        #endregion

        static void Main(string[] args)
        {
            int op = 0;

            op= MostrarMenuYSolicitarOpcion();
            while (op == 0)
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
                            MostrarListadoOrdenado();
                        }break;
                    default:
                        { op = 0; }break;
                }

                op = MostrarMenuYSolicitarOpcion();
            }
        }
    }
}
