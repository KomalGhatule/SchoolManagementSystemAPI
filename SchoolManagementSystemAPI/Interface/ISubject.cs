using SchoolManagementSystemAPI.Entities;

namespace SchoolManagementSystemAPI.Interface
{
    public interface ISubject
    {
        Task<List<Subject>> GetAllSubjects();
        Task<Subject?> GetSubjectByID(int id);
        Task<Subject?> AddSubject(Subject obj);
        Task<Subject?> UpdateSubject(int id,Subject obj);
        Task<bool> DeleteSubjectByID(int id);
    }
}
