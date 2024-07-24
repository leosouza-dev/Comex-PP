// See https://aka.mensagemBoasVindas/new-console-template for more information
using Comex.Menu;
using Comex.Models;

internal class OrdenarProdutosPeloTitulo : Menu
{
    public override void Executar(List<Produto> produtos, List<Pedido> pedidos)
    {
        base.Executar(produtos, pedidos);
        Console.WriteLine("Exibindo todos os produtos registradoss na nossa aplicação");

        var produtosOrdenados = produtos.OrderBy(p => p.Nome).ToList();
        Console.Clear();
        Console.WriteLine("Produtos ordenados pelo título:");
        for (int i = 0; i < produtosOrdenados.Count; i++)
        {
            Console.WriteLine($"Produto: {produtosOrdenados[i].Nome}, Preço: {produtosOrdenados[i].PrecoUnitario:F2}");
        }

        VoltarMenu();
    }
}