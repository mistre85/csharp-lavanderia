using csharp_lavanderia.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace csharp_lavanderia
{

    public class Cliente
    {

        private static int _codice = 0;
        public int Codice { get; }

        public int Gettoni { get; private set; }

        public string Stato { get; private set; }

        public bool PanniSporchi { get; set; }
        public bool PanniBagnati { get; set; }

        //si suppone per semplicità che un 
        public Cliente()
        {
            _codice++;
            Codice = _codice;
            Gettoni = new Random().Next(1, 10);
          
        }

        //l'utente deve 
        //apire la lavatrice
        //selezionare il lavaggio
        //chiudere la lavatrice
        //inserire i gettoni
        //avviare il lavaggio
        //controllare quando il lavaggio finisce
        //se il lavaggio è finito deve aprire la macchina
        //prendere i panni puliti
        //chiudere la macchina

        //ripetere il processo per l'asciugatrice
        //l'utente deve 
        //apire l'asciugatrice
        //selezionare il lavaggio
        //chiudere la lavatrice
        //avviare il lavaggio
        //controllare quando il lavaggio finisce
        //se il lavaggio è finito deve aprire la macchina
        //prendere i panni puliti
        //chiudere la macchina

        public void Usa(Macchina macchina)
        {
            switch (Stato)
            {
                case "CERCA_MACCHINA":

                    break;
                case "PANNI_BAGNATI":
                    break;
                case "APRI_MACCHINA":

                   
                        macchina.Apri();
                        Stato = "SELEZIONA_PROGRAMMA";
                    break;

                case "CHIUDI_MACCHINA":

                    macchina.Chiudi();
                    Stato = "AVVIA_PROGRAMMA";
                    break;

                case "AVVIA_PROGRAMMA":


                    try
                    {
                        macchina.AvviaProgramma();
                        Stato = "ATTESA_TERMINE_PROGRAMMA";
                    }
                    catch (MacchinaInFunzioneExcption)
                    {

                        Stato = "RICERCA_LAVATRICE";
                    }
                    
                    break;

                case "SELEZIONA_PROGRAMMA":

                    try
                    {
                        macchina.SelezionaProgramma();
                        Stato = "CHIUDI_MACCHINA";

                    }
                    catch (GettoniInsufficientiException)
                    {
                        Stato = "INSERISCI_GETTONI";
                    }

                    break;

                case "INSERISCI_GETTONI":

                    if (Gettoni < macchina.ProgrammaSelezionato.NumeroGettoni)
                    {
                        throw new GettoniInsufficientiException($"Il cliente {Codice} non ha abbstanza gettoni per il programma {macchina.ProgrammaSelezionato.Nome}");
                    }

                    macchina.InserisciGettoni(macchina.ProgrammaSelezionato.NumeroGettoni);
                    Gettoni -= macchina.ProgrammaSelezionato.NumeroGettoni;

                    Stato = "SELEZIONA_PROGRAMMA";
                    break;
            }
        }
    }

    


    
}
