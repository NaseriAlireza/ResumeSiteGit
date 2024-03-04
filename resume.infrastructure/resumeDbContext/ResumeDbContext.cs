using Microsoft.EntityFrameworkCore;
using resume.Domain.Entities;
using resume.Domain.Entities.Education;
using resume.Domain.Entities.MySkills;
using resume.Domain.Entities.Person;


namespace resume.infrastructure.resumeDbContext;

public class ResumeDbContext:DbContext
{
    public ResumeDbContext(DbContextOptions<ResumeDbContext> options)
            : base(options)
    {
    }
    public DbSet<Education> Education { get; set; }
    public DbSet<MySkills> MySkills { get; set; }
    public DbSet<Person> Person { get; set; }


}
