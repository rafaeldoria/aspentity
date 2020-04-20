using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using aspentity.Models;
using aspentity.Database;

namespace aspentity.Controllers
{
    public class FuncionariosController : Controller
    {   
        private readonly applicationDBContext database;

        public FuncionariosController(applicationDBContext database){
            this.database = database;
        }

        public IActionResult Index(){
            var funcionarios = database.Funcionarios.ToList();
            return View(funcionarios);
        }

        public IActionResult Cadastrar(){
            return View();
        }

        public IActionResult Editar(int id){
            Funcionario funcionario = database.Funcionarios.First(registro => registro.Id == id);
            return View("Cadastrar", funcionario);
        }

        public IActionResult Deletar(int id){
            Funcionario funcionario = database.Funcionarios.First(registro => registro.Id == id);
            database.Funcionarios.Remove(funcionario);
            database.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Salvar(Funcionario funcionario){
            if(funcionario.Id == 0){
                database.Funcionarios.Add(funcionario);
            }else{
                Funcionario dadosFuncionario = database.Funcionarios.First(registro => registro.Id == funcionario.Id);
                dadosFuncionario.Nome = funcionario.Nome;
                dadosFuncionario.Salario = funcionario.Salario;
                dadosFuncionario.Cpf = funcionario.Cpf;
            }
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}