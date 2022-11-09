



public abstract class Programma
{

    public string Nome { get; protected set; }
    public int Durata { get; protected set; }
    public int NumeroGettoni { get; protected set; }

   

    public Programma(string nome, int durata, int numeroGettoni)
    {
        Nome = nome;
        Durata = durata;
        NumeroGettoni = numeroGettoni;
     
    }

 
}