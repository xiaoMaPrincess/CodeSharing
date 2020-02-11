using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreDIDemo.Services
{
    /// <summary>
    /// 全局单例
    /// </summary>
    public interface ISingletonService { }
    public class SingletonService:ISingletonService
    {
    }
}
