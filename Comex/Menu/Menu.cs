using Comex.Models;

namespace Comex.Menu;

internal class Menu
{
    public void LimparConsoleAdicionarTitulo()
    {
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine($"\n------------- Sistema COMEX -------------\n");
    }

    public async virtual void Executar(List<Produto> produtos, List<Pedido> pedidos)
    {
        LimparConsoleAdicionarTitulo();
    }

    public void VoltarMenu()
    {
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
