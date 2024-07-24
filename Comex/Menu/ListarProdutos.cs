// See https://aka.mensagemBoasVindas/new-console-template for more information
using Comex.Menu;
using Comex.Models;

internal class ListarProdutos : Menu
{
    public override void Executar(List<Produto> produtos, List<Pedido> pedidos)
    {
        base.Executar(produtos, pedidos);
        Console.WriteLine("Exibindo todos os produtos registradoss na nossa aplicação");

        for (int i = 0; i < produtos.Count; i++)
        {
            Console.WriteLine($"Produto: {produtos[i].Nome}, Preço: {produtos[i].PrecoUnitario:F2}");
        }

        VoltarMenu();
    }
}