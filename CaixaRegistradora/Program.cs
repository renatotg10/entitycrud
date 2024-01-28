using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Clear(); // Limpa a tela no início da execução

        Console.WriteLine("Bem-vindo ao Sistema de Venda de Produtos"); // Exibe o nome da aplicação
        Console.WriteLine(new string('-', 40)); // Linha de caracteres '-' repetidos 40 vezes

        int opcao;
        do
        {
            ExibirMenu();
            opcao = LerOpcao();

            switch (opcao)
            {
                case 1:
                    // Opção para "Registrar Venda"
                    Console.Clear();
                    Console.WriteLine("Opção selecionada: Registrar Venda");
                    RegistrarVenda();
                    break;
                case 2:
                    // Opção para "Sair"
                    Console.WriteLine("Obrigado por utilizar o Sistema de Venda de Produtos!");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

        } while (opcao != 2);
    }

    static void ExibirMenu()
    {
        Console.WriteLine("MENU:");
        Console.WriteLine("1. Registrar Venda");
        Console.WriteLine("2. Sair");
        Console.Write("Escolha a opção desejada: ");
    }

    static int LerOpcao()
    {
        return Convert.ToInt32(Console.ReadLine());
    }

    static void RegistrarVenda()
    {
        List<Produto> listaProdutos = new List<Produto>();

        do
        {
            AdicionarProduto(listaProdutos);
        } while (DesejaInserirOutroProduto());

        ExibirRecibo(listaProdutos);

        Console.WriteLine("Digite o valor pago:");
        double valorPago = Convert.ToDouble(Console.ReadLine());

        CalcularTroco(listaProdutos, valorPago);

        Console.WriteLine("Pressione Enter para voltar ao menu...");
        Console.ReadLine(); // Aguarda o Enter antes de voltar ao menu
    }

    static void AdicionarProduto(List<Produto> listaProdutos)
    {
        Console.WriteLine("Digite o nome do produto:");
        string nomeProduto = Console.ReadLine();

        Console.WriteLine("Digite a quantidade:");
        int quantidade = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Digite o valor unitário:");
        double valorUnitario = Convert.ToDouble(Console.ReadLine());

        Produto produto = new Produto(nomeProduto, quantidade, valorUnitario);
        listaProdutos.Add(produto);
    }

    static bool DesejaInserirOutroProduto()
    {
        Console.WriteLine("Deseja inserir outro produto? (S/N)");
        string resposta = Console.ReadLine().ToUpper();
        return resposta == "S";
    }

    static void ExibirRecibo(List<Produto> listaProdutos)
    {
        Console.WriteLine("Lista de Produtos:");
        Console.WriteLine("------------------");

        double totalPagar = 0;

        foreach (var produto in listaProdutos)
        {
            Console.WriteLine($"{produto.Nome} - Quantidade: {produto.Quantidade} - Valor Unitário: {produto.ValorUnitario:C} - Subtotal: {produto.Subtotal:C}");
            totalPagar += produto.Subtotal;
        }

        Console.WriteLine("------------------");
        Console.WriteLine($"Total a Pagar: {totalPagar:C}");
        Console.WriteLine();
    }

    static void CalcularTroco(List<Produto> listaProdutos, double valorPago)
    {
        double totalPagar = 0;

        foreach (var produto in listaProdutos)
        {
            totalPagar += produto.Subtotal;
        }

        if (valorPago < totalPagar)
        {
            Console.WriteLine($"Valor insuficiente! Faltam: {(totalPagar - valorPago):C}");
        }
        else
        {
            double troco = valorPago - totalPagar;
            Console.WriteLine($"Troco a devolver: {troco:C}");
        }
    }
}

class Produto
{
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public double ValorUnitario { get; set; }

    public Produto(string nome, int quantidade, double valorUnitario)
    {
        Nome = nome;
        Quantidade = quantidade;
        ValorUnitario = valorUnitario;
    }

    public double Subtotal
    {
        get { return Quantidade * ValorUnitario; }
    }
}
