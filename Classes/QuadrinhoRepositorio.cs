using System.Collections.Generic;
using ComixZone.Interfaces;

namespace ComixZone.Classes
{
    public class QuadrinhoRepositorio : IRepositorio<QuadrinhoBase>
    {
        private List<QuadrinhoBase> listaQuadrinhos = new List<QuadrinhoBase>();
        public void Atualiza(int id, QuadrinhoBase entidade)
        {
            listaQuadrinhos[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaQuadrinhos[id].Excluir();
        }

        public void Insere(QuadrinhoBase entidade)
        {
            listaQuadrinhos.Add(entidade);
        }

        public List<QuadrinhoBase> Lista()
        {
            return listaQuadrinhos;
        }

        public int ProximoId()
        {
            return listaQuadrinhos.Count;
        }

        public QuadrinhoBase RetornaPorId(int id)
        {
            return listaQuadrinhos[id];
        }
    }
}