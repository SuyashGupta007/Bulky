using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;

namespace Bulky.DataAccess.Repository
{
    public class DrugsRepository:Repository<Drugs>,IDrugsRepository 
    {
        private ApplicationDbContext _db;
        public DrugsRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }  

        public void Update(Drugs obj)
        {
            _db.Drugs.Update(obj);
        }
        public List<Drugs> Search(string SearchTerm)
        {
            
            List<Drugs> result = _db.Drugs.Where(e => e.Drug_Name.Contains(SearchTerm)).ToList();
            return result;
        }

    }
}
