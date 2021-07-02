using System;
using System.Collections.Generic;

namespace tombola
{
    class Program
    {
        static void Main(string[] args)
        {

            //Scritta di benvenuto da mostrare solo all'inizio
            Console.WriteLine("Benvenuto al gioco della Tombola!!");

            do
            {
                //1. Inserimento dei 15 numeri interi compresi tra 1 e 90
                Console.WriteLine("Per giocare inserisci 15 numeri, compresi tra 1 e 90");
                int[] cartelletta = Tombolata();

                //2. Estrazione numeri random
                Console.WriteLine("Un momento. Sto estraendo i numeri!");
                int[] estrazione = numeriEstratti();

                //3. Controllo vittoria

                Console.WriteLine("Stiamo per scoprire se hai vinto!");
                var risultato = Confronto(cartelletta, estrazione);


                #region Controllo
                if (risultato.Count == 2)
                {
                    Console.WriteLine();
                    Console.WriteLine("Complimenti hai vinto facendo Ambo!\nQuesti sono i tuoi due numeri vincenti!");
                    foreach (int w in risultato)
                    {
                        Console.Write($"{w} - ");
                    }
                }
                else if (risultato.Count == 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Complimenti hai vinto facendo Terno!\nQuesti sono i tuoi tre numeri fortunati!");
                    foreach (int w in risultato)
                    {
                        Console.Write($"{w} - ");
                    }
                }
                else if (risultato.Count == 4)
                {
                    Console.WriteLine();
                    Console.WriteLine("Complimenti hai vinto facendo Quaterna!\nQuesti sono i tuoi quattro numeri vincenti!");
                    foreach (int w in risultato)
                    {
                        Console.Write($"{w} - ");
                    }
                }
                else if (risultato.Count == 5)
                {
                    Console.WriteLine();
                    Console.WriteLine("Complimenti hai vinto facendo Cinquina!\nQuesti sono i tuoi cinque numeri fortunati!");
                    foreach (int w in risultato)
                    {
                        Console.Write($"{w} - ");
                    }
                }
                else if (risultato.Count == 15)
                {
                    Console.WriteLine();
                    Console.WriteLine("Complimenti hai vinto facendo Tombola!!!\nQuesti sono i tuoi numeri!");
                    foreach (int w in risultato)
                    {
                        Console.Write($"{w} - ");
                    }
                    Console.WriteLine("PS. Regalami un po' della tua fortuna!");
                }
                else
                { Console.WriteLine("Mi dispiace. Ma non hai vinto."); }
                #endregion

                //Continua a giocare
                Console.WriteLine("Vuoi rigiocare? Scrivi 'n' per uscire oppure premi un qualsiasi altro tasto per continuare a giocare.");

            }
            while (!(Console.ReadKey().KeyChar == 'n'));
   
            /*------------------------------------*/

            //fase di inserimento dei numeri
            #region Inserimento Numeri
            int[] Tombolata()
            {
                int[] cartella = new int[15];

                for (int i = 0; i < cartella.Length; i++)
                {
                    int numeroScelto;
                    Console.WriteLine($"Inserisci il {i + 1}° numero per compilare la tua cartella");
                    //controllo che i numeri siano tutti interi e compresi tra 1 e 90
                    while (!int.TryParse(Console.ReadLine(), out numeroScelto) || numeroScelto < 1 || numeroScelto > 90)
                    {
                        Console.WriteLine("Errore! Il numero che hai inserito non è compreso tra 1 e 90 (o non è affatto un numero!)\n" +
                            "Ritenta! Inserisci un altro numero!");
                    }
                    cartella[i] = numeroScelto;
               
                }


                Console.WriteLine();
                Console.WriteLine("Grazie per aver inserito i numeri!\nPer ricapitolare, queste sono le tue scelte:");
                foreach (int i in cartella)
                {
                    if (i != 0)
                    {

                        Console.Write($"{i} - ");
                    }
                }
                Console.WriteLine();
                return cartella;

            }
            #endregion


            #region Numeri Estratti
            int[] numeriEstratti()
            {
                int[] numeri = new int[70]; //scelgo quanti numeri estrarre               

                var counter = 0;

                do
                {
                    Random numCasuali = new Random();
                    var r = numCasuali.Next(1, 91);

                    if (Array.IndexOf(numeri, r) == -1)
                    {
                        numeri[counter] = r;
                        counter++;
                    }
                } while (counter < numeri.Length);
                Console.WriteLine();
                return numeri;
            }

            #endregion

            #region Confronto Estrazioni
            List<int> Confronto(int[] utente, int[] cpu)
            {
                var appoggio = new List<int>();

                for (int i = 0; i < utente.Length; i++)
                {
                    for (int j = 0; j < cpu.Length; j++)
                    {
                        if (utente[i] == cpu[j])
                        {
                            appoggio.Add(utente[i]);
                            break;
                        }
                    }
                }
                Console.WriteLine();
                return appoggio;
            }


            #endregion
        }
    }
}
