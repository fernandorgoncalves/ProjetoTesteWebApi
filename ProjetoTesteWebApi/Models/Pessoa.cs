using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using ProjetoTesteWebApi.Controllers;
using System.IO;
using System.Web.Hosting;

namespace ProjetoTesteWebApi.Models
{
    public class Pessoa
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string telefone { get; set; }
        public string cpf { get; set; }

        public List<Pessoa> ListarPessoa()
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");
            var json = File.ReadAllText(caminhoArquivo);
            var listaPessoas = JsonConvert.DeserializeObject<List<Pessoa>>(json);
            return listaPessoas;
        }
        public bool RescreverArquivo(List<Pessoa> listaPessoas)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");

            var json = JsonConvert.SerializeObject(listaPessoas, Formatting.Indented);
            File.WriteAllText(caminhoArquivo, json);
            return true;
        }
        public Pessoa Inserir(Pessoa Pessoa)
        {
            var listaPessoas = this.ListarPessoa();
            var maxId = listaPessoas.Max(prop => prop.id);
            Pessoa.id = maxId + 1;
            listaPessoas.Add(Pessoa);
            RescreverArquivo(listaPessoas);
            return Pessoa;
        }
        public Pessoa Atualizar(int id, Pessoa Pessoa)
        {
            var listaPessoas = this.ListarPessoa();

            var itemIndex = listaPessoas.FindIndex(p => p.id == Pessoa.id);
            if(itemIndex >= 0)
            {
                Pessoa.id = id;
                listaPessoas[itemIndex] = Pessoa;
            }
            else
            {
                return null;
            }
            RescreverArquivo(listaPessoas);
            return Pessoa;
        }
        public bool Deletar(int id)
        {
            var listaPessoas = this.ListarPessoa();

            var itemIndex = listaPessoas.FindIndex(p => p.id == id);
            if(itemIndex >= 0)
            {
                listaPessoas.RemoveAt(itemIndex);
            }
            else
            {
                return false;
            }
            RescreverArquivo(listaPessoas);
            return true;
        }
    }
}