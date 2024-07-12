﻿using Comex.Modelos;
using Comex.Utils;

namespace Comex.Menus;

public class MenuListarProdutos
{
    public void ListarProdutos(List<Produto> listaDeProdutos, List<Pedido> listadePedidos, string mensagemDeBasVindas)
    {
        Console.Clear();

        //ExibirTituloDaOpcao("Exibindo todos os produtos registradoss na nossa aplicação");
        Console.WriteLine("Exibindo todos os produtos registradoss na nossa aplicação");

        for (int i = 0; i < listaDeProdutos.Count; i++)
        {
            Console.WriteLine($"Produto: {listaDeProdutos[i].Nome}, Preço: {listaDeProdutos[i].PrecoUnitario:F2}");
        }


        ConsoleUtil.PausaELimpaATela();
    }
}
