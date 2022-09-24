using System.Threading.Tasks;
using Events.Data.Entities;

namespace Events.Data.DataInterfaces
{
    public interface IOrganizerRepository : IGenericRepository<OrganizerEntity>
    {
        public OrganizerEntity GetByName(string name);
    }
}