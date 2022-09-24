using System.Threading.Tasks;
using Events.Services.Models;

namespace Events.Services.ServiceInterfaces
{
    public interface IAccountService
    {
        public Task CreateAccount(OrganizerModel organizer);

        public OrganizerModel Authorize(OrganizerModel organizer);
    }
}