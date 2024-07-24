// See https://aka.mensagemBoasVindas/new-console-template for more information
using Comex.Menu;
using Comex.Models;

internal class ListarPedidos : Menu
{
    public override void Executar(List<Produto> produtos, List<Pedido> pedidos)
    {
        base.Executar(produtos, pedidos);

        Console.WriteLine("Exibindo todos os produtos registrados na nossa aplicação");

        var pedidosOrdenados = pedidos.OrderBy(p => p.Cliente.Nome).ToList();

        foreach (var Pedido in pedidosOrdenados)
        {
            Console.WriteLine($"Cliente: {Pedido.Cliente.Nome}, Total: {Pedido.Total:F2}");
        }

        VoltarMenu();
    }
}