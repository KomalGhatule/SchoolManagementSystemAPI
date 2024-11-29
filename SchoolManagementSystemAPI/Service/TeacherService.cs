using Microsoft.EntityFrameworkCore;
using SchoolManagementSystemAPI.Context;
using SchoolManagementSystemAPI.Entities;
using SchoolManagementSystemAPI.Interface;

namespace SchoolManagementSystemAPI.Service
{
    public class TeacherService:ITeacher
    {
        private readonly SchoolDbContext _dbContext;
        public TeacherService(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Teacher>> GetAllTeachers()
        {
            return await _dbContext.Teachers.ToListAsync();
        }

        public async Task<Teacher?> GetTeacherByID(int id)
        {
            return await _dbContext.Teachers.FirstOrDefaultAsync(tea=>tea.TeacherId == id);
        }

        public async Task<Teacher?> AddTeacher(Teacher obj)
        {
            var addTeacher = new Teacher()
            {
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                SubjectId = obj.SubjectId,
            };
            _dbContext.Teachers.Add(addTeacher);
            var result=await _dbContext.SaveChangesAsync();
            return result>0?addTeacher: null;
        }

        public async Task<Teacher?> UpdateTeacher(int id,Teacher obj)
        {
            var teach=await _dbContext.Teachers.FirstOrDefaultAsync(index=>index.TeacherId==id);
            if(teach!=null)
            {
                teach.FirstName = obj.FirstName;
                teach.LastName = obj.LastName;
                teach.SubjectId = obj.SubjectId;
                var result= await _dbContext.SaveChangesAsync();
                return result>0?teach: null;
            }
            return null;
        }

        public async Task<bool> DeleteTeacherByID(int id)
        {
            var hero=await _dbContext.Teachers.FirstOrDefaultAsync(index=>index.TeacherId==id);
            if(hero!=null)
            {
                _dbContext.Teachers.Remove(hero);
                var result=await _dbContext.SaveChangesAsync();
                return result>0;
            }
            return false;
        }
    }
}
