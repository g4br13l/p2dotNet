using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Livraria.Models;

namespace Livraria.Controllers
{
    public class LivroController : Controller
    {
        private LivrariaContext db = new LivrariaContext();

        //
        // GET: /Livro/

        public JsonResult Index()
        {
            List<Object> obj = new List<object>();

            List<Dominio.arquivos.Livro> livros = new LivroDAL.LivrosDAL().Listar();
            foreach (Dominio.arquivos.Livro lv in livros)
            {
                obj.Add(new
                {
                    Id = lv.IdLivro.ToString(),
                    Nome = lv.Nome.ToString(),
                    Preco = lv.Preco.ToString(),
                    DataPublicacao = lv.DataPublicacao.ToString(),

                });

            }
            return Json(obj, JsonRequestBehavior.AllowGet);

        }

        //
        // GET: /Livro/Details/5

        public JsonResult Details(int id = 0)
        {
            Dominio.arquivos.Livro livromodel = new LivroDAL.LivrosDAL().Selecionar(id);
            var ob = new{ Nome = livromodel.Nome.ToString(), Preco = livromodel.Preco.ToString(), DataPublicacao = livromodel.DataPublicacao.ToString() };
            return Json(ob, JsonRequestBehavior.AllowGet);      
        }

        //
        // GET: /Livro/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Livro/Create

        [HttpPost]
        public void Create(LivroModel livromodel)
        {
            new LivroDAL.LivrosDAL().Inserir(new Dominio.arquivos.Livro()
            {
                Nome = livromodel.Nome,
                Preco = livromodel.Preco,
                DataPublicacao = livromodel.DataPublicacao,
            });


            //return RedirectToAction("Index");
        }

        //
        // GET: /Livro/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var objDao = new LivroDAL.LivrosDAL().Selecionar(id);
            return View(new Models.LivroModel()
            {
                Nome = objDao.Nome,
                Preco = objDao.Preco,
                DataPublicacao = objDao.DataPublicacao
            });
        }            
            
        //
        // POST: /Livro/Edit/5

        [HttpPost]
        public ActionResult Edit(LivroModel livromodel)
        {
            if (ModelState.IsValid)
            {

                new LivroDAL.LivrosDAL.Atualizar(livromodel);

                db.Entry(livromodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(livromodel);
        }

        //
        // GET: /Livro/Delete/5

        public ActionResult Delete(int id = 0)
        {
            new LivroDAL.LivrosDAL().deletar(id);
            return RedirectToAction("Index");
        }

        //
        // POST: /Livro/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            LivroModel livromodel = db.LivroModels.Find(id);
            db.LivroModels.Remove(livromodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}