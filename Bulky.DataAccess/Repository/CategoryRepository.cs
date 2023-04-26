using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bulky.Models;

namespace Bulky.DataAccess.Repository
{
    public class CategoryRepository:Repository<Category>,ICategoryRepository 
    {
        private readonly ApplicationDbContext _db;
      
        public CategoryRepository(ApplicationDbContext db) : base(db) {
            _db = db;

        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
        public List<Category> Search(string SearchTerm)
        {
            
            List<Category> result = _db.Categories.Where(e => e.Name.Contains(SearchTerm)).ToList();
            return result;
        }

    }
}
