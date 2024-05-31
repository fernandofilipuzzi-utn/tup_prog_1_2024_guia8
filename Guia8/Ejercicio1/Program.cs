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
        int[] numeros=new int[100];
        int contador = 0;

        #endregion

        #region variables y métodos
        static void MostrarMenu()
        { 
        }

        static void MostrarCargaValore()
        { }
        #endregion
        static void Main(string[] args)
        {
            int op = 0;

            MostrarMenu();
            op = Convert.ToInt32(Console.ReadLine());
            while (op == 0)
            {
                switch (op)
                {
                    case 1:
                        { }break;
                    default:
                        { op = 0; }break;
                }

                MostrarMenu();
                op = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}
