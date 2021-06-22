using System;
using System.Collections.Generic;

namespace ComixZone.Classes
{
    public class Livro : QuadrinhoBase
    {
        public Livro(int id, string titulo, string sinopse, int ano, List<Genero> generos, 
                            List<Autor> idRoteiristas, TipoQuadrinho tipoQuadrinho)
        {
            this.id = id;
            this.titulo = titulo;
            this.sinopse = sinopse;
            this.generos = generos;
            this.roteiristas = idRoteiristas;
            this.tipoQuadrinho = TipoQuadrinho.Livro;
            this.excluido = false;
        }

                public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Titulo: " + this.titulo + Environment.NewLine;
            retorno += "Ano: " + this.ano + Environment.NewLine;
            retorno += "Gêneros: ";
            foreach(var gen in this.generos)
            {
                retorno += gen.ToString() + "  ";
            }
            retorno += Environment.NewLine;
            retorno += "Sinopse: " + this.sinopse + Environment.NewLine;
            retorno += "Escritor(es): ";
            foreach(var aut in this.roteiristas)
            {
                retorno += aut.ToString() + "  ";
            }

			return retorno;
		}
    }
}