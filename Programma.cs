



public abstract class Programma
{

    public int Numero { get; protected set; }
    public string Nome { get; protected set; }
    public int Durata { get; protected set; }
    public int NumeroGettoni { get; protected set; }

   

    public Programma(int numero, string nome, int durata, int numeroGettoni)
    {
        Numero = numero;
        Nome = nome;
        Durata = durata;
        NumeroGettoni = numeroGettoni;
     
    }

 
}