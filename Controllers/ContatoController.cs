using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp_DIO_FRONT_END_MVC.Context;
using CSharp_DIO_FRONT_END_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_DIO_FRONT_END_MVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly AgendaContext _context;

        public ContatoController(AgendaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contato = _context.Contatos.ToList();
            return View(contato);
        }

        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            if (ModelState.IsValid)
            {
                _context.Contatos.Add(contato);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        public IActionResult Editar(int id)
        {
            var contato = _context.Contatos.Find(id);
            if (contato == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        [HttpPost]
        public IActionResult Editar(Contato contato)
        {
            var contatoBanco = _context.Contatos.Find(contato.Id);
            if (contatoBanco == null)
            {
                return RedirectToAction(nameof(Index));
            }
            contatoBanco.Nome = contato.Nome;
            contatoBanco.Ativo = contato.Ativo;
            contatoBanco.Telefone = contato.Telefone;
            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id)
        {
            var contato = _context.Contatos.Find(id);
            if (contato == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        public IActionResult Deletar(int id)
        {
            var contato = _context.Contatos.Find(id);
            if (contato == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        [HttpPost]
        public IActionResult Deletar(Contato contato){
            var contatoBanco = _context.Contatos.Find(contato.Id);
            if (contatoBanco == null)
            {
                return RedirectToAction(nameof(Index));
            }
            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}