using AspLesson4.Entities;
using AspLesson4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspLesson4.Pages.Product
{
    public class IndexModel : PageModel
    {
        private static int DefaultID = -1;

        private readonly ProductDbContext _context;

        public IndexModel(ProductDbContext context)
        {
            _context = context;
            Products = _context.Products.ToList();
            Product = new Entities.Product()
            {
                Id = DefaultID
            };
        }

        public string Message { get; set; }
        public string Info { get; set; }
        public List<Entities.Product> Products { get; set; } = new List<Entities.Product> {  };

        public void OnGet(string info = "")
        {
            Message = $"Today is {DateTime.Now.DayOfWeek}";
            Info = info;
        }

        [BindProperty]
        public Entities.Product Product { get; set; }

        public IActionResult OnPostDelete(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            if (product == null)
            {
                var _errorInfo = "Product was not found!";
                return RedirectToPage("Index", new { info = _errorInfo });
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            var _info = $"Product({product.Name}) was deleted!";
            return RedirectToPage("Index", new { info = _info });
        }

        public IActionResult OnPostUpdate()
        {
            if (Product.Id == DefaultID || Product.Id == 0)
            {
                var warning = "Select Product";
                return RedirectToPage("Index", new { info = warning });
            }

            _context.Products.Update(Product);
            var stateCount = _context.SaveChanges();

            if (stateCount > 0)
            {
                var _info = $"Product({Product.Name}) was updated!";
                return RedirectToPage("Index", new { info = _info });
            }
            var noChange = "No changes were made";
            return RedirectToPage("Index", new {info = noChange});
        }

        public IActionResult OnPost()
        {
            _context.Products.Add(Product);
            _context.SaveChanges();
            Info = $"{Product.Name} added successfully";
            return RedirectToPage("Index", new { info = Info });
        }
    }
}
