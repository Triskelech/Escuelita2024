using Microsoft.EntityFrameworkCore;
using Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Context
{
    public interface IContextScope<TContext> : IDisposable where TContext : EscuelitaContext
    {
        //TContext GetContext();

        bool IsDisposed { get; }
    }
}
