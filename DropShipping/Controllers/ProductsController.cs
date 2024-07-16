using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DropShipping.Data;
using DropShipping.Models;
using DropShipping.Filters;
using DropShipping.Helper;
using DropShipping.Repositorio;

namespace DropShipping.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ProductsController : Controller
    {
        private readonly IProductRepositorio _productRepositorio;
        private readonly ISessao _sessao;

        
        public ProductsController(IProductRepositorio productRepositorio, ISessao sessao)
        {
            _productRepositorio = productRepositorio;
            _sessao = sessao;
        }


        // GET: Products
        public IActionResult Index()
        {
            UserModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
            List<ProductModel> products = _productRepositorio.BuscarTodos(usuarioLogado.Id);
            return View(products);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            // Alteração improvisada talvez não funcione, favor estudar mais

            if (id == null)
            {
                return NotFound();
            }

            var product = _productRepositorio.Detalhes(_productRepositorio.BuscarPorId(id));
            
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        public IActionResult Create(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                UserModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                product.UsuarioId = usuarioLogado.Id;

                product = _productRepositorio.Adicionar(product);
                TempData["MensagemSucesso"] = "Produto cadastrado com sucesso";
                return RedirectToAction("Index");
                
            }

            return View(product);
            
        }

        public IActionResult Editar()
        {
            return View("Edit");
        }

        // GET: Products/Edit/5
        public IActionResult Edit(ProductModel product)
        {
            try
            {
                ProductModel produto = null;

                if(ModelState.IsValid)
                {
                    produto = new ProductModel()
                    {
                        Id = product.Id,
                        Nome = product.Nome,
                        Descrição = product.Descrição,
                        Preço = product.Preço

                    };

                    // Alteração improvisada talvez não funcione, favor estudar mais
                    UserModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                    product.UsuarioId = usuarioLogado.Id;

                    product = _productRepositorio.Atualizar(product);
                    TempData["MensagemSucesso"] = "Produto alterado com sucesso !";
                    return RedirectToAction("Index");

                    if (product == null)
                    {
                        return NotFound();
                    }
                }
                return View(product);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }

            
            
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descrição,Preço")] ProductModel product)
        //{
        //    if (id != product.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(product);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProductExists(product.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        TempData["MensagemSucesso"] = "Produto alterado com sucesso ! ";
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(product);
        //}

        // GET: Products/Delete/5
        public IActionResult Delete(int id)
        {

            try
            {
                bool apagado = _productRepositorio.Apagar(id);
                TempData["MensagemSucesso"] = "Produto apagado com sucesso !";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                return RedirectToAction("Index");
            }

        }

        //// POST: Products/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var product = await _context.Products.FindAsync(id);
        //    if (product != null)
        //    {
        //        _context.Products.Remove(product);
        //    }

        //    await _context.SaveChangesAsync();
        //    TempData["MensagemSucesso"] = "Produto deletado com sucesso ! ";
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ProductExists(int id)
        //{
        //    return _context.Products.Any(e => e.Id == id);
        //}
    }
}
