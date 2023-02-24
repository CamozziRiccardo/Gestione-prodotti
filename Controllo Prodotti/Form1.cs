using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controllo_Prodotti
{
    public partial class Form1 : Form
    {
        public struct Prodotto
        {
            public string[] prod;
            public string[] prezzo;
        }

        public static int dim;

        public static Prodotto prodotto = new Prodotto();

        public Form1()
        {
            InitializeComponent();
            dim = 0;
            prodotto.prod = new string[100];
            prodotto.prezzo = new string[100];
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            caricamento(textBox1.Text, textBox2.Text);
            stampa();
            MessageBox.Show("Elementi caricati e stampati con successo");
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            falsesearch(textBox3.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int posizione = search(textBox3.Text);
            if (posizione != -1)
            {
                canc(posizione);
                stampa();
                MessageBox.Show("Elemento cancellato correttamente");
            }
            else
            {
                MessageBox.Show("L'elemento non esisteva, non è stato perciò possibile cancellarlo");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int posizione = search(textBox3.Text);
            if (posizione != -1)
            {
                mod(textBox4.Text, textBox5.Text, posizione);
                stampa();
                MessageBox.Show("Elemento modificato correttamente");
            }
            else
            {
                MessageBox.Show("L'elemento non esisteva, non è stato perciò possibile modificarlo");
            }
            textBox4.Text = "";
            textBox5.Text = "";
        }

        //funzioni di servizio
        static void caricamento(string p, string pr)
        {
            prodotto.prod[dim] = p;
            prodotto.prezzo[dim] = pr;
            dim++;
        }

        void stampa()
        {
            listView1.Items.Clear();
            for (int i = 0; i < dim; i++)
            {
                listView1.Items.Add(prodotto.prod[i] + " €" + prodotto.prezzo[i]);
            }
        }

        void falsesearch(string nome)
        {
            for (int i = 0; i < dim; i++)
            {
                if (prodotto.prod[i] == nome)
                {
                    MessageBox.Show("Elemento trovato");
                    return;
                }
            }
            MessageBox.Show("Elemento non trovato");
        }

        int search(string nome)
        {
            int pos;
            for (int i = 0; i < dim; i++)
            {
                if (prodotto.prod[i] == nome)
                {
                    pos = i;
                    return pos;
                }
            }
            pos = -1;
            return pos;
        }

        void canc(int pos)
        {
            for (int i = pos; i < dim; i++)
            {
                prodotto.prezzo[i] = prodotto.prezzo[i + 1];
                prodotto.prod[i] = prodotto.prod[i + 1];
            }
            dim--;
        }

        void mod(string nome, string prez, int pos)
        {
            prodotto.prod[pos] = nome;
            prodotto.prezzo[pos] = prez;
        }
    }
}
