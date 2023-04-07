using System;
using System.Collections.Generic;
using ProjetoTesteWebApi.Models;
using System.Web.Http;
using System.Linq;

namespace ProjetoTesteWebApi.Controllers
{
    public class PessoaController : ApiController
    {
        // GET: api/Pessoa
        public IEnumerable<Pessoa> Get()
        {
            Pessoa pessoa = new Pessoa();
            return pessoa.ListarPessoa();
        }

        // GET: api/Pessoa/5
        public Pessoa Get(int id)
        {
            Pessoa pessoa = new Pessoa();
            return pessoa.ListarPessoa().Where(x=>x.id==id).FirstOrDefault();
        }

        // POST: api/Pessoa
        public List<Pessoa> Post(Pessoa pessoa)
        {
            Pessoa _pessoa = new Pessoa();
            _pessoa.Inserir(pessoa);
            return _pessoa.ListarPessoa();

        }

        // PUT: api/Pessoa/5
        public Pessoa Put(int id, [FromBody]Pessoa pessoa)
        {
            Pessoa _pessoa = new Pessoa();
            return _pessoa.Atualizar(id, pessoa);
        }

        // DELETE: api/Pessoa/5
        public void Delete(int id)
        {
            Pessoa _pessoa = new Pessoa();
            _pessoa.Deletar(id);
        }
    }
}
