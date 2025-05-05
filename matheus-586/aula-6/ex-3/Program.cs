// - Crie uma classe base chamada `Animal` com um método virtual `EmitirSom`. Em seguida, crie duas subclasses `Gato` e `Cachorro`, cada uma com sua própria implementação do método `EmitirSom`. Crie instâncias de `Gato` e `Cachorro`, e chame o método `EmitirSom` para cada uma.
// Classe base
public class Animal
{
    public virtual void EmitirSom()
    {
        Console.WriteLine("Som genérico");
    }
}

// Subclasse Gato
public class Gato : Animal
{
    public override void EmitirSom()
    {
        Console.WriteLine("Miau!");
    }
}

// Subclasse Cachorro
public class Cachorro : Animal
{
    public override void EmitirSom()
    {
        Console.WriteLine("Au au!");
    }
}