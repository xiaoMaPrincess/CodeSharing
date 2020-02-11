using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreAutofacDemo.Services
{
    public interface ICoreService
    {
        void OutputHashCode();
    }
    public class CoreService : ICoreService
    {
        public void OutputHashCode()
        {
            Console.WriteLine($"CoreService.OutputHashCode:{GetHashCode()}");
        }
    }
    /// <summary>
    /// 第二个实现类
    /// </summary>
    public class CoreService2 : ICoreService
    {
        public CoreName Name { get; set; }
        public void OutputHashCode()
        {
            Console.WriteLine($"CoreService2.OutputHashCode:{GetHashCode()},CoreName：{Name == null}");
        }
    }
    public class CoreName
    {

    }
}
