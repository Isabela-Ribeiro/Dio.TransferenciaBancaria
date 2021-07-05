
using System;
using System.Collections.Generic;

namespace tranferencia.banck
{
    class Program
    {
        static List<Conta> listaConta = new List<Conta>();
        static void Main(string[] args)
        {
           string opc = Menu();

           while(opc.ToUpper() != "x"){
               switch(opc)
               {
                case "1":
                    ListarContas();
                break;
                case "2":
                    InserirConta();
                break;
                case "3":
                    Transferirencia();
                break;
                case "4":
                    Sacar();
                break;
                case "5":
                    Depositar();
                break;
                case "6":
                Console.Clear();
                break;
                
                default:
                throw new ArgumentOutOfRangeException();
              
               }
               opc = Menu();
           }
           Console.ReadLine();
        }
        private static string Menu(){
            Console.WriteLine("Bem Vindo!");

            Console.WriteLine("Escolha uma opção do menu");
            Console.WriteLine("1 - Listar Conta");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Tranferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("6 - Limpar Tela");
            Console.WriteLine("x - Sair");

            string opc = Console.ReadLine().ToUpper();

            return opc;
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Digite o nome do cliente:");
            string nomeCliente = Console.ReadLine();

            Console.WriteLine("Escolha o tipo de conta: 1 - Pessoa Fisica ou 2 - Pessoa Juridica:");
            int escolhaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o saldo inicial:");
            double saldoInicial = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o credit: ");
            double creditoInicial = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(
                tipoConta: (TipoConta)escolhaTipoConta,
                saldo: saldoInicial,
                credito: creditoInicial,
                nome: nomeCliente
                );

            listaConta.Add(novaConta);
        }
        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");

            if(listaConta.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }

            for(int i = 0;i< listaConta.Count; i++)
            {
                Conta conta = listaConta[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void Transferirencia()
        {
            Console.WriteLine("Tranferir");

            Console.WriteLine("Digite o numero da conta:");
            int indiceConta =int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a conta que será tranferido:");
            int contaTransfere = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido; ");
            double valorTransfere = double.Parse(Console.ReadLine());

           listaConta[indiceConta].Tranferir(valorTransfere, listaConta[contaTransfere]);
        }
        private static void Sacar()
        {
            Console.WriteLine("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaConta[indiceConta].Sacar(valorSaque);
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser Depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaConta[indiceConta].Depositar(valorDeposito);
        }
    }
}
