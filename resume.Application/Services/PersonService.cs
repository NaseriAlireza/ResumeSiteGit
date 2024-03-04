using Microsoft.EntityFrameworkCore;

using resume.Domain.Entities.Person;
using resume.infrastructure.resumeDbContext;


namespace resume.Application.Services
{
    public class PersonService
    {
        private readonly ResumeDbContext Context;
        public PersonService(ResumeDbContext _context)
        {
            Context = _context;
        }

       
        public async Task<bool> Create(Person person)
        {
            
            var persons= await Context.Person.ToListAsync();
            var flag=persons.Where(e=> e.UserName == person.UserName).SingleOrDefault();
            if (flag is null)
            {
                Context.Person.Add(person);
                await Context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
                
    
        }
        public async Task Update(int id,Person person)
        {
            
            if(id==person.Id)
            {
                Context.Person.Update(person);
                await Context.SaveChangesAsync();
            }

        }
        public async Task Delete(int? id)
        {
            var person = Context.Person.Find(id);
            Context.Person.Remove(person);
            await Context.SaveChangesAsync();
        }
        public async Task<List<Person>> GetAllAsync()
        {
            return await Context.Person.ToListAsync();
        }
        public List<Person> GetAll()
        {
            return Context.Person.ToList();
        }
        public async Task<List<Person>> FindAsync(Person person)
        {
            
                var persons = await Context.Person.Where(e => e.UserName == person.UserName && e.Password == person.Password).ToListAsync();
                return persons;
            
        }
        public async Task<Person> Find(int id)
        {

            var person = await Context.Person.Where(e => e.Id== id).SingleOrDefaultAsync();
            return person;

        }
        public  List<Person> Find(Person person)
        {

            var persons =Context.Person.Where(e => e.UserName == person.UserName && e.Password == person.Password).ToList();
            return persons;

        }


        public async Task<Person> SingleOrDefaultAsync(Person person)
        {
            try
            {
                var persons = await Context.Person.Where(e => e.UserName == person.UserName && e.Password == person.Password).SingleOrDefaultAsync();
                return persons;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        

        
    }
}
