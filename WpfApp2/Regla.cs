using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{

    //clase de una regla de la gramatica
    class Regla
    {
        //char con la referencia de la regla
        private Char referencia;

        //los posibles caminos que puede tomar la gramatica al utilizar este camino
        private List<string> opciones; 

        /// <summary>
        /// contructor de una regla de 
        /// </summary>
        /// <param name="refe"></param>
        /// la referencia de la regla es un char y esta en mayuscula
        /// <param name="opc"></param>
        /// los diferentes opciones que tiene la regla
        public Regla(char refe, List<String> opc)
        {
            referencia = refe;
            opciones = opc;
        }

        /// <summary>
        /// metodo de getter y setter de la referencia de la regla
        /// </summary>
        public Char refere { get { return referencia; } set { referencia = value; } }


        /// <summary>
        /// metodo axuliar del toString de la gramtica, organiza la regla y la deja bonita
        /// </summary>
        /// <returns></returns>
        /// returna una cadena de carracteres con la infromacion de la regla
        public String reglaToString()
        {
            String regla =referencia + " -->" ;
            foreach(var o in opciones)
            {
                regla += o + " | ";
            }


            return regla;
        }

        /// <summary>
        /// metodo para conecer si un caracter que entra por parametro es produciodo por esta regla en especifico
        /// </summary>
        /// <param name="p"></param>
        /// caracter que entre para saber si es producide en esta regla o mejor dicho se puede accerder desde esta ruta
        /// <returns></returns>
        /// returna la respuesta positiva en caso de que se la encuentre y negativa si no
        public Boolean produce(String p)
        {
            if (opciones.Contains(p))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
