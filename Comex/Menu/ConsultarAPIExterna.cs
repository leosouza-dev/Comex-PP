// See https://aka.mensagemBoasVindas/new-console-template for more information
using System.Text.Json;
using Comex.Menu;
using Comex.Models;

internal class ConsultarAPIExterna : Menu
{
    public async override void Executar(List<Produto> produtos, List<Pedido> pedidos)
    {
        base.Executar(produtos, pedidos);
         using (HttpClient client = new HttpClient())
        {
            try
            {
                string resposta = await client.GetStringAsync("http://fakestoreapi.com/products");
                var produtosDeserializados = JsonSerializer.Deserialize<List<Produto>>(resposta)!;
                for (int i = 0; i < produtos.Count; i++)
                {
                    Console.WriteLine($"Nome: {produtosDeserializados[i].Nome}, " +
                        $"Descrição: {produtosDeserializados[i].Descricao}, " +
                        $"Preço {produtosDeserializados[i].PrecoUnitario} \n");
                }
                VoltarMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Temos um problema: {ex.Message}");
            }
        }

        VoltarMenu();
    }
}