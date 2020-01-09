using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCoreMVCDemo.Models
{
    public class PersonRepository : IPersonRepository
    {
        private List<Person> people;
        private readonly MvcDbContext _context;
        public PersonRepository(MvcDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Person> GetAllPeople()
        {
            return _context.Person;
        }

        public Person GetPersonById(int id)
        {
            return people.FirstOrDefault(x => x.Id == id);
        }
        private void InitializeData()
        {
            people = new List<Person>()
            {
                new Person{Id=1,Name="季某人",Email="923974733@qq.com"},
                new Person{Id=1,Name="高某人",Email="xiaomapricess@gmail.com"},
                new Person{Id=1,Name="忘某人",Email="819166858@qq.com"},
            };
        }
    }
}
