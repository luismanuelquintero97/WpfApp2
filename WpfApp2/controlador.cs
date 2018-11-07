using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    //funciona como controlador para la gramatica y que quede mas ordenado
    public class controlador
    {
        private gramatica gramatica;

        //el constructor inicializa la gramatica vacia, posterior mente se carga la gramatica
        public controlador()
        {
            gramatica = new gramatica();
        }


        /// <summary>
        /// metodo encargado de cargar la gramatica que seleciona el usuario apartir de un archivo plano
        /// </summary>
        /// <param name="ruta"></param>
        /// parametro de la ruta en la cual se encuentra el archivo plano que contiene la gramatica
        public void cargarGramatica(String ruta)
        {
            Console.WriteLine(ruta);
            gramatica.cargarGramatica(ruta);
        }

        /// <summary>
        /// metodo que establece el formato el cual se va a mostrar la gramatica en la interfaz(paraque se vea bonita)
        /// </summary>
        /// <returns></returns>
        /// returna un string con la informacion referente a la gramatica ya ordenada
        public String gramaticaToString()
        {
            return gramatica.gramaticaToString();
        }
        /// <summary>
        /// metodo encargado de dividir la cadena entrada por parametro y llamar a la gramatica para efectuar el algoritmoCYK, 
        /// tambien organiza la informacion que recibe de la gramatica en un string y finalmente decide si la cadena es generada o no
        /// </summary>
        /// <param name="cadena"></param>
        /// la cadena de entrada pasada por el usuario que se necesita comprobar si es generadad por la gramatica o no
        /// <returns></returns>
        /// un String con la informacion ordenada de la matriz generada por el algoritmoCYK
        public String algortimoCYK(String cadena)
        {
            String mensaje = "";
            String[] cad = new string[cadena.Length];
            
            
            //Separa la cadenada y crea un arreglo

           for(int i = 0; i < cadena.Length; i++) 
            {
                cad[i] = cadena.ElementAt(i).ToString();
            }
            List<String>[,] matriz = gramatica.algoritmoCYK(cad);

            // comprueba que la gramatica genera la cadena

           if (matriz[0, cadena.Length-1].Contains("s")==false)
            {
               //agragar mensaje para decir que la gramatica no genera la cadena
            }
            

            // organiza la informacion de la matriz generada
                
                for(int i=0; i < cadena.Length; i++)
                {
                    String temp = cadena.ElementAt(i).ToString();

                    for(int j=0; j < cadena.Length; j++)
                    {
                        if (matriz[i, j] != null)
                        {
                        temp += "[ "; 
                        List<String> tempCadena = matriz[i, j];
                        for (int k = 0; k < tempCadena.Count; k++)
                        {
                            temp += tempCadena.ElementAt(k);
                        }
                        temp += " ]";
                        }
                    }

                    mensaje += temp + "    \n";

                }
            
            return mensaje;
        }
    }
}
