// See https://aka.ms/new-console-template for more information
using Comex.Menus;
using Comex.Modelos;
using Comex.Utils;
using System.Text.Json;

MenuCriarProduto menuCriarProduto = new MenuCriarProduto();
MenuListarProdutos menuListarProdutos = new MenuListarProdutos();
MenuConsyultaApi menuConsyultaApi = new MenuConsyultaApi();
MenuOrdenarProdutos menuOrdenarProdutos = new();


var listaDeProdutos = new List<Produto>
{
    new Produto("Notebook")
    {
        Descricao = "Notebook Dell Inspiron",
        PrecoUnitario = 3500.00,
        Quantidade = 10
    },
    new Produto("Smartphone")
    {
        Descricao = "Smartphone Samsung Galaxy",
        PrecoUnitario = 1200.00,
        Quantidade = 25
    },
    new Produto("Monitor")
    {
        Descricao = "Monitor LG Ultrawide",
        PrecoUnitario = 800.00,
        Quantidade = 15
    },
    new Produto("Teclado")
    {
        Descricao = "Teclado Mecânico RGB",
        PrecoUnitario = 250.00,
        Quantidade = 50
    }
};

var listadePedidos = new List<Pedido>();


string mensagemDeBasVindas = "Boas vindas ao COMEX";

void ExibirLogo()
{
    Console.WriteLine(@"
────────────────────────────────────────────────────────────────────────────────────────
─██████████████─██████████████─██████──────────██████─██████████████─████████──████████─
─██░░░░░░░░░░██─██░░░░░░░░░░██─██░░██████████████░░██─██░░░░░░░░░░██─██░░░░██──██░░░░██─
─██░░██████████─██░░██████░░██─██░░░░░░░░░░░░░░░░░░██─██░░██████████─████░░██──██░░████─
─██░░██─────────██░░██──██░░██─██░░██████░░██████░░██─██░░██───────────██░░░░██░░░░██───
─██░░██─────────██░░██──██░░██─██░░██──██░░██──██░░██─██░░██████████───████░░░░░░████───
─██░░██─────────██░░██──██░░██─██░░██──██░░██──██░░██─██░░░░░░░░░░██─────██░░░░░░██─────
─██░░██─────────██░░██──██░░██─██░░██──██████──██░░██─██░░██████████───████░░░░░░████───
─██░░██─────────██░░██──██░░██─██░░██──────────██░░██─██░░██───────────██░░░░██░░░░██───
─██░░██████████─██░░██████░░██─██░░██──────────██░░██─██░░██████████─████░░██──██░░████─
─██░░░░░░░░░░██─██░░░░░░░░░░██─██░░██──────────██░░██─██░░░░░░░░░░██─██░░░░██──██░░░░██─
─██████████████─██████████████─██████──────────██████─██████████████─████████──████████─
────────────────────────────────────────────────────────────────────────────────────────");
    Console.WriteLine(mensagemDeBasVindas);
}

async Task ExibirOpcoesMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 Criar Produto");
    Console.WriteLine("Digite 2 Listar Produtos");
    Console.WriteLine("Digite 3 Consultar API Externa");
    Console.WriteLine("Digite 4 Ordenar Produtos pelo Título");
    Console.WriteLine("Digite 5 Ordenar Produtos pelo Preço");
    Console.WriteLine("Digite 6 Criar Pedido");
    Console.WriteLine("Digite 7 Listar Pedidos");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            menuCriarProduto.CriarProduto(listaDeProdutos, mensagemDeBasVindas);
            await ExibirOpcoesMenu();
            break;
        case 2:
            menuListarProdutos.ListarProdutos(listaDeProdutos, listadePedidos, mensagemDeBasVindas);
            await ExibirOpcoesMenu();
            break;
        case 3:
            await menuConsyultaApi.ConsultaAPIExternaAsync(listaDeProdutos, listadePedidos, mensagemDeBasVindas);
            await ExibirOpcoesMenu();
            break;
        case 4:
            menuOrdenarProdutos.OrdenarProdutoPeloNome(listaDeProdutos, listadePedidos, mensagemDeBasVindas);
            await ExibirOpcoesMenu();
            break;
        case 5:
            menuOrdenarProdutos.OrdenarProdutosPeloPreco(listaDeProdutos, listadePedidos, mensagemDeBasVindas);
            await ExibirOpcoesMenu();
            break;
        case 6:
            await CriarPedido(listaDeProdutos, listadePedidos, mensagemDeBasVindas);
            break;
        case 7:
            await ListarPedidos(listaDeProdutos, listadePedidos, mensagemDeBasVindas);
            break;
        case -1:
            Console.WriteLine("Tchau tchau :)");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    

    

    

    

    async Task CriarPedido(List<Produto> listaDeProdutos, List<Pedido> listadePedidos, string mensagemDeBasVindas)
    {
        Console.Clear();
        Console.WriteLine("Criando um novo pedido\n");

        Console.Write("Digite o nome do cliente: ");
        string nomeCliente = Console.ReadLine()!;
        var cliente = new Cliente();
        cliente.Nome = nomeCliente;

        var pedido = new Pedido(cliente);

        Console.WriteLine("\nProdutos disponíveis:");
        for (int i = 0; i < listaDeProdutos.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {listaDeProdutos[i].Nome}");
        }

        Console.Write("Digite o número do produto que deseja adicionar (ou 0 para finalizar): ");
        int numeroProduto = int.Parse(Console.ReadLine()!);

        var produtoEscolhido = listaDeProdutos[numeroProduto - 1];

        Console.Write("Digite a quantidade: ");
        int quantidade = int.Parse(Console.ReadLine()!);

        var itemDePedido = new ItemDePedido(produtoEscolhido, quantidade, produtoEscolhido.PrecoUnitario);
        pedido.AdicionarItem(itemDePedido);

        Console.WriteLine($"Item adicionado: {itemDePedido}\n");


        listadePedidos.Add(pedido);
        Console.WriteLine($"\nPedido criado com sucesso:\n{pedido}");

        ConsoleUtil.PausaELimpaATela();
        await ExibirOpcoesMenu();
    }

    async Task ListarPedidos(List<Produto> listaDeProdutos, List<Pedido> listadePedidos, string mensagemDeBasVindas)
    {
        Console.Clear();
        Console.WriteLine("Exibindo todos os produtos registradoss na nossa aplicação");

        var pedidosOrdenados = listadePedidos.OrderBy(p => p.Cliente.Nome).ToList();

        foreach (var Pedido in pedidosOrdenados)
        {
            Console.WriteLine($"Cliente: {Pedido.Cliente.Nome}, Total: {Pedido.Total:F2}");
        }


        ConsoleUtil.PausaELimpaATela();
        await ExibirOpcoesMenu();
    }
}

await ExibirOpcoesMenu();






