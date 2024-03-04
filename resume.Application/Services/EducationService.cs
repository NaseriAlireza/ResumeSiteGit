using Microsoft.EntityFrameworkCore;
using resume.Domain.Entities;
using resume.Domain.Entities.Education;
using resume.infrastructure.resumeDbContext;



namespace resume.Application.Services
{
    public class EducationService
    {
        private readonly ResumeDbContext Context;
        public EducationService(ResumeDbContext _Context)
        {
            Context = _Context;
        }

        public List<Education> GetAll()
        {
			return Context.Education.ToList();
        }
		public async Task<bool> Create(Education education)
		{

			var educations = await Context.Education.ToListAsync();
			var flag = educations.Where(e => e.EducationTitle == education.EducationTitle).SingleOrDefault();
			if (flag is null)
			{
				Context.Education.Add(education);
				await Context.SaveChangesAsync();
				return true;
			}
			else
			{
				return false;
			}


		}
		public async Task Update(int id, Education education)
		{

			if (id == education.Id)
			{
				Context.Education.Update(education);
				await Context.SaveChangesAsync();
			}

		}
		public async Task Delete(int? id)
		{
			var education = Context.Education.Find(id);
			Context.Education.Remove(education);
			await Context.SaveChangesAsync();
		}
		public async Task<List<Education>> GetAllAsync()
		{
			return await Context.Education.ToListAsync();
		}
		public async Task<List<Education>> FindAsync(Education education)
		{

			var educations = await Context.Education.Where(e => e.EducationTitle == education.EducationTitle && e.EducationDuration == education.EducationDuration && e.Discription==education.Discription).ToListAsync();
			return educations;

		}
		
		public List<Education> Find(Education education)
		{

			var Education = Context.Education.Where(e => e.EducationTitle == education.EducationTitle && e.EducationDuration == education.EducationDuration && e.Discription == education.Discription).ToList();
			return Education;

		}

		public async Task<Education> Find(int id)
		{

			var education = await Context.Education.Where(e => e.Id == id).SingleOrDefaultAsync();
			return education;

		}
		public async Task<Education> SingleOrDefaultAsync(Education education)
		{
			try
			{
				var educations = await Context.Education.Where(e => e.EducationTitle == education.EducationTitle && e.EducationDuration == education.EducationDuration && e.Discription == education.Discription).SingleOrDefaultAsync();
				return educations;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}



	}
}
