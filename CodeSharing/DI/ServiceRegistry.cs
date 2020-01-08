using System;
using System.Collections.Generic;
using System.Text;

namespace DI
{
    /// <summary>
    /// 服务注册
    /// </summary>
    class ServiceRegistry
    {
        public Type ServiceType { get; set; }
    }
    public enum LifeTime { 
        Transient,
        Scoped,
        Singleton
    }
}
