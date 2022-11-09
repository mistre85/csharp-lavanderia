
// il sistema di controllo è il program.cs

public class Lavatrice : Macchina
{   
    public Serbatoio Detersivo { get; private set; }
    public Serbatoio Ammorbidente { get; private set; }

    protected override ProgrammaLavaggio ProgrammaSelezionato
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


    public override bool AvviaProgramma()
    {
        
        if (
           !Detersivo.Disponibile(ProgrammaSelezionato.ConsumoDetersivo) ||
           !Ammorbidente.Disponibile(ProgrammaSelezionato.ConsumoAmmorbidente))
        {
            InFunzione = false;
            return false;
        }

        InFunzione = true;

        GettoniInseriti += ProgrammaSelezionato.NumeroGettoni;
        Detersivo.Consuma(ProgrammaSelezionato.ConsumoDetersivo);
        Ammorbidente.Consuma(ProgrammaSelezionato.ConsumoAmmorbidente);

        //inizializzo sul tempo del programma
        Simulazione(true);

        return true;

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
