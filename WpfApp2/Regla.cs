using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class Regla
    {
        private Char referencia;
        private List<string> opciones; 

        public Regla(char refe, List<String> opc)
        {
            referencia = refe;
            opciones = opc;
        }
        public Char refere { get { return referencia; } set { referencia = value; } }

        public String reglaToString()
        {
            String regla =referencia + " -->" ;
            foreach(var o in opciones)
            {
                regla += o + " | ";
            }


            return regla;
        }
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
