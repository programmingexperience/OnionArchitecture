using OA.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface ILoggerSrvc
    {
        void Insert(Log log);
    }
}
