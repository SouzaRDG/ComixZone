using System;

namespace ComixZone.Classes
{
    public class Autor
    {
        protected int id {get; set;}
        protected string nome {get; set;}
        protected string bio {get; set;}
        protected TipoAutor tipoAutor {get; set;}
        protected bool excluido {get; set;}

        public Autor(int id, string nome, string bio, TipoAutor tipoAutor)
        {
            this.id = id;
            this.nome = nome;
            this.bio = bio;
            this.tipoAutor = tipoAutor;
            this.excluido = false;
        }

        public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Nome: " + this.nome + Environment.NewLine;
            retorno += this.tipoAutor + Environment.NewLine;
            retorno += "Bio: " + this.bio + Environment.NewLine;
			return retorno;
		}

        public string retornaNome()
		{
			return this.nome;
		}
		public int retornaId()
		{
			return this.id;
		}
        public bool retornaExcluido()
		{
			return this.excluido;
		}
        public void Excluir() 
        {
            this.excluido = true;
        }
    }
}