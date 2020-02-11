using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreDIDemo.Services
{
    /// <summary>
    /// 每次都获取新实例
    /// </summary>
    public interface ITransientService { }
    public class TransientService: ITransientService
    {
    }
}
