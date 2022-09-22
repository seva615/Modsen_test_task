using System.Linq;
using Events.Data.DataInterfaces;
using Events.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Events.Data.Entities;


namespace Events.Data.Repositories
{
    public class SpeakerRepository: GenericRepository<SpeakerEntity>, ISpeakerRepository
    {
        private readonly DataContext _db;

        public SpeakerRepository(DataContext db) : base(db)
        {
            _db = db;
            CollectionWithInclude = db.Speakers;


        }
    }
}