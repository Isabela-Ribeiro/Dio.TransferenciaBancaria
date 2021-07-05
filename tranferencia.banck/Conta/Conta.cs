using System;

namespace tranferencia.banck
{
    public class Conta
    {
        private string Nome{get;set;}
        private double Saldo{get;set;}
        private double Credito{get;set;}
        private TipoConta TipoConta{get; set;}

        public Conta(TipoConta tipoConta,string nome,double saldo,double credito)
        {
            this.TipoConta = tipoConta;
            this.Nome = nome;
            this.Credito = credito;
            this.Saldo = saldo;
        }
        public bool Sacar(double valorSaque)
        {
            if(this.Saldo - valorSaque <(this.Credito * -1)){
                Console.WriteLine("Saldo Insuficiente");

            return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}",this.Nome,this.Saldo);

            return true;
        }
        public void Depositar(double valorDeposito){
            this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome,this.Saldo);
        }

        public void Tranferir(double valorTransferencia, Conta contaDestino )
        {
            if(this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);

            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno +=" Tipo Conta:" + this.TipoConta;
            retorno +="| Nome do Proprietario da conta: " + this.Nome;
            retorno +="| Saldo Atual: " + this.Saldo + "|";
            retorno +=" Credito disponivel: " + this.Credito;

            return retorno;
        }
    }
}