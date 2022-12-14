using System;
using System.Linq;
using System.Threading.Tasks;
using Events.Data.DataInterfaces;
using Events.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Events.Data.Repositories
{
    public class OrganizerRepository : GenericRepository<OrganizerEntity>, IOrganizerRepository
    {
        private readonly DataContext _db;
        
        public OrganizerRepository(DataContext db) : base(db)
        {
            _db = db;
            CollectionWithInclude = db.Organizers
                .Include(x => x.Events).ThenInclude(x => x.Plan).ThenInclude(x => x.Speeches)
                .ThenInclude(x => x.Speaker)
                .Include(x => x.Events).ThenInclude(x => x.Address);





        }

        public OrganizerEntity GetOrganizerById(Guid id)
        {
            return CollectionWithInclude.FirstOrDefault(entity => entity.Id == id);
        }

        public  OrganizerEntity GetByName(string name)
        {
            return  CollectionWithInclude.FirstOrDefault(entity => entity.Name == name);
        }
        
    }
}