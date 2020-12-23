using FirstWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Controllers
{
    public class ProductController : Controller
    {
        UnitOfWork.UnitOfWorkApp _uow;
        public ProductController()
        {
            _uow = new UnitOfWork.UnitOfWorkApp();
        }
        // GET: Product
        public ActionResult Index()
        {
            return View(_uow.ProductRepository.FindAll());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View(_uow.ProductRepository.FindById(id));
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                _uow.ProductRepository.Add(product);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_uow.ProductRepository.FindById(id));
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product produto)
        {
            try
            {
                _uow.ProductRepository.Edit(produto);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_uow.ProductRepository.FindById(id));
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product produto)
        {
            try
            {
                _uow.ProductRepository.Remove(_uow.ProductRepository.FindById(id));
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
