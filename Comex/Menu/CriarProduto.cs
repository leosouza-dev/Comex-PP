// See https://aka.mensagemBoasVindas/new-console-template for more information
using Comex.Menu;
using Comex.Models;

internal class CriarProduto : Menu
{
    public override void Executar(List<Produto> produtos,List<Pedido> pedidos)
    {
        base.Executar(produtos,pedidos);
        Console.WriteLine("Registro de Produto");

        Console.Write("Digite o nome do Produto: ");
        string nomeDoProduto = Console.ReadLine()!;
        var produto = new Produto(nomeDoProduto);

        Console.Write("Digite a descrição do Produto: ");
        string descricaoDoProduto = Console.ReadLine()!;
        produto.Descricao = descricaoDoProduto;

        Console.Write("Digite o preço do Produto: ");
        string preçoDoProduto = Console.ReadLine()!;
        produto.PrecoUnitario = double.Parse(preçoDoProduto);

        Console.Write("Digite a quantidade do Produto: ");
        string quantidadeDoProduto = Console.ReadLine()!;
        produto.Quantidade = int.Parse(quantidadeDoProduto);

        produtos.Add(produto);
        Console.WriteLine($"O Produto {produto.Nome} foi registrado com sucesso!");

        VoltarMenu();
    }
}