using System;
using System.Collections.Generic;

namespace ComixZone.Classes
{
    public class Livro : QuadrinhoBase
    {
        public Livro(int id, string titulo, string sinopse, List<Genero> generos, 
                            List<Autor> idRoteiristas, List<Autor> idIlustradores, TipoQuadrinho tipoQuadrinho)
        {
            this.id = id;
            this.titulo = titulo;
            this.sinopse = sinopse;
            this.generos = generos;
            this.roteiristas = idRoteiristas;
            this.ilustradores = idIlustradores;
            this.tipoQuadrinho = TipoQuadrinho.Livro;
            this.excluido = false;
        }

                public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Titulo: " + this.titulo + Environment.NewLine;
            retorno += "Ano: " + this.ano + Environment.NewLine;
            retorno += "Gêneros: " + this.generos + Environment.NewLine;
            retorno += "Sinopse: " + this.sinopse + Environment.NewLine;
            retorno += "Escritor(es): " + this.roteiristas + Environment.NewLine;

			return retorno;
		}
    }
}