
// il sistema di controllo è il program.cs

using ConsoleTables;
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

    public Lavatrice(int numero) : base(numero, 3)
    {
        Numero = numero;
       
        Detersivo = new Serbatoio(new Random().Next(1000),1000);
        Ammorbidente = new Serbatoio(new Random().Next(500),1000);

        ListaProgrammi[0] = new ProgrammaLavaggio(1,"Rifrescante", 20, 5, 20, 25);
        ListaProgrammi[1] = new ProgrammaLavaggio(2,"Rinnovante", 40, 10, 40, 50);
        ListaProgrammi[2] = new ProgrammaLavaggio(3,"Sgrassante", 60, 15, 60, 100);

    }

    protected override void _avvia()
    {
        if (!Detersivo.Disponibile(ProgrammaSelezionato.ConsumoDetersivo))
        {
            throw new DetersivoInsufficienteException();
        }

        if (!Ammorbidente.Disponibile(ProgrammaSelezionato.ConsumoAmmorbidente))
        {
            throw new AmmorbidenteInsufficienteException();
        }

        Detersivo.Consuma(ProgrammaSelezionato.ConsumoDetersivo);
        Ammorbidente.Consuma(ProgrammaSelezionato.ConsumoAmmorbidente);
       
    }


    public override string TabellaProgrammiToString()
    {

        var table = new ConsoleTable("Numero programma", "Nome programma", "Durata", "Gettoni","Consumo Ammorbidente","Consumo Detersivo");

        foreach (ProgrammaLavaggio programma in ListaProgrammi)
        {
            table.AddRow(
                programma.Numero,
                programma.Nome,
                programma.Durata,
                programma.NumeroGettoni,
                programma.ConsumoAmmorbidente,
                programma.ConsumoDetersivo);
        }

        return table.ToString();


    }
}
