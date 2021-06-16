using ApiCatalogosJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogosJogos.Repositories
{
    public class JogoRepository : IJogosRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("a735b4aa-5985-4745-a938-9d4d9ac846e8"), new Jogo{ Id = Guid.Parse("a735b4aa-5985-4745-a938-9d4d9ac846e8"), Nome = "Fifa 21", Produtora = "EA", Preco = 200 } },
            {Guid.Parse("1053c45b-7d39-4c5b-8205-593b3c4ef48a"), new Jogo{ Id = Guid.Parse("1053c45b-7d39-4c5b-8205-593b3c4ef48a"), Nome = "Fifa 20", Produtora = "EA", Preco = 180 } },
            {Guid.Parse("1cc46cf8-a875-45a4-ae16-93f26bf78496"), new Jogo{ Id = Guid.Parse("1cc46cf8-a875-45a4-ae16-93f26bf78496"), Nome = "Fifa 19", Produtora = "EA", Preco = 160 } },
            {Guid.Parse("9f0f7a3c-6a27-4010-b8a8-84a44dc3c8a5"), new Jogo{ Id = Guid.Parse("9f0f7a3c-6a27-4010-b8a8-84a44dc3c8a5"), Nome = "Fifa 18", Produtora = "EA", Preco = 140 } },
            {Guid.Parse("e42c42d7-0d51-44e3-8e5f-7a78a865f7eb"), new Jogo{ Id = Guid.Parse("e42c42d7-0d51-44e3-8e5f-7a78a865f7eb"), Nome = "F1 2021", Produtora = "EA", Preco = 250 } },
            {Guid.Parse("a864ceac-fbe4-4532-ae07-90802994c39e"), new Jogo{ Id = Guid.Parse("a864ceac-fbe4-4532-ae07-90802994c39e"), Nome = "Need For Speed", Produtora = "EA", Preco = 190 } }

        };
        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return null;

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task<List<Jogo>> ObterSemLambda(string nome, string produtora)
        {
            var retorno = new List<Jogo>();

            foreach (var jogo in jogos.Values)
            {
                if (jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora))
                    retorno.Add(jogo);
                                
            }
            return Task.FromResult(retorno);
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //Fechar conexão com banco de dados.
        }





    }
}
