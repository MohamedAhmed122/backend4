using Backend4.Models.Users;

namespace Backend4.Services
{
    public interface IUsersService
    {
        UserCredential FindByFullName(string firstName, string lastName);
        void Create(UserCredential user);

    }
}
