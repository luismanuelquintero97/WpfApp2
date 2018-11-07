using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    // calse form con los botones, textbox y labels
    public partial class Form1 : Form
    {
        //extencion para conecer la ruta de la gramatica
        OpenFileDialog opf = new OpenFileDialog();
        //intancia del mundo
        controlador mundo = new controlador();
        

        /// <summary>
        /// contructor de la interfaz
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
      
        /// <summary>
        /// metodo que obtiene la ruta del texto plano y lo envia a la carga de la gramatica
        /// </summary>
        /// <param name="sender"></param>
        /// no lo se muy bien 
        /// <param name="e"></param>
        /// extension para manejar los eventos
        private void button1_Click(object sender, EventArgs e)
        {
            if(opf.ShowDialog()== DialogResult.OK)
            {
                String ruta = opf.FileName;
                cargarGramatica(ruta);
                
            }
        }

        /// <summary>
        /// metodo que llamara el algoritmoCYK del mundo 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            String matriz= mundo.algortimoCYK(textCadena.Text);
            label3.Text = matriz;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// metodod que llama a la carga de la gramatica en el mundo, tambien canbia el text para mostrar la gramatica
        /// </summary>
        /// <param name="ruta"></param>
        public void cargarGramatica(String ruta)
        {
            Console.WriteLine(ruta);
            mundo.cargarGramatica(ruta);
            label2.Text= mundo.gramaticaToString();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
