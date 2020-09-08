using brProg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace brProg.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult Index(bool? excluir = null)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                ClienteListViewModel vm = new ClienteListViewModel();
                
                if (excluir == true)
                {
                    ViewBag.Message = "Cliente excluido com sucesso!";
                    return View(vm);
                }

                vm.AchouResultado = null;
                return View(vm);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [HttpPost]
        public ActionResult Index(ClienteListViewModel vm)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                if (vm.Cpf == null && vm.NomeCliente == null)
                {
                    ViewBag.Message = "Digite o Nome do Cliente ou o CPF!";
                    return View(vm);
                }

                using (var db = new MyContext())
                {
                    var results = db.Cliente.ToList();
                    
                    if (vm.Cpf != null)
                        results = results.Where(x => x.Cpf == vm.Cpf).ToList();

                    //lembrar de incluir o ignoreCaracter
                    if(vm.NomeCliente != null)
                        results = results.Where(x => vm.NomeCliente.Contains(x.NomeCliente)).ToList();

                    if (results.Any())
                    {
                        vm.Clientes = new List<Cliente>();
                        foreach (var result in results)
                        {
                            var cliente = new Cliente();

                            cliente.Cpf = result.Cpf;
                            cliente.Email = result.Email;
                            cliente.id = result.id;
                            cliente.NomeCliente = result.NomeCliente;
                            cliente.Telefone = result.Telefone;

                            vm.Clientes.Add(cliente);
                        }
                        vm.AchouResultado = true;
                    }
                    else
                        vm.AchouResultado = false;
                }
                return View(vm);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        public ActionResult Register()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                using (var db = new MyContext())
                {

                    if (db.Cliente.Where(x => x.Cpf == vm.Cpf).Any())
                    {
                        ViewBag.Message = "Este cliente já esta cadastrada!";
                        return View(vm);
                    }

                    Cliente cliente = new Cliente();
                    cliente.Cpf = vm.Cpf;
                    cliente.Email = vm.Email;
                    cliente.NomeCliente = vm.NomeCliente;
                    cliente.Telefone = vm.Telefone;
                    db.Cliente.Add(cliente);
                    db.SaveChanges();
                    ModelState.Clear();
                }
                RegisterViewModel vm2 = new RegisterViewModel();
                ViewBag.Message = "Cliente Cadastrado com Sucesso!";
                return View(vm2);
            }
            return View(vm);
        }

        public ActionResult Deletar(int id)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                using (var db = new MyContext())
                {
                    var clienteDeletar = db.Cliente.Where(x => x.id == id);

                    db.Cliente.RemoveRange(clienteDeletar);
                    db.SaveChanges();
                }
                
                return RedirectToAction("Index", "Cliente", new { excluir = true });
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        public ActionResult Alterar(int id)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                using (var db = new MyContext())
                {
                    var cliente = db.Cliente.Where(x => x.id == id).FirstOrDefault();
                    var returnView = new RegisterViewModel();
                    if (cliente != null)
                    {
                        returnView.id = cliente.id;
                        returnView.Cpf = cliente.Cpf;
                        returnView.Email = cliente.Email;
                        returnView.NomeCliente = cliente.NomeCliente;
                        returnView.Telefone = cliente.Telefone;
                    }
                    return View(returnView);
                }
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [HttpPost]
        public ActionResult Alterar(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                using (var db = new MyContext())
                {

                    if (db.Cliente.Where(x => (x.Cpf == vm.Cpf && vm.id != x.id)).Any())
                    {
                        ViewBag.Message = "Este cliente já esta cadastrada!";
                        return View(vm);
                    }

                    var cliente = db.Cliente.Where(x => x.id == vm.id).FirstOrDefault();

                    cliente.Cpf = vm.Cpf;
                    cliente.Email = vm.Email;
                    cliente.NomeCliente = vm.NomeCliente;
                    cliente.Telefone = vm.Telefone;
                    db.SaveChanges();
                    ModelState.Clear();
                }
                
                ViewBag.Message = "Cliente Alterado com Sucesso!";
                return View(vm);
            }
            return View(vm);
        }
    }
}