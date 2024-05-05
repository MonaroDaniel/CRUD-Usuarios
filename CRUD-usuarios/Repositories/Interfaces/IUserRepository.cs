using CRUD_usuarios.Models;

namespace CRUD_usuarios.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetUsers();
        Task<UserModel> GetUserById(int id);
        Task<UserModel> PostUser(UserModel user);
        Task<UserModel> PutUser(UserModel user, int id);
        Task<bool> DeleteUser(int id);
    }
}
