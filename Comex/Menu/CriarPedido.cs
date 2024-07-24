// See https://aka.mensagemBoasVindas/new-console-template for more information
using Comex.Menu;
using Comex.Models;

internal class CriarPedido : Menu
{
    public override void Executar(List<Produto> produtos, List<Pedido> pedidos)
    {
        base.Executar(produtos, pedidos);
        Console.WriteLine("Exibindo todos os produtos registradoss na nossa aplicação");

        Console.WriteLine("Criando um novo pedido\n");

        Console.Write("Digite o nome do cliente: ");
        string nomeCliente = Console.ReadLine()!;
        var cliente = new Cliente();
        cliente.Nome = nomeCliente;

        var pedido = new Pedido(cliente);

        Console.WriteLine("\nProdutos disponíveis:");
        for (int i = 0; i < produtos.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {produtos[i].Nome}");
        }

        Console.Write("Digite o número do produto que deseja adicionar (ou 0 para finalizar): ");
        int numeroProduto = int.Parse(Console.ReadLine()!);

        var produtoEscolhido = produtos[numeroProduto - 1];

        Console.Write("Digite a quantidade: ");
        int quantidade = int.Parse(Console.ReadLine()!);

        var itemDePedido = new ItemDePedido(produtoEscolhido, quantidade, produtoEscolhido.PrecoUnitario);
        pedido.AdicionarItem(itemDePedido);

        Console.WriteLine($"Item adicionado: {itemDePedido}\n");


        pedidos.Add(pedido);

        VoltarMenu();
    }
}