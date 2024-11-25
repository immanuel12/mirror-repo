using HelloWorldApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HelloWorldApp.Models;

namespace HelloWorldApp.Pages
{
  public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public string Name { get; set; }

    public IList<NameEntry> NameEntries { get; set; }

    public void OnGet()
    {
        NameEntries = _context.NameEntries.ToList();
    }

    public IActionResult OnPost()
    {
        Console.WriteLine($"Nama yang diterima di OnPost: {Name}");

        if (ModelState.IsValid)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                var newEntry = new NameEntry { Name = Name };
                try
                {
                    _context.NameEntries.Add(newEntry);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Terjadi kesalahan saat menambahkan data: " + ex.Message);
                    return Page();
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Nama tidak boleh kosong.");
            }
        }
        else
        {
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine($"ModelState Error: {error.ErrorMessage}");
            }
        }

        Console.WriteLine($"Nama setelah diproses: {Name}");

        NameEntries = _context.NameEntries.ToList();

        return Page();
    }
}

}
