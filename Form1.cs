using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gierka
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        Random random = new Random();
        List<string> icons = new List<string>()
    {
        "r", "r", "s", "s", "b", "b", "x", "x",
        "Y", "Y", "N", "N", "(", "(", ")", ")"
    };  // te znaczki są to w "Webdings" znaczki z windowsa
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
