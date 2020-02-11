using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreDIDemo.Services
{
    /// <summary>
    /// 同一请求内单例
    /// </summary>
    public interface IScopedService { }
    public class ScopedService:IScopedService
    {

    }
}
