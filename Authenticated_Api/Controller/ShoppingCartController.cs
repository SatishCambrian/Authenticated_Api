using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AuthenticatedClassLibrary.Model.Data;

namespace Authenticated.Controllersgit 
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly SecurityDbContext _context;
        public ShoppingCartController(SecurityDbContext context)
        {
            _context = context;
        }

        // GET: ShoppingCart
        public IActionResult Index()
        {
            var userId = User.Identity.Name;
            var shoppingCarts = _context.ShoppingCarts
                .Where(sc => sc.UserId == userId)
                .Include(sc => sc.Products)
                .ToList();

            return View(shoppingCarts);
            //return View(_context.ShoppingCarts.ToList());
        }

        // GET: ShoppingCart/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingCart = _context.ShoppingCarts
                .FirstOrDefault(m => m.ShoppingCartId == id);
            if (shoppingCart == null)
            {
                return NotFound();
            }

            return View(shoppingCart);
        }

        // GET: ShoppingCart/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShoppingCart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ShoppingCartId,CustomerId,CreatedDate")] ShoppingCart shoppingCart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoppingCart);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(shoppingCart);
        }

        // GET: ShoppingCart/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingCart = _context.ShoppingCarts.Find(id);
            if (shoppingCart == null)
            {
                return NotFound();
            }
            return View(shoppingCart);
        }

        // POST: ShoppingCart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ShoppingCartId,CustomerId,CreatedDate")] ShoppingCart shoppingCart)
        {
            if (id != shoppingCart.ShoppingCartId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoppingCart);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingCartExists(shoppingCart.ShoppingCartId))
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
            return View(shoppingCart);
        }

        // GET: ShoppingCart/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingCart = _context.ShoppingCarts
                .FirstOrDefault(m => m.ShoppingCartId == id);
            if (shoppingCart == null)
            {
                return NotFound();
            }

            return View(shoppingCart);
        }

        // POST: ShoppingCart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var shoppingCart = _context.ShoppingCarts.Find(id);
            _context.ShoppingCarts.Remove(shoppingCart);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingCartExists(int id)
        {
            return _context.ShoppingCarts.Any(e => e.ShoppingCartId == id);
        }
    }
}