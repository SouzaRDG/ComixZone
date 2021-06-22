using System.Collections.Generic;
using ComixZone.Interfaces;

namespace ComixZone.Classes
{
    public class AutorRepositorio : IRepositorio<Autor>
    {
        private List<Autor> listaAutor = new List<Autor>();
        public AutorRepositorio()
        {
            this.Insere(new Autor(0,"Desconhecido/Nenhum","---",TipoAutor.Roteirista_e_Ilustrador));
        }

        public void Atualiza(int id, Autor entidade)
        {
            listaAutor[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaAutor[id].Excluir();
        }

        public void Insere(Autor entidade)
        {
            listaAutor.Add(entidade);
        }

        public List<Autor> Lista()
        {
            return listaAutor;
        }

        public int ProximoId()
        {
            return listaAutor.Count;
        }

        public Autor RetornaPorId(int id)
        {
            return listaAutor[id];
        }
    }
}