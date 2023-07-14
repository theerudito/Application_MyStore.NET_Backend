using Store.DTO;
using Store.Models;

namespace Store.Service
{
    public interface IAuthRepository
    {
        Task<List<MAuth>> GetAllUsers();

        Task<MAuth> GetUserById(int id);

        Task<MAuth> UpdateUser(MAuth auth);

        Task<MAuth> DeleteUser(int id);

        Task<MAuth> Login(MAuthDTO authDTO);

        Task<MAuth> Register(MAuth auth);
    }
}
