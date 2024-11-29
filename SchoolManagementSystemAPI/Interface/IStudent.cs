using SchoolManagementSystemAPI.Entities;

namespace SchoolManagementSystemAPI.Interface
{
    public interface IStudent
    {
        Task<List<Student>> GetAllStudents();
        Task<Student?> GetStudentByID(int id);
        Task<Student?> AddStudent(Student obj);
        Task<Student?> UpdateStudent(int id,Student obj);
        Task<bool> DeleteStudentByID(int id);
    }
}
