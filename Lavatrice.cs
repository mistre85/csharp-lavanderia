
// il sistema di controllo è il program.cs

using csharp_lavanderia.Exceptions;

public class Lavatrice : Macchina
{   
    public Serbatoio Detersivo { get; private set; }
    public Serbatoio Ammorbidente { get; private set; }

    public override ProgrammaLavaggio ProgrammaSelezionato
    {
        get
        {
            return (ProgrammaLavaggio)base.ProgrammaSelezionato;
        }
    }

    public Lavatrice() : base(3)
    {
        this.
        Detersivo = new Serbatoio(1000);
        Ammorbidente = new Serbatoio(500);

        Programmi[0] = new ProgrammaLavaggio("Rifrescante",20,5,20,2);
        Programmi[1] = new ProgrammaLavaggio("Rinnovante",40,10,40,3);
        Programmi[2] = new ProgrammaLavaggio("Sgrassante",60,15,60,4);

    }


    public override void AvviaProgramma()
    {

        if (Aperta)
        {
            throw new MacchinaApertaException();
        }

        if (InFunzione)
        {
            throw new MacchinaInFunzioneExcption();
        }

        if (ProgrammaSelezionato == null)
        {
            throw new ProgrammaNonSelezionatoException();
        }

        if(ProgrammaSelezionato.NumeroGettoni > GettoniInseriti)
        {
            throw new GettoniInsufficientiException();
        }

        if (!Detersivo.Disponibile(ProgrammaSelezionato.ConsumoDetersivo))
        {
            throw new DetersivoInsufficienteException();
        }

        if (!Ammorbidente.Disponibile(ProgrammaSelezionato.ConsumoAmmorbidente))
        {
            throw new AmmorbidenteInsufficienteException();
        }


        InFunzione = true;
        GettoniInseriti -= ProgrammaSelezionato.NumeroGettoni;

    }

    public override void Simulazione()
    {
        base.Simulazione();

        Detersivo.Consuma(ProgrammaSelezionato.ConsumoDetersivo);
        Ammorbidente.Consuma(ProgrammaSelezionato.ConsumoAmmorbidente);

        
    }

    public override void StampaDettaglio()
    {
        StampaStato();

        base.StampaDettaglio();

        Console.WriteLine("Ammorbidente disponibile: {0}", Ammorbidente.Livello);
        Console.WriteLine("Detersivo disponibile: {0}", Detersivo.Livello);
        Console.WriteLine("Numero Gettoni: {0}", GettoniInseriti);

    }
}
