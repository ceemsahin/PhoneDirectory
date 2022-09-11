using Directory.Models;
using Microsoft.AspNetCore.Mvc;

namespace Directory.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string p)
        {

            if (!string.IsNullOrEmpty(p))
            {

                return View(_context.Users.Where(x => x.NameSurname == p).ToList());
            }
            var persons = _context.Users.ToList();

            return View(persons);
        }


        [HttpGet]
        public IActionResult YeniKisi()
        {


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> YeniKisi(UserModel user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
            else
            {
                return View("YeniKisi");
            }

            return RedirectToAction("Index");
        }


        public IActionResult KisiGetir(int id)
        {
            var person = _context.Users.Find(id);
            return View("KisiGetir", person);


        }

        public async Task<IActionResult> KisiGuncelle(UserModel user)
        {
            var person = await _context.Users.FindAsync(user.Id);

            person.NameSurname = user.NameSurname;
            person.category = user.category;
            person.PhoneNumber = user.PhoneNumber;

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public IActionResult KisiSil(int id)
        {
            var person = _context.Users.Find(id);
            _context.Users.Remove(person);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }

    }
}