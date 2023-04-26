using Bulky.Models;


namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IDrugsRepository : IRepository<Drugs>
    {
        void Update(Drugs obj);
        void Save();
        List<Drugs> Search(string searchTerm);
    }
}
