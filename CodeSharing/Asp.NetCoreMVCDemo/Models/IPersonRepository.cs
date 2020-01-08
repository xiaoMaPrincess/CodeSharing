using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCoreMVCDemo.Models
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAllPeople();
        Person GetPersonById(int id);
    }
}
