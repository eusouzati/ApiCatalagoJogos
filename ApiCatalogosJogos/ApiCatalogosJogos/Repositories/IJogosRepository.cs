using ApiCatalogosJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogosJogos.Repositories
{
    public interface IJogosRepository : IDisposable
    {
        Task<List<Jogo>> Obter(int pagina, int qualidade);
        Task<Jogo> Obter(Guid Id);
        Task<List<Jogo>> Obter(string nome, string produtora);
        Task Inserir(Jogo jogo);
        Task Atualizar(Jogo jogo);
        Task Remover(Guid id);
    }
}
