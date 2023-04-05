
// il sistema di controllo è il program.cs

using ConsoleTables;
using csharp_lavanderia.Exceptions;
using System.Reflection.PortableExecutable;

public abstract class Macchina
{

    public int Numero { get; protected set; }

    public Programma[] ListaProgrammi { get; protected set; }

    public virtual Programma ProgrammaSelezionato { get; protected set; }

    private int tempoRimanente;

    public Macchina(int numero, int numeroProgrammi)
    {
        Numero = numero;
        ListaProgrammi = new Programma[numeroProgrammi];

        //creiamo un pò di entropia
        Aperta = new Random().Next(2) == 1;
        GettoniInseriti = new Random().Next(5);
        
    }

    public bool InFunzione { get; protected set; }
    public bool Aperta { get; private set; }

    public int GettoniInseriti { get; protected set; }

    public int NumeroProgrammiDisponibili
    {
        get
        {
            return ListaProgrammi.Length;
        }
    }

    public int TempoRimanente
    {
        get
        {
            return tempoRimanente;
        }

        private set
        {
            if (value == 0)
            {
                tempoRimanente = 0;
                InFunzione = false;
                //ProgrammaSelezionato = null;
            }
            else
            {
                tempoRimanente = value;
            }
        }

    }


    public void Avvia()
    {
        if (Aperta)
        {
            throw new MacchinaApertaException("La macchina è aperta, impossibile avviare!");
        }

        if (InFunzione)
        {
            throw new MacchinaInFunzioneExcption("La macchina è già in funzione! Terminare il programma e riprovare!");
        }

        if (ProgrammaSelezionato == null)
        {
            throw new ProgrammaNonSelezionatoException("Programma non selezionato, impossibile avviare!");
        }

        if (ProgrammaSelezionato.NumeroGettoni > GettoniInseriti)
        {
            throw new GettoniInsufficientiException("I gettoni inseriti non sono sufficienti per avviare il programma selezionato");
        }

        //?? potremmo anche dire che, essendo classe astratta
        //questo caricamento dovrebbero deciderlo i figli in caso di override
        _avvia();
    }

    protected virtual void _avvia()
    { 
        //comportamento di default di tutte le macchine (compresa asciugatrice)
        InFunzione = true;
        GettoniInseriti -= ProgrammaSelezionato.NumeroGettoni;
    }


    public void Ferma()
    {
        InFunzione = false;
    }

    public void Apri()
    {
        if (InFunzione)
        {
            throw new MacchinaInFunzioneExcption("La macchina è in funzione, impossibile aprire!");
        }

        Aperta = true;
    }

    public void Chiudi()
    {
        Aperta = false;
    }


    public void InserisciGettoni(int numeroGettoni)
    {
        GettoniInseriti += numeroGettoni;
    }

    //selezione e avvio
    public void SelezionaProgramma(int numeroProgramma)
    {
        //mi serve per tradurre il numero programma umano
        //con quello dell'indice dell'array
        numeroProgramma--;


        //controllo che il programma sia valido
        if (numeroProgramma >= ListaProgrammi.Length|| numeroProgramma <0)
        {
            throw new ProgrammaSelezionatoInesistenteException("Il programma selezionato è inesistente");
        }


        if (InFunzione)
        {
            throw new MacchinaInFunzioneExcption("La macchina è in funzione, impossibile cambiare programma!");
        }

        ProgrammaSelezionato = ListaProgrammi[numeroProgramma];

    }

    public abstract string TabellaProgrammiToString();

   
}
