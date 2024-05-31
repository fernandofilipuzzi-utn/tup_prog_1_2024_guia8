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

        static void OrdenarListado()
        {
            for (int n = 0; n < contador - 1; n++)
            {
                for (int m = n + 1; m < contador; m++)
                {
                    if (numeros[n] > numeros[m])
                    {
                        Intercambio(n, m);
                    }
                }
            }
        }

        static void Intercambio(int n, int m)
        {
            int aux = numeros[n];
            numeros[n] = numeros[m];
            numeros[m] = aux;
        }

        static int BuscarPorValorSecuencial(int valor) 
        {
            int n = 0, idx=-1;
            while (n < contador && idx == -1)
            {
                if (numeros[n] == valor)
                    idx = n;
                n++;
            }
            return idx;
        }

        #endregion

        #region variables y métodos de la vista
        static int MostrarMenuYSolicitarOpcion()
        {
            Console.Clear();
            Console.WriteLine("\t\tMenú principal");

            Console.WriteLine("\t1- Solicitar listado");
            Console.WriteLine("\t2- Mostrar listado ordenado");
            Console.WriteLine("\t3- Buscar valor");

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
                CargarValor(val);

                Console.WriteLine("ingrese valor(-1 sale)");
                val = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("presione una tecla para salir");
            Console.ReadKey();
        }

        static void MostrarListadoOrdenado() 
        {
            Console.Clear();
            Console.WriteLine("\t\t listado ordenado\n\n");

            OrdenarListado();

            Console.WriteLine("\nListado ordenado:");
            for (int n = 0; n < contador; n++)
            {
                Console.Write("{0} -", numeros[n]);
            }

            Console.WriteLine("\n presione una tecla para volver al menú principal");
            Console.ReadKey();
        }

        static void MostrarBusquedaValor() 
        {
            Console.Clear();
            Console.WriteLine("\t\t Busqueda de valor");

            Console.Write("Ingrese valor a buscar: ");
            int valor=Convert.ToInt32(Console.ReadLine()); 
            
            int idx = BuscarPorValorSecuencial(valor);
            if (idx > -1)
            {
                Console.WriteLine("Valor {0} fue encontra en la posicion: {1}", numeros[idx], idx+1);
            }
            else
            {
                Console.WriteLine("Valor {0} no NO encontrado", valor);
            }

            Console.WriteLine("presione una tecla para salir");
            Console.ReadKey();
        }
        #endregion

        static void Main(string[] args)
        {
            int op = 0;

            op= MostrarMenuYSolicitarOpcion();
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
                            MostrarListadoOrdenado();
                        }break;
                    case 3:
                        {
                            MostrarBusquedaValor();
                        }
                        break;
                    default:
                        { op = 0; }break;
                }

                op = MostrarMenuYSolicitarOpcion();
            }
        }
    }
}
