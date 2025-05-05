// - Crie uma classe chamada `ContaBancaria` com os atributos privados `numeroConta` e `saldo`. Adicione métodos públicos `Depositar` e `Sacar` para modificar o saldo, e métodos `GetNumeroConta` e `GetSaldo` para acessar os atributos. Teste a classe criando uma instância e realizando algumas operações.

public class ContaBancaria{
    private int numeroConta;
    private int saldo;

    public void SetSaldo(int saldo) {
        this.saldo = saldo;
    }

    public void GetSaldo() {
       Console.WriteLine("Saldo da Conta: " + saldo);
    }

    public void SetNumeroConta(int numeroConta){
        this.numeroConta = numeroConta;  
    }
    public void GetNumeroConta() {
        Console.WriteLine("Numero da conta: " + numeroConta);
    }
    
    public void Depositar(int depositar) {
        this.saldo += depositar;
        Console.WriteLine("Saldo atual (pós-depósito): " + saldo);
    }

    public void Sacar(int sacar) {
        this.saldo -= sacar;
        Console.WriteLine("Saldo atual (pós-sacar): " + saldo);
    }
}



