using Microsoft.EntityFrameworkCore;
using SchoolManagementSystemAPI.Context;
using SchoolManagementSystemAPI.Entities;
using SchoolManagementSystemAPI.Interface;

namespace SchoolManagementSystemAPI.Service
{
    public class UserService:IUser
    {
        private readonly SchoolDbContext _dbContext;
        public UserService(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetUserByID(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u=>u.UserId == id);
        }

        public async Task<User?> AddUser(User obj)
        {
            var addUser = new User()
            {
                UserName = obj.UserName,
                PasswordHash = obj.PasswordHash,
                Role = obj.Role,
            };
            _dbContext.Users.Add(addUser);
            var result= await _dbContext.SaveChangesAsync();
            return result > 0 ? addUser : null;
        }
        public async Task<User?> UpdateUser(int id,User user)
        {
            var model= await _dbContext.Users.FirstOrDefaultAsync(index=>index.UserId == id);
            if(model!=null)
            {
                model.UserName = user.UserName;
                model.PasswordHash = user.PasswordHash;
                model.Role = user.Role;
                var result=await _dbContext.SaveChangesAsync();
                return result > 0 ? model : null;
            }
            return null;    
        }
        public async Task<bool> DeleteUserByID(int id)
        {
            var hero=await _dbContext.Users.FirstOrDefaultAsync(index=>index.UserId == id);
            if(hero!=null)
            {
                 _dbContext.Users.Remove(hero);
                 var result=await _dbContext.SaveChangesAsync();
                 return result > 0;
            }
            return false;
        }
    }
}
