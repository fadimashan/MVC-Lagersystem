using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Lagersystem.Data;
using MVC_Lagersystem.Models;
using MVC_Lagersystem.Repo;

namespace MVC_Lagersystem.Controllers
{
    public class ProductsController : Controller
    {
        private readonly MVC_LagersystemContext _context;

        IEnumerable<ProductViewModel> GetProducts = Enumerable.Empty<ProductViewModel>();

        public ProductsController(MVC_LagersystemContext context)
        {
            _context = context;
        }

        //GET: Products
        public async Task<IActionResult> Index()
        {

            return View(await _context.Product.ToListAsync());
        }


        public async Task<IActionResult> Index3()
        {
           
            var products = await _context.Product.ToArrayAsync();
            var model = new ProductCategoryVM()
            {
                Products = products,
                Categorys = await GetCategoryAsync()

            };

            return View(model);
        }

        private async Task<IEnumerable<SelectListItem>> GetCategoryAsync()
        {
            return await _context.Product
                .Select(p => p.Category)
                .Distinct()
                .Select(g => new SelectListItem
                {
                    Text = g.ToString(),
                    Value = g.ToString()
                })
                .ToListAsync();
        }

        public IActionResult DisplayForm()
        {

            var model = from item in _context.Product select item.Category;

            return View("PViewModel", model);
        }


        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Orderdate,Category,Chelf,Count,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                var unique = true;
                foreach (var p in _context.Product)
                {
                    if (p.Name == product.Name)
                    {
                        p.Count += product.Count;
                        unique = false;
                    }

                }

                if (unique)
                {
                    _context.Add(product);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Orderdate,Category,Chelf,Count,Description")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }


        public async Task<IActionResult> PViewModel()
        {
            var model = _context.Product.Select(x => new ProductViewModel()
            {
                Name = x.Name,
                Price = x.Price,
                Id = x.Id,
                Count = x.Count,
                InventoryValue = x.Price * x.Count
            });

            return View(await model.ToListAsync());
        }


        public ActionResult Filter(string category)
        {
            var listOfP = _context.Product.ToList();
            var tempList = listOfP.Where(p => p.Category.ToLower().Contains(category)).ToList();
            return View("Filter", tempList);
        }

        public async Task<IActionResult> Filter2(ProductCategoryVM viewModel)
        {
            var products = string.IsNullOrWhiteSpace(viewModel.Name) ?
                _context.Product :
                _context.Product.Where(m => m.Name.StartsWith(viewModel.Name));

            products = viewModel.Category == null ?
                products :
                products.Where(m => m.Category == viewModel.Category);

            var model = new ProductCategoryVM
            {
                Products = products,
                Categorys = await GetCategoryAsync()
            };

            return View(nameof(Index3), model);

        }
    }
}
