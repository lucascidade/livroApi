using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLivro
{
    public class Livro
    {
        public Livro(string titulo, int ano, string edicao)
        {
            Titulo = titulo;
            Ano = ano;
            Edicao = edicao;
        }
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public string Edicao { get; set; }

        public override string ToString()
        {
            return $"Titulo: {Titulo}\nAno: {Ano}\nEdição: {Edicao}\n";
        }
    }
}
