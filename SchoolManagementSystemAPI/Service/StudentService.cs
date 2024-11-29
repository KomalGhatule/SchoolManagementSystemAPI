using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystemAPI.Context;
using SchoolManagementSystemAPI.Entities;
using SchoolManagementSystemAPI.Interface;

namespace SchoolManagementSystemAPI.Service
{
    public class StudentService:IStudent
    {
        private readonly SchoolDbContext _dbContext;
        public StudentService(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Student>> GetAllStudents()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<Student?> GetStudentByID(int id)
        {
            return await _dbContext.Students.FirstOrDefaultAsync(stu=>stu.StudentId == id);
        }
        
        public async Task<Student?> AddStudent(Student obj)
        {
            var addStudent = new Student()
            {
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                DateOfBirth = obj.DateOfBirth,
                ClassId = obj.ClassId,
            };
            _dbContext.Students.Add(addStudent);
            var result=await _dbContext.SaveChangesAsync();
            return result > 0 ? addStudent : null;
        }

        public async Task<Student?> UpdateStudent(int id,Student obj)
        {
            var stud=await _dbContext.Students.FirstOrDefaultAsync(stud=>stud.StudentId == id);
            if(stud!=null)
            {
                stud.FirstName = obj.FirstName;
                stud.LastName = obj.LastName;
                stud.DateOfBirth = obj.DateOfBirth;
                stud.ClassId = obj.ClassId;
                var result= await _dbContext.SaveChangesAsync();
                return result > 0 ? stud : null;
            }
            return null;
        }
        public async Task<bool> DeleteStudentByID(int id)
        {
            var stud = await _dbContext.Students.FirstOrDefaultAsync(index => index.StudentId == id);
            if(stud != null)
            {
                _dbContext.Students.Remove(stud);
                var result= await _dbContext.SaveChangesAsync();
                return result > 0;
            }
            return false;
        }
    }
}
