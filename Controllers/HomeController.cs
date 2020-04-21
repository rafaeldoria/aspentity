using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aspentity.Models;
using aspentity.Database;
using Microsoft.EntityFrameworkCore;

namespace aspentity.Controllers
{
    public class HomeController : Controller
    {
        private readonly applicationDBContext database;

        public HomeController(applicationDBContext database){
            this.database = database;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Teste()
        {
            // Categoria c1 = new Categoria();
            // c1.Nome = "TI";
            // Categoria c2 = new Categoria();
            // c2.Nome = "Móveis";
            // Categoria c3 = new Categoria();
            // c3.Nome = "Eletrônicos";
            // Categoria c4 = new Categoria();
            // c4.Nome = "Celulares";

            // List<Categoria> listCategoria = new List<Categoria>();
            // listCategoria.Add(c1);
            // listCategoria.Add(c2);
            // listCategoria.Add(c3);
            // listCategoria.Add(c4);

            // database.AddRange(listCategoria);
            // database.SaveChanges();

            // var listaCategorias = database.Categorias.ToList();
            var listaCategorias = database.Categorias.Where(cat => cat.Nome.Equals("TI")).ToList();
            Console.WriteLine("=======Categorias========");
            listaCategorias.ForEach(categoria => {
                Console.WriteLine(categoria.ToString());
            });
            Console.WriteLine("=========================");

            return Content("Sucesso");
        }

        public IActionResult Relacionamento(){
            // Produto p1 = new Produto();
            // p1.Nome = "Roteador";
            // p1.Categoria = database.Categorias.First(cat => cat.Id == 1);

            // Produto p2 = new Produto();
            // p2.Nome = "Estante";
            // p2.Categoria = database.Categorias.First(cat => cat.Id == 2);

            // Produto p3 = new Produto();
            // p3.Nome = "Televisão";
            // p3.Categoria = database.Categorias.First(cat => cat.Id == 3);

            // database.Add(p1);
            // database.Add(p2);
            // database.Add(p3);
            // database.SaveChanges();

            // var listaProdutos = database.Produtos.Include(p => p.Categoria).ToList();

            // Console.WriteLine("=======Produtos========");
            // listaProdutos.ForEach(produto => {
            //     Console.WriteLine(produto.ToString());
            // });
            // Console.WriteLine("=======================");

            // var listaProdutosPorCategoria = database.Produtos.Include(p => p.Categoria).Where(p => p.Categoria.Id == 1).ToList();
            var listaProdutosPorCategoria = database.Produtos.Where(p => p.Categoria.Id == 1).ToList();

            Console.WriteLine("=======Produtos========");
            listaProdutosPorCategoria.ForEach(produto => {
                Console.WriteLine(produto.ToString());
            });
            Console.WriteLine("=======================");

            return Content("Sucesso");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
