
// il sistema di controllo è il program.cs

using csharp_lavanderia.Exceptions;

public abstract class Macchina
{
    protected Programma[] Programmi { get; set; }

    private int tempoRimanente;

    public virtual Programma ProgrammaSelezionato { get; protected set; }

    public Macchina(int numeroProgrammi)
    {
        Programmi = new Programma[numeroProgrammi];
    }

    public bool InFunzione { get; protected set; }
    public bool Aperta { get; private set; }

    public int GettoniInseriti { get; protected set; }

    public int NumeroProgrammiDisponibili
    {
        get
        {
            return Programmi.Length;
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


    public abstract void AvviaProgramma();

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
    public void SelezionaProgramma(Programma programma = null)
    {
       

        if (InFunzione)
        {
            throw new MacchinaInFunzioneExcption("La macchina è in funzione, impossibile cambiare programma!");
        }

        if (programma == null)
        {
            int numeroProgramma = new Random().Next(0, Programmi.Length - 1);
            ProgrammaSelezionato = Programmi[numeroProgramma];
        }
        else
        {
            ProgrammaSelezionato = programma;
        }

        if (ProgrammaSelezionato.NumeroGettoni > GettoniInseriti)
        {
            throw new GettoniInsufficientiException("Per poter selezionare questo programma c'è biosgno di {0}", ProgrammaSelezionato.NumeroGettoni);
        }

        //quando il programma cambia, possiamo risettare il tempo rimanente del programma
        TempoRimanente = ProgrammaSelezionato.Durata;

    }

    public virtual void Simulazione()
    {
        if (ProgrammaSelezionato == null)
        {
            throw new ProgrammaNonSelezionatoException();
        }

        if (!InFunzione)
        {
            throw new MacchinaInFunzioneExcption();
        }

      
        TempoRimanente = new Random().Next(0, TempoRimanente);


    }


    public virtual void StampaDettaglio()
    {
        StampaStato();

        if (InFunzione)
        {
            Console.WriteLine(ProgrammaSelezionato.ToString());
            Console.WriteLine("Tempo rimanente: {0}", TempoRimanente);
        }

        
    }

    public void StampaStato()
    {
        Console.WriteLine("Stato: {0}, Programma: {1}", InFunzione ? "Occupata" : "Libera", InFunzione ? ProgrammaSelezionato.Nome : "Nessuno");
    }

}
