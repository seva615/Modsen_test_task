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
                .Include(x=>  x.Address)
                .Include(x=> x.Events);


        }
        
        public  OrganizerEntity GetByName(string name)
        {
            return  CollectionWithInclude.FirstOrDefault(entity => entity.Name == name);
        }
        
    }
}