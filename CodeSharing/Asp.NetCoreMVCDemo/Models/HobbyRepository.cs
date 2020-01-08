using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCoreMVCDemo.Models
{
    public class HobbyRepository : IHobbyRepository
    {
        private List<Hobby> _hobbies { get; set; }
        public HobbyRepository()
        {
            if (_hobbies == null)
            {
                InitializeData();
            }
        }
        public IEnumerable<Hobby> GetAllHobbies()
        {
            throw new NotImplementedException();
        }
        private void InitializeData()
        {
            _hobbies = new List<Hobby>()
            {
                new Hobby{Id=1,Name="篮球",Content="扣篮、三分" },
                new Hobby{Id=1,Name="篮球",Content="扣篮、三分" },
                new Hobby{Id=1,Name="篮球",Content="扣篮、三分" }
            };
        }
    }
}
