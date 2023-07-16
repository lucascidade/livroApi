using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLivro
{
    internal class LivroClient
    {
        private readonly RestClient _livroClient;

        public LivroClient ()
        {
            const string ApiURL = "http://localhost:5132";
            _livroClient = new RestClient(ApiURL);
        }

        public List<Livro> listarLivros()
        {
            var request = new RestRequest(resource: "livros");
            var livros = _livroClient.Get<List<Livro>>(request);

            if(livros.Count == 0 )
            {
               Console.WriteLine("lista de livros está vazia, adicone alguns com a opção 3!");
            }
            return livros;
        }

        public List<Livro> livroPorTitulo (string titulo)
        {
            var request = new RestRequest(resource: "livroPorTitulo")
                .AddQueryParameter("titulo", titulo);

            var livros = _livroClient.Get<List<Livro>>(request);
            return livros;
        }

        public Livro adicionaLivro(Livro livro)
        {
            var request = new RestRequest(resource: "adicionaLivro").
                AddJsonBody(livro);

            var livroAdicionado = _livroClient.Post<Livro>(request);
            return livroAdicionado;
        }

        public void ExcluirLivros ()
        {
            var request = new RestRequest(resource: "livros");
            _livroClient.Delete(request);
        }
    }
}
