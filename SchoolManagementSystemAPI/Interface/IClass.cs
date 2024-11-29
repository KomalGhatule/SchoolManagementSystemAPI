using SchoolManagementSystemAPI.Entities;

namespace SchoolManagementSystemAPI.Interface
{
    public interface IClass
    {
        Task<List<Class>> GetAllClass();
        Task<Class?> GetClassByID(int id);
        Task<Class?> AddClass(Class obj);
        Task<Class?> UpdateClass(int id,Class obj);
        Task<bool> DeleteClassByID(int id);
    }
}
