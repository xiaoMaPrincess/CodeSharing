using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCoreMVCDemo.Models
{
    public class PersonRepository : IPersonRepository
    {
        private List<Person> people;
        public PersonRepository()
        {
            if (people == null)
            {
                InitializeData();
            }
        }
        public IEnumerable<Person> GetAllPeople()
        {
            return people;
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
