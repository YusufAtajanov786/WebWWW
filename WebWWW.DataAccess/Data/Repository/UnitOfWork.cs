using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebWWW.DataAccess.Data.Repository.IRepository;

namespace WebWWW.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            this._db = db;
            Category = new CategoryRepository(_db);
            foodTypeRepository = new FoodTypeRepository(_db);
        }

        public ICategoryRepository Category { get; private set; }
        public IFoodTypeRepository foodTypeRepository { get; private set; }

       
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
