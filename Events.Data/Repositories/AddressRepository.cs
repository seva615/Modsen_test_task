using Events.Data.DataInterfaces;
using Events.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Events.Data.Repositories
{
    public class AddressRepository : GenericRepository<AddressEntity>, IAddressRepository
    {
        private readonly DataContext _db;

        public AddressRepository(DataContext db) : base(db)
        {
            _db = db;
            CollectionWithInclude = db.Addresses;



        }
        
    }
}