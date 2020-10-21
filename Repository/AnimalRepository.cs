using Microsoft.EntityFrameworkCore;
using System.Linq;
using VetPet.Data;
using VetPet.Models;

namespace VetPet.Repository
{
    public class AnimalRepository : BaseIDRepository<Animal>
    {
        public AnimalRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        protected override IQueryable<Animal> Query() => DbSet
                                                        .Include(c => c.User)
                                                        .AsQueryable();
    }
}
