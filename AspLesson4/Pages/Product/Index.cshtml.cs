using AspLesson4.Entities;
using AspLesson4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspLesson4.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly ProductDbContext _context;

        public IndexModel(ProductDbContext context)
        {
            _context = context;
        }
        public string Message { get; set; }
        public string Info { get; set; }
        public List<Entities.Product> Products { get; set; }
        public void OnGet(string info="")
        {
            Products = _context.Products.ToList();
            Message = $"Today is {DateTime.Now.DayOfWeek}";
            Info = info;
        }
        [BindProperty]
        public Entities.Product Product { get; set; }
        public IActionResult OnPost()
        {
            _context.Products.Add(Product);
            _context.SaveChanges();
            Info = $"{Product.Name} added successfully";
            return RedirectToPage("Index",new { info=Info });
        }
    }
}
