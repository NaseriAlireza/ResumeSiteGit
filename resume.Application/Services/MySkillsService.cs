using Microsoft.EntityFrameworkCore;
using resume.Domain.Entities;
using resume.Domain.Entities.MySkills;
using resume.infrastructure.resumeDbContext;


namespace resume.Application.Services
{
    public class MySkillsService
    {
        private readonly ResumeDbContext Context;
        public MySkillsService(ResumeDbContext _Context)
        {
            Context = _Context;
        }
        
        public List<MySkills> GetAll()
        {
            return Context.MySkills.ToList();
        }
        
        public async Task<bool> Create(MySkills myskills)
        {

            var myskillss = await Context.MySkills.ToListAsync();
            var flag = myskillss.Where(e => e.MySkillsTitle == myskills.MySkillsTitle).SingleOrDefault();
            if (flag is null && myskills.MySkillsTitle is not null)
            {
                Context.MySkills.Add(myskills);
                await Context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }


        }
        public async Task Update(int id, MySkills myskills)
        {

            if (id == myskills.Id)
            {
                Context.MySkills.Update(myskills);
                await Context.SaveChangesAsync();
            }

        }
        public async Task Delete(int? id)
        {
            var myskills = Context.MySkills.Find(id);
            Context.MySkills.Remove(myskills);
            await Context.SaveChangesAsync();
        }
        public async Task<List<MySkills>> GetAllAsync()
        {
            return await Context.MySkills.ToListAsync();
        }
        public async Task<List<MySkills>> FindAsync(MySkills myskills)
        {

            var myskillss = await Context.MySkills.Where(e => e.MySkillsTitle == myskills.MySkillsTitle && e.Percentage == myskills.Percentage ).ToListAsync();
            return myskillss;

        }

        public List<MySkills> Find(MySkills myskills)
        {

            var myskillss = Context.MySkills.Where(e => e.MySkillsTitle == myskills.MySkillsTitle && e.Percentage == myskills.Percentage).ToList();
            return myskillss;

        }

        public async Task<MySkills> Find(int id)
        {
			return await Context.MySkills.Where(e => e.Id == id).SingleOrDefaultAsync();
		}
        public async Task<MySkills> SingleOrDefaultAsync(MySkills myskills)
        {
            try
            {
                var myskillss = await Context.MySkills.Where(e => e.MySkillsTitle == myskills.MySkillsTitle && e.Percentage == myskills.Percentage).SingleOrDefaultAsync();
                return myskillss;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        


    }
}
