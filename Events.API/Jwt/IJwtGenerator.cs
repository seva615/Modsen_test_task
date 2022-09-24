using Modsen_test_task.ViewModels;

namespace Modsen_test_task.Jwt
{
    public interface IJwtGenerator
    {
        string GenerateJwtToken(OrganizerViewModel organizer);
    }
}