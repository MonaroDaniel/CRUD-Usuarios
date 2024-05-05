using CRUD_usuarios.Data;
using CRUD_usuarios.Models;
using CRUD_usuarios.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUD_usuarios.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserCrudDBContext _dbContext;
        public UserRepository(UserCrudDBContext userCrudDBContext) 
        {
            _dbContext = userCrudDBContext;
        }

        public async Task<List<UserModel>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModel> PostUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> PutUser(UserModel user, int id)
        {
            UserModel userById = await GetUserById(id);

            if (userById == null)
            {
                throw new Exception($"User ID: {id} not found on database.");
            }

            userById.Name = user.Name;
            userById.Email = user.Email;

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel userById = await GetUserById(id);

            if (userById == null)
            {
                throw new Exception($"User ID: {id} not found on database.");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
