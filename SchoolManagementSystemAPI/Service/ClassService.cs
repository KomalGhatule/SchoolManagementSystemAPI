using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystemAPI.Context;
using SchoolManagementSystemAPI.Entities;
using SchoolManagementSystemAPI.Interface;

namespace SchoolManagementSystemAPI.Service
{
    public class ClassService : IClass
    {
        private readonly SchoolDbContext _dbContext;
        public ClassService(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Class>> GetAllClass()
        {
            return await _dbContext.Classes.ToListAsync();  
        }

        public async Task<Class?> GetClassByID(int id)
        {
            return await _dbContext.Classes.FirstOrDefaultAsync(c => c.ClassId == id);
        }
        public async Task<Class?> AddClass(Class obj)
        {
            var addClass = new Class()
            {
                ClassName = obj.ClassName,
                TeacherId = obj.TeacherId,
            };
            _dbContext.Classes.Add(addClass);
            
            var result = await _dbContext.SaveChangesAsync();
            
            return result >= 0 ? addClass : null;
        }
        public async Task<Class?> UpdateClass(int id,Class obj)
        {
            var model=await _dbContext.Classes.FirstOrDefaultAsync(index=>index.ClassId == id);
            if(model!=null)
            {
                model.ClassName = obj.ClassName;
                model.TeacherId = obj.TeacherId;
                var result= await _dbContext.SaveChangesAsync();
                return result >= 0 ? model : null;
            }
            return null;
        }
        public async Task<bool> DeleteClassByID(int id)
        {
            var hero = await _dbContext.Classes.FirstOrDefaultAsync(c => c.ClassId == id);
            if(hero != null)
            {
                _dbContext.Classes.Remove(hero);
                var result= await _dbContext.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }
    }
}

