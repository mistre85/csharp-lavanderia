
// il sistema di controllo è il program.cs
public class ProgrammaLavaggio : Programma
{
    //usati per i programmi di lavaggio
    public int ConsumoAmmorbidente { get; }
    public int ConsumoDetersivo { get; }

    public ProgrammaLavaggio(string nome, int durata, 
        int numeroGettoni, int consumoAmmorbidente, int consumoDetersivo) : 
        base(nome, durata, numeroGettoni)
    {
        ConsumoAmmorbidente = consumoAmmorbidente;
        ConsumoDetersivo = consumoDetersivo;
    }

    public override string ToString()
    {
        return "Programma Lavaggio " + Nome;
    }
}
