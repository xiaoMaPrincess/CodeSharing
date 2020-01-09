using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCoreMVCDemo.Models
{
    public class HobbyRepository : IHobbyRepository
    {
        private List<Hobby> _hobbies { get; set; }
        private readonly MvcDbContext _context;
        public HobbyRepository(MvcDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Hobby> GetAllHobbies()
        {
            return _context.Hobby;
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
