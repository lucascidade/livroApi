
using ConsoleLivro;


var livroClient = new LivroClient();

do
{
    Console.WriteLine("-----------------API DE LIVROS --------------------");
    Console.WriteLine("1 - Listar Todos os Livros");
    Console.WriteLine("2 - Buscar livro por NOME");
    Console.WriteLine("3 - Adicona novo livro");
    Console.WriteLine("4 - Excluir todos os livros");
    Console.WriteLine("5 - Sair");
    Console.WriteLine("____________________________________________________");
    Console.WriteLine("");
    Console.WriteLine("Escolha uma opção: ");

    var opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            var livros = livroClient.listarLivros();
            livros.ForEach(l => Console.WriteLine(l.ToString()));
            continue;
        case "2":
            Console.WriteLine("Digite o nome do livro para realizarmos a busca: ");
            var nomeLivro = Console.ReadLine();
            var livro = livroClient.livroPorTitulo(nomeLivro);
            livro.ForEach(busca => Console.WriteLine(busca.ToString()));
            continue;
        case "3":
            Console.WriteLine("Digite o nome do livro que deseja adiconar: ");
            var nomLivro = Console.ReadLine();
            Console.WriteLine("Digite o ano que este livro foi lançado: ");
            var anoLivro = Console.ReadLine();
            Console.WriteLine("Digite a edicao deste livro: ");
            var edicaoLivro = Console.ReadLine();

            var livroCriado = new Livro(nomLivro, int.Parse(anoLivro), edicaoLivro);
            var livroAdicionado = livroClient.adicionaLivro(livroCriado);

            Console.WriteLine("Livro CRIADO COM SUCESSO");
            Console.WriteLine(livroAdicionado.ToString());
            continue;
        case "4":
            livroClient.ExcluirLivros();
            Console.WriteLine("Livros excluidos!");
            continue;
        case "5":
            System.Environment.Exit(0);
            break;

        default:
            break;

    }
} while (true);

