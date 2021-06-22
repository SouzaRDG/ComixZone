using System.Collections.Generic;
using ComixZone.Interfaces;

namespace ComixZone.Classes
{
    public class QuadrinhoRepositorio : IRepositorio<QuadrinhoBase>
    {
        public QuadrinhoRepositorio()
        {
        }

        public void Atualiza(int id, QuadrinhoBase entidade)
        {
            throw new System.NotImplementedException();
        }

        public void Exclui(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insere(QuadrinhoBase entidade)
        {
            throw new System.NotImplementedException();
        }

        public List<QuadrinhoBase> Lista()
        {
            throw new System.NotImplementedException();
        }

        public int ProximoId()
        {
            throw new System.NotImplementedException();
        }

        public QuadrinhoBase RetornaPorId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}