using SchoolManagementSystemAPI.Entities;

namespace SchoolManagementSystemAPI.Interface
{
    public interface IUser
    {
        Task<List<User>> GetAllUsers();
        Task<User?> GetUserByID(int id);
        Task<User?> AddUser(User obj);
        Task<User?> UpdateUser(int id,User obj);
        Task<bool> DeleteUserByID(int id);
    }
}
