using System.Collections.Generic;
using System;

namespace ComixZone.Classes
{
    public abstract class QuadrinhoBase
    {
        protected int id {get; set;}
        protected string titulo {get; set;}
        protected int ano {get; set;}
        protected string sinopse {get; set;}
        protected List<Genero> generos {get; set;}
        protected List<Autor> roteiristas {get; set;}
        protected List<Autor> ilustradores {get; set;}
        protected TipoQuadrinho tipoQuadrinho {get; set;}
        protected bool excluido {get; set;}

        public virtual string retornaTitulo()
		{
            return this.titulo;
		}
		public int retornaId()
		{
			return this.id;
		}
        public bool retornaExcluido()
		{
			return this.excluido;
		}
        public List<Genero> retornaGeneros()
		{
			return this.generos;
		}
        public List<Autor> retornaIdRoteiristas()
		{
			return this.roteiristas;
		}
        public List<Autor> retornaIdIlustradores()
		{
			return this.ilustradores;
		}
        public TipoQuadrinho retornaTipoQuadrinho()
		{
			return this.tipoQuadrinho;
		}
        public void Excluir() 
        {
            this.excluido = true;
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
            retorno += "Ilustrador(es): " + this.ilustradores + Environment.NewLine;

			return retorno;
		}
    }

}