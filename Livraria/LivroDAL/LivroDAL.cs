using Livraria.Dominio.arquivos;
using Livraria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Livraria.LivroDAL
{
    public class LivrosDAL
    {
        LivrariaEntities contexto;
        public LivrosDAL() 
        {
            contexto = new LivrariaEntities();
        }    
        public void Inserir(Livro Lvr) 
        {
            contexto.Livro.Add(Lvr);
            contexto.SaveChanges();
        }
        public void deletar(int id) 
        {
            contexto.Livro.Remove(contexto.Livro.Find(id));
            contexto.SaveChanges();
        }
        public List<Livro> Listar() 
        {
            return contexto.Livro.ToList();
        }
        public Livro Selecionar(int Id) 
        {
            return contexto.Livro.FirstOrDefault(x => x.IdLivro == Id);
        }
        public void Atualizar(LivroModel OLvr) 
        {
            
            Livro NLvr = new Livro();
            NLvr = contexto.Livro.Find(OLvr.IdLivro);
            if (NLvr == null)
                return;
            NLvr.IdLivro = OLvr.IdLivro;
            NLvr.Nome = OLvr.Nome;
            NLvr.Preco = OLvr.Preco;
            NLvr.DataPublicacao = OLvr.DataPublicacao;
            contexto.SaveChanges();
            contexto.SaveChanges();
        }
    }
}