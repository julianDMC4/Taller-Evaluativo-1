using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Taller_Evaluativo
{
    class Program
    {
        static void Main(string[] args)
        {

            Stack pila1 = new Stack();
            List<int> lista1 = new List<int>();
            int[] arreglo1 = new int[20];
            Dictionary<int, String> diccionario1 = new Dictionary<int, string>();
            LlenarVector(pila1, 25);
            LlenarVector(lista1, 20);
            LlenarVector(arreglo1);
            LlenarDiccionario(arreglo1, diccionario1);
            Ejercicios ejercicios = new Ejercicios();
            ejercicios.Ejercicio1(pila1);
            ejercicios.Ejercicio2(56,lista1);
            ejercicios.Ejercicio3(diccionario1);


        }
        public static void LlenarVector(Stack trinis, int cantidad)
        {
            Random numeroaleatorio = new Random();
            for (int i = 0; i < cantidad; i++)
            {
                trinis.Push(numeroaleatorio.Next(0, 100));
               
            }

        }
        public static void LlenarVector(List<int> trinis, int cantidad)
        {
            Random numeroaleatorio = new Random();
            for (int i = 0; i < cantidad*2; i++)
            {
                trinis.Add(numeroaleatorio.Next(0, 100));
                //Console.WriteLine(trinis[i]);
            }

        }


        public static void LlenarVector(int[] trinis)
        {
            Random numeroaleatorio = new Random();
            for (int i = 0; i < trinis.Length; i++)
            {
                trinis[i]=(numeroaleatorio.Next(0, 100));
               
            }
        }
        public static void LlenarDiccionario(int[] trinis, Dictionary<int, string> diccionario)
        {
            string resultado = "";
            int prueba = 0;
            Ejercicios ejercicios = new Ejercicios();
            for (int i = 0; i < trinis.Length; i++)
            {
                prueba = trinis[i];
                
                if(prueba%2 == 0 && prueba!= 2)
                {
                    resultado = "2";
                }
                else if (prueba % 3 == 0 && prueba != 3)
                {
                    resultado = "3";
                }
                else if (prueba % 5 == 0 && prueba != 5)
                {
                    resultado = "5";
                }
                else if (prueba % 7 == 0 && prueba != 7)
                {
                    resultado = "7";
                }
                else
                {
                    resultado = "prime";
                }
               
                if (!diccionario.ContainsKey(trinis[i]))
                {
                    diccionario.Add(trinis[i], resultado);
                }
            }
            for (int i = 0; i < diccionario.Count; i++)
            {
                var entrada = diccionario.ElementAt(i);
                Console.WriteLine("el numero " + entrada.Key + "  es divisible por" + entrada.Value);
            }
        }

    }


    class Ejercicios
    {

        public void Ejercicio3(Dictionary<int,string> diccionario)
        {
            OrdenarAcendente(diccionario);
        }
        public List<int> OrdenarAcendente(List<int> Lista)
        {
            int auxiliar;
            for (int i = 0; i <= Lista.Count; i++)
            {
                for (int j = 0; j < Lista.Count - 1; j++)
                {
                    if (Lista[j] > Lista[j + 1]) 
                    {
                        auxiliar = Lista[j];
                        Lista[j] = Lista[j + 1];
                        Lista[j + 1] = auxiliar;
                    }
                }
            }
            /*for (int i = 0; i < Lista.Count; i++)
            {
                Console.WriteLine(Lista[i]);
            }*/
            return Lista;
        }

        public Dictionary<int,string> OrdenarAcendente(Dictionary<int,string> Diccionario)
        {
            int auxiliar;
            string auxiliar2;
            List<int> Llaves= new List<int>();
            List<string> Valores = new List<string>();
            Dictionary<int, string> Diccionario_Ordenado = new Dictionary<int, string>();

            for (int i = 0; i < Diccionario.Count; i++)
            {
                var entrada = Diccionario.ElementAt(i);
                Llaves.Add(entrada.Key);
                Valores.Add(entrada.Value);
            }
            for (int i = 0; i <= Llaves.Count; i++)
            {
                for (int j = 0; j < Llaves.Count - 1; j++)
                {
                    if (Llaves[j] > Llaves[j + 1])
                    {
                        auxiliar = Llaves[j];
                        auxiliar2 = Valores[j];
                        Llaves[j] = Llaves[j + 1];
                        Llaves[j + 1] = auxiliar;
                        Valores[j] = Valores[j + 1];
                        Valores[j + 1] = auxiliar2;
                    }
                }
            }
            for (int i = 0; i < Llaves.Count; i++)
            {
                Diccionario_Ordenado.Add(Llaves[i], Valores[i]);
                Console.WriteLine( Diccionario_Ordenado.ElementAt(i));
            }
            return null;
        }


            public  void Ejercicio2(int numerodeseado, List<int> Lista)
        {
            OrdenarAcendente(Lista);
            for (int i = 0; i < Lista.Count; i++)
            {
                if(numerodeseado == Lista[i])
                {
                    Console.WriteLine("Sisas, el numero " + numerodeseado + " si esta en la lista");
                    return;
                }
               
            }
            Console.WriteLine("Nonas, el numero " + numerodeseado + " no esta en la lista");
        }
       public int ComprobarPrimos(int numero)
        {
            bool EsPrimo(int value)
            {
                var Factores = Math.Sqrt(numero);
                for (var factor = 2; factor <= Factores; factor++)
                {
                    if (value % factor == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            if(numero > 1 && EsPrimo(numero))
            {
                Console.WriteLine("Este numero es primo:" + numero);
                return numero;
            }
            else
            {
                //Console.WriteLine("Este numero no es primo:" + numero);
                return -1;
            }
            
        }
        public void Ejercicio1(Stack trinis)
        {
            Stack trinisCopia = new Stack();
            trinisCopia = trinis;
            for (int i = 0; i < trinis.Count; i++)
            {
                if (ComprobarPrimos((int)trinisCopia.Pop())!=-1)
                {
                    Console.WriteLine("Esta Pila si tiene un primo");
                    return;
                }
            }
            Console.WriteLine("Esta Pila no tiene primos");

        }

        
    } 
}
