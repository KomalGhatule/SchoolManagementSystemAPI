using Microsoft.EntityFrameworkCore;
using SchoolManagementSystemAPI.Context;
using SchoolManagementSystemAPI.Entities;
using SchoolManagementSystemAPI.Interface;

namespace SchoolManagementSystemAPI.Service
{
    public class SubjectService:ISubject
    {
        private readonly SchoolDbContext _dbContext;
        public SubjectService(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Subject>> GetAllSubjects()
        {
            return await _dbContext.Subjects.ToListAsync();
        }

        public async Task<Subject?> GetSubjectByID(int id)
        {
            return await _dbContext.Subjects.FirstOrDefaultAsync(sub=>sub.SubjectId == id);
        }

        public async Task<Subject?> AddSubject(Subject obj)
        {
            var addSubject = new Subject()
            {
                SubjectName = obj.SubjectName,
            };
            _dbContext.Subjects.Add(addSubject);
            var result= await _dbContext.SaveChangesAsync();
            return result>0?addSubject:null;
        }
        public async Task<Subject?> UpdateSubject(int id,Subject obj)
        {
            var sub=await _dbContext.Subjects.FirstOrDefaultAsync(index=>index.SubjectId == id);
            if(sub!=null)
            {
                sub.SubjectName = obj.SubjectName;
                var result=await _dbContext.SaveChangesAsync();
                return result>0?sub:null;
            }
            return null;
        }
        public async Task<bool> DeleteSubjectByID(int id)
        {
            var sub=await _dbContext.Subjects.FirstOrDefaultAsync(index=>index.SubjectId == id);
            if(sub!=null)
            {
                _dbContext.Subjects.Remove(sub);
                var result=await _dbContext.SaveChangesAsync();
                return result>0;
            }
            return false;
        }
    }
}
