



public abstract class Programma
{

    public string Nome { get; protected set; }
    public int Durata { get; protected set; }
    public int NumeroGettoni { get; protected set; }

    //usati per i programmi di lavaggio
    public int ConsumoAmmorbidente { get; }
    public int ConsumoDetersivo { get; }

    public Programma(string nome, int durata, int numeroGettoni, int consumoAmmorbidente, int consumoDetersivo)
    {
        Nome = nome;
        Durata = durata;
        NumeroGettoni = numeroGettoni;
        ConsumoAmmorbidente = consumoAmmorbidente;
        ConsumoDetersivo = consumoDetersivo;
    }

 
}