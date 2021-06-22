using System.Collections.Generic;
using ComixZone.Interfaces;

namespace ComixZone.Classes
{
    public class AutorRepositorio : IRepositorio<Autor>
    {
        public AutorRepositorio()
        {
            this.Insere(new Autor(0,"Desconhecido/Nenhum","---",TipoAutor.Roteirista_e_Ilustrador));
        }

        public void Atualiza(int id, Autor entidade)
        {
            throw new System.NotImplementedException();
        }

        public void Exclui(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insere(Autor entidade)
        {
            throw new System.NotImplementedException();
        }

        public List<Autor> Lista()
        {
            throw new System.NotImplementedException();
        }

        public int ProximoId()
        {
            throw new System.NotImplementedException();
        }

        public Autor RetornaPorId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}