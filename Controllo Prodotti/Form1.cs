﻿using System;
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

        private void button1_Click(object sender, EventArgs e)
        {
            //chiamata alla funzione di caricamento, prendendo come parametri da mettere nello struct le stringhe presenti nelle textBox
            caricamento(textBox1.Text, textBox2.Text);

            //chiamata alla funzione di stampa
            stampa();

            //MessageBox per avvisare l'utente del caricamento del prodotto inserito
            MessageBox.Show("Elementi caricati e stampati con successo");

            //Svuotamento della textBox1 per poter inserire ulteriori prodotti
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //chiamata ad una falsa funzione di ricerca che avvisa solamente l'utente dell'esistenza del prodotto inserita
            falsesearch(textBox3.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //chiamata ad una funzione di ricerca che ritorna la posizione di un prodotto inserito dall'utente
            int posizione = search(textBox3.Text);

            //nel caso la posizione sia diversa -1, ovvero che il prodotto esiste, ...
            if (posizione != -1)
            {
                //... richiamo la funzione di cancellamento ...
                canc(posizione);

                //..., stampo nuovamente senza l'elemento ...
                stampa();

                //... e avviso l'utente del cancellamento del prodotto ...
                MessageBox.Show("Elemento cancellato correttamente");
            }
            else //... , altrimenti, ...
            {
                //... avviso l'utente della non esistenza della stringa inserita
                MessageBox.Show("L'elemento non esisteva, non è stato perciò possibile cancellarlo");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //chiamata ad una funzione di ricerca che ritorna la posizione di un prodotto inserito dall'utente
            int posizione = search(textBox3.Text);

            //nel caso la posizione sia diversa -1, ovvero che il prodotto esiste, ...
            if (posizione != -1)
            {
                //... richiamo la funzione di modifica ...
                mod(textBox4.Text, textBox5.Text, posizione);

                //..., stampo nuovamente con l'elemento modificato ...
                stampa();

                //... e avviso l'utente della modifica del prodotto ...
                MessageBox.Show("Elemento modificato correttamente");
            }
            else //... , altrimenti, ...
            {
                //... avviso l'utente della non esistenza della stringa inserita
                MessageBox.Show("L'elemento non esisteva, non è stato perciò possibile modificarlo");
            }

            //Svuotamento delle textBox per poter inserire ulteriori prodotti
            textBox4.Text = "";
            textBox5.Text = "";
        }

        #region funzioni di servizio
        //funzione di caricamento
        static void caricamento(string p, string pr)
        {
            //inserisco il nome e il prezzo del prosotto nello struct
            prodotto.prod[dim] = p;
            prodotto.prezzo[dim] = pr;

            //aumento la dimensione data l'aggiunta di elementi
            dim++;
        }

        //funzione di stampa
        void stampa()
        {
            //pulisco la listview per poter ristampare gli array
            listView1.Items.Clear();

            //stampa degli array nella listview attraverso un ciclo
            for (int i = 0; i < dim; i++)
            {
                listView1.Items.Add(prodotto.prod[i] + " €" + prodotto.prezzo[i]);
            }
        }

        //funzione di avviso di esistenza
        void falsesearch(string nome)
        {
            //ciclo di ricerca sequenziale
            for (int i = 0; i < dim; i++)
            {
                //nel caso venga trovato il prodotto ricercato ...
                if (prodotto.prod[i] == nome)
                {
                    //... avviso l'utente e torno al programma
                    MessageBox.Show("Elemento trovato");
                    return;
                }
            }
            //nel caso non venga trovato nulla, avviso l'utente della non esistenza del prodotto
            MessageBox.Show("Elemento non trovato");
        }

        //funzione di ricerca reale
        int search(string nome)
        {
            //variabile che segna la posizione
            int pos;

            //ciclo di ricerca sequenziale
            for (int i = 0; i < dim; i++)
            {
                //nel caso venga trovato il prodotto ricercato ...
                if (prodotto.prod[i] == nome)
                {
                    //.. la variabile posizione prende il valore dell'indice del ciclo e ...
                    pos = i;

                    //... ritorno il valore di posizione
                    return pos;
                }
            }
            //nel caso il prodotto no0n venga trovato, assegno il valore -1 alla variabile pos e ritrono al programma
            pos = -1;
            return pos;
        }

        //funzione di cancellamento
        void canc(int pos)
        {
            //ciclo di retrocessione degli elementi dalla posizione per il cancellamento
            for (int i = pos; i < dim; i++)
            {
                prodotto.prezzo[i] = prodotto.prezzo[i + 1];
                prodotto.prod[i] = prodotto.prod[i + 1];
            }

            //diminuzione della grandezza degli array dato il cancellamento di uno degli elementi
            dim--;
        }

        //funzione di modifica
        void mod(string nome, string prez, int pos)
        {
            //modifica degli elementi nella posizione trovata dalla funzione di ricerca
            prodotto.prod[pos] = nome;
            prodotto.prezzo[pos] = prez;
        }
        #endregion
    }
}
