public class Veiculo {


     private string motor;

     private int velocidade;    

     
    public int Locomover(int tempo) {
         Console.WriteLine($"Locomovi com o motor: {tempo}") 
         //$ antes do string é interpolação de string, permite adicionar variavel entre chaves
         retun velocidade/tempo;

    }

}

public class Carro: veiculo {
     
     private int tamanhoPortaMalas;
     
     private string categoria; //Black, confort, x
}

public class Moto:veiculo{

    private bool levaPassageiro;
}