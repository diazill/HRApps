using HRApps.Data;
using HRApps.Models.DataPelamar;
using HRApps.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace HRApps.Controllers
{
    public class PelamarsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public PelamarsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPelamarViewModel viewModel)
        {
            var pelamar = new Pelamar
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                StatusPelamar = 1,
                Nik = viewModel.Nik,
                Status = viewModel.Status,
                TglLahir = viewModel.TglLahir,
                JenisKelamin = viewModel.JenisKelamin
            };
            await dbContext.Pelamars.AddAsync(pelamar);
            await dbContext.SaveChangesAsync();

        return View(); 
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var Pelamar = await dbContext.Pelamars.ToListAsync();
            
            return View(Pelamar);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var Pelamar =  await dbContext.Pelamars.FindAsync(id);

            return View(Pelamar);
        }
    }
}
