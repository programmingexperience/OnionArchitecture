using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.Service.Interfaces;
using OA.Repo.UoW;
using OA.Data.Model;

namespace OA.Service.Services
{
    public class LoggerSrvc : ILoggerSrvc
    {
        private readonly IGenericUoW _UoW;
        public LoggerSrvc(IGenericUoW UoW)
        {
            _UoW = UoW;
        }
        public void Insert(Log log)
        {
            _UoW.GenericRepository<Log>().Insert(log);
            _UoW.SaveChanges();
        }
    }
}
