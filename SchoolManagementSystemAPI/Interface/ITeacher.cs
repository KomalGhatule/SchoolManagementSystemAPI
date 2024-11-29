using SchoolManagementSystemAPI.Entities;

namespace SchoolManagementSystemAPI.Interface
{
    public interface ITeacher
    {
        Task<List<Teacher>> GetAllTeachers();
        Task<Teacher?> GetTeacherByID(int id);
        Task<Teacher?> AddTeacher(Teacher obj);
        Task<Teacher?> UpdateTeacher(int id, Teacher obj);
        Task<bool> DeleteTeacherByID(int id);
    }
}
