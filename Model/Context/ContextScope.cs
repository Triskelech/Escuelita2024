using Microsoft.EntityFrameworkCore;
using Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Context
{
    public class ContextScope<TContext> : IContextScope<TContext> where TContext : EscuelitaContext
    {
        private readonly EscuelitaContext _dbcontext;
        public bool IsDisposed { get; }

        public ContextScope(EscuelitaContext context)
        {
            _dbcontext = context;
        }

        public EscuelitaContext DbContext => _dbcontext;

        public EscuelitaContext GetContext()
        {
            //if (_dbcontext == null)
            //{
            //    if (_initializer != null)
            //    {
            //        _dbcontext = new SimaContext(_connectionStringName, _initializer);
            //    }
            //    else
            //    {
            //        _dbcontext = new SimaContext(_connectionStringName, _dropCreateSchema, _migrations);
            //    }

            //    _dbcontext.SaveChangesWhenDispose = true;
            //}

            //var logger = LogManager.GetLogger("EntityFramework");
            //_dbcontext.Database.Log = s => logger.Debug(s);

            return _dbcontext;
        }

        public virtual void Dispose()
        {
            GetContext().Dispose();

            //_dbcontext = null;
            //_disposed = true;
        }
    }
}
