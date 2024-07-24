// See https://aka.mensagemBoasVindas/new-console-template for more information
using Comex.Menu;
using Comex.Models;

internal class OrdenarProdutosPeloPreco : Menu
{
    public override void Executar(List<Produto> produtos, List<Pedido> pedidos)
    {
        base.Executar(produtos, pedidos);
        Console.WriteLine("Exibindo todos os produtos registradoss na nossa aplicação");

        var produtosOrdenadosPorPreco = produtos.OrderBy(p => p.PrecoUnitario).ToList();
        Console.Clear();
        Console.WriteLine("Produtos ordenados pelo preço:");
        for (int i = 0; i < produtosOrdenadosPorPreco.Count; i++)
        {
            Console.WriteLine($"Produto: {produtosOrdenadosPorPreco[i].Nome}, Preço: {produtosOrdenadosPorPreco[i].PrecoUnitario:F2}");
        }

        VoltarMenu();
    }
}