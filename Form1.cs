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
            PrzypisanieIkon();
        }

        Random random = new Random();
        List<string> icons = new List<string>()
    {
        "r", "r", "s", "s", "b", "b", "x", "x",
        "Y", "Y", "N", "N", "(", "(", ")", ")"
    };  // te znaczki są to w "Webdings" znaczki z windowsa
        private void PrzypisanieIkon() //dodawanie losowych ikon z listy
        {
            foreach (Control kontrola in tableLayoutPanel1.Controls) //pętlimy
            {
                Label iconLabel = kontrola as Label;
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
        private void label1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true) 
                return;

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
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;
                konczeniegry(); // sprawdzanie czy gra sie konczy

                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
  
                }

                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;
            firstClicked = null; //resetujemy pierwsszy i drugi klik i od nowa
            secondClicked = null;
        }

    private void konczeniegry()
    {

        foreach (Control kontrola in tableLayoutPanel1.Controls)
        {
            Label iconLabel = kontrola as Label;

            if (iconLabel != null)
            {
                if (iconLabel.ForeColor == iconLabel.BackColor)
                    return;
            }
        }
        MessageBox.Show("Połączyłeś wszystkie ikony, gratulacje!   Twój czas to: " + czass + " sekund!" , "Koniec Gry");
        Close();
    }
        private int czass=0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            czass = czass + 1;
            czas.Text = czass.ToString();
        }
    }
}
