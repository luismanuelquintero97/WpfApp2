using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    //Clase gramatica, como su nombre lo indica es donde esta la gramatica y es la clase principal(donde la magia sucede)

    public class gramatica
    {

        //las reglas que conforman la gramatica
        List<Regla> reglas;
        //los diferentes tipos de entrada de la gramatica
        String[] tiposDeEntrada;


        //el contructor de la gramatica en principio vacio
        public gramatica()
        {

            reglas = new List<Regla>();
        }

        /// <summary>
        /// metodo encargado de cargar la gramatica en la solucion
        /// </summary>
        /// <param name="ruta"></param>
        /// la ruta donde se encuentra el texto plano que contiene la informacion de la gramtica
        public void cargarGramatica(String ruta)
        {
            string[] text = System.IO.File.ReadAllLines(ruta);
            tiposDeEntrada = text[0].Split(',');

            for (int i = 1; i < text.Length; i = i + 2)
            {
                char nombre = Convert.ToChar(text[i]);
                List<String> opciones = new List<string>();
                String[] var = text[i + 1].Split(',');
                foreach (var v in var)
                {
                    opciones.Add(v);
                }
                Regla r = new Regla(nombre, opciones);
                reglas.Add(r);
            }
        }

        /// <summary>
        /// metodo que transforma la informacion de la gramatica cargada en un cadena de caracteres ordenada para su visualizacion
        /// </summary>
        /// <returns></returns>
        /// la cadena de caracteres ordenada
       
        public String gramaticaToString()
        {
            String gramatica = "";
            foreach (var r in reglas)
            {
                gramatica += r.reglaToString() + " \n";
            }
            return gramatica;
        }


        /// <summary>
        /// principal metodo del algoritmoCYK (es basteante autoexplicativo)
        /// </summary>
        /// <param name="cadena"></param>
        /// un arreglo de caracteres pasada como parametro por el usuario para saber si esta cadena es generada por la gramatica previamente cargada
        /// <returns></returns>
        /// la matriz generada resultante generada por el algoritmoCYK
        public List<String>[,] algoritmoCYK(string[] cadena)
        {
            int tamaño = cadena.Count();
            List<String>[,] matriz = new List<String>[tamaño, tamaño];

            //primera iteracion del algoritmo

            for (int i = 0; i < tamaño; i++)
            {
                List<String> loGeneran = new List<String>();
                foreach (Regla r in reglas)
                {
                    if (r.produce(cadena[i]))
                    {
                        String temp = r.refere.ToString();
                        loGeneran.Add(temp);
                    }
                }
                matriz[i, 0] = loGeneran;

            }
            // siguientes iteraciones del algoritmo
            for (int j = 2; j <= tamaño; j++)
            {
                for (int i = 1; i <= tamaño - j + 1; i++)
                {
                    List<String> loGeneran = new List<string>();

                    for (int k = 1; k <= j - 1; k++)
                    {
                        //encuentra las posiciones indicadas por el algoritmo en la matriz 

                        //lista con los generados que estan en la misma fila
                        List<string> l1 = matriz[i - 1, k - 1];
                        //lista con los generados que forman como la diagonal con la fila de abajito(no se como esplicar eso bien)
                        List<string> l2 = matriz[i + k - 1, j - k - 1];


                        //genera las diferentes alternativas cobinando los generardores de de las casillas ya encontradas
                        List<String> alt = alternativas(l1, l2);

                        //filtra las alternativas y obtiene las unicas que si son generedas por lo menos por algunas de las reglas
                        //de la gramatica
                        List<String> gen = new List<string>();
                        for (int l = 0; l < alt.Count; l++)
                        {

                            foreach (Regla r in reglas)
                            {
                                if (r.produce(alt.ElementAt(l)))
                                {
                                    String temp = r.refere.ToString();
                                    if (gen.Contains(temp) == false)
                                    {

                                        gen.Add(temp);
                                    }
                                }
                            }
                        }

                        loGeneran= loGeneran.Union(gen).ToList<String>();
                    }

                    matriz[i - 1, j - 1] = loGeneran;
                }

            }
            
            return matriz;

        }

        /// <summary>
        /// metodo encargado de convinar y generar las distintas convinaciones de dos listas de String, para nuestro algoritmo lo utilizamos
        /// para generar las posibles convinaciones que tiene los generadores anteriores
        /// </summary>
        /// <param name="l1"></param>
        /// la primera lista de caracteres, corresponde a los resultados de los generadores anteriores por la misma fila
        /// <param name="l2"></param>
        /// la segunda lista de caracteres que entra, coresponde a las casillas en orden diagonal que contiene generadores
        /// <returns></returns>
        /// returna la uniond de dichas dos listas, el cual contiene todas las posiblens convinaciones de estas
        public List<String> alternativas(List<String> l1, List<String> l2)
        {
            List<String> union = new List<string>();

            if(l1.Count>0 && l2.Count ==0)
            {
                union = l1;
            }
            else if(l2.Count>0&& l1.Count == 0)
            {
                union = l2;
            }
            else if(l1.Count==0 && l2.Count == 0)
            {
            }
            else
            {
                foreach(String l in l1)
                {
                    foreach(String m in l2)
                    {
                        String temp = l + m;
                        union.Add(temp);
                    }
                }
            }
            return union;
        }
    }
}
