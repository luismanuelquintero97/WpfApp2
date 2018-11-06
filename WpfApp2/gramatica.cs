using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class gramatica
    {

        List<Regla> reglas;
        String[] tiposDeEntrada;



        public gramatica()
        {

            reglas = new List<Regla>();
        }
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
        public String gramaticaToString()
        {
            String gramatica = "";
            foreach (var r in reglas)
            {
                gramatica += r.reglaToString() + " \n";
            }
            return gramatica;
        }

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

            ;
            for (int j = 2; j <= tamaño; j++)
            {
                for (int i = 1; i <= tamaño - j + 1; i++)
                {
                    List<String> loGeneran = new List<string>();

                    for (int k = 1; k <= j - 1; k++)
                    {
                        List<string> l1 = matriz[i - 1, k - 1];
                        List<string> l2 = matriz[i + k - 1, j - k - 1];

                        List<String> alt = alternativas(l1, l2);

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
