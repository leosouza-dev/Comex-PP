﻿using Comex.Modelos;
using Comex.Utils;

namespace Comex.Menus;

public class MenuCriarProduto
{
    public void CriarProduto(List<Produto> listaDeProdutos, string mensagemDeBasVindas)
    {
        Console.Clear();
        Console.WriteLine("Registro de Produto");

        Console.Write("Digite o nome do Produto: ");
        string nomeDoProduto = Console.ReadLine();
        var produto = new Produto(nomeDoProduto);

        Console.Write("Digite a descrição do Produto: ");
        string descricaoDoProduto = Console.ReadLine();
        produto.Descricao = descricaoDoProduto;

        Console.Write("Digite o preço do Produto: ");
        string preçoDoProduto = Console.ReadLine();
        produto.PrecoUnitario = double.Parse(preçoDoProduto);

        Console.Write("Digite a quantidade do Produto: ");
        string quantidadeDoProduto = Console.ReadLine();
        produto.Quantidade = int.Parse(quantidadeDoProduto);

        listaDeProdutos.Add(produto);
        Console.WriteLine($"O Produto {produto.Nome} foi registrado com sucesso!");

        ConsoleUtil.PausaELimpaATela();
    }
}
