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
    public partial class Form1 : Form
    {
        OpenFileDialog opf = new OpenFileDialog();
        controlador mundo = new controlador();
        
        public Form1()
        {
            InitializeComponent();
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            if(opf.ShowDialog()== DialogResult.OK)
            {
                String ruta = opf.FileName;
                cargarGramatica(ruta);
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String matriz= mundo.algortimoCYK(textCadena.Text);
            label3.Text = matriz;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

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
