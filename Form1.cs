using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Gierka
{
    public partial class Form1 : Form
    {
        Label firstClicked = null;
        Label secondClicked = null;
        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }

        Random random = new Random();
        List<string> icons = new List<string>()
    {
        "r", "r", "s", "s", "b", "b", "x", "x",
        "Y", "Y", "N", "N", "(", "(", ")", ")"
    };  // te znaczki są to w "Webdings" znaczki z windowsa
        private void AssignIconsToSquares() //dodawanie losowych ikon z listy
        {
            foreach (Control control in tableLayoutPanel1.Controls) //pętlimy
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor; // ukrywa ikony
                    icons.RemoveAt(randomNumber);
                }
            }
        }




        private void Form1_Load(object sender, EventArgs e)
        {

        }
        // po kliknięciu na puste pole ukazuje nam się ikonka
        private void label1_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;
                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }
            }
        }
    }
}
