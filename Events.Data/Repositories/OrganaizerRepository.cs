using Events.Data.DataInterfaces;
using Events.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Events.Data.Repositories
{
    public class OrganaizerRepository : GenericRepository<OrganizerEntity>, IOrganaizerRepository
    {
        private readonly DataContext _db;
        
        public OrganaizerRepository(DataContext db) : base(db)
        {
            _db = db;
            CollectionWithInclude = db.Organizers
                .Include(x=>  x.Address)
                .Include(x=> x.Events);


        }
        
    }
}