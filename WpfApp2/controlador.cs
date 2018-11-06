using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class controlador
    {
        private gramatica gramatica;

        public controlador()
        {
            gramatica = new gramatica();
        }
        
        public void cargarGramatica(String ruta)
        {
            Console.WriteLine(ruta);
            gramatica.cargarGramatica(ruta);
        }
        public String gramaticaToString()
        {
            return gramatica.gramaticaToString();
        }

        public String algortimoCYK(String cadena)
        {
            String mensaje = "";
            String[] cad = new string[cadena.Length];
           for(int i = 0; i < cadena.Length; i++) 
            {
                cad[i] = cadena.ElementAt(i).ToString();
            }
            cad.ToList().ForEach(c => Console.WriteLine("            "+ c));
            List<String>[,] matriz = gramatica.algoritmoCYK(cad);

           // if (matriz[0, cadena.Length-1].Contains("s"))
           // {
             //   throw new Exception("no se pudo generar la cadena de entrada");
            //}
            
            
                
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
