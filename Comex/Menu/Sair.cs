// See https://aka.mensagemBoasVindas/new-console-template for more information
using Comex.Menu;
using Comex.Models;

internal class Sair : Menu
{
    public override void Executar(List<Produto> produtos, List<Pedido> pedidos)
    {
        base.Executar(produtos, pedidos);
        Console.WriteLine("Tchau Tchau");
    }
}