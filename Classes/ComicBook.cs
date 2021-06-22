using System;
using System.Collections.Generic;

namespace ComixZone.Classes
{
    public class ComicBook : QuadrinhoBase
    {
        private int numeroDeVolumes;
        public ComicBook(int id, string titulo, string sinopse, List<Genero> generos, List<Autor> idRoteiristas, 
                            List<Autor> idIlustradores, TipoQuadrinho tipoQuadrinho, int numeroDeVolumes)
        {
            this.id = id;
            this.titulo = titulo;
            this.sinopse = sinopse;
            this.generos = generos;
            this.roteiristas = idRoteiristas;
            this.ilustradores = idIlustradores;
            this.tipoQuadrinho = TipoQuadrinho.Comics;
            this.numeroDeVolumes = numeroDeVolumes;
            this.excluido = false;
        }

        public int retornaNumeroDeVolumes()
		{
			return this.numeroDeVolumes;
		}

                        public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Titulo: " + this.titulo + Environment.NewLine;
            retorno += "Ano: " + this.ano + Environment.NewLine;
            retorno += "Gêneros: " + this.generos + Environment.NewLine;
            retorno += "Sinopse: " + this.sinopse + Environment.NewLine;
            retorno += "Roteiro: " + this.roteiristas + Environment.NewLine;
            retorno += "Ilustração: " + this.ilustradores + Environment.NewLine;

			return retorno;
		}
    }
}