using Asp.NetCoreMVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCoreMVCDemo.ViewModels
{
    public class HomeViewModel
    {
        public IList<Person> People { get; set; }
        public IList<Hobby> Hobbies { get; set; }
    }
}
