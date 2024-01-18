using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Context
{
    public static class ScopeManager<TContext> where TContext : EscuelitaContext
    {
        private static Func<IContextScope<TContext>> _resolver;
        private static IContextScope<TContext> _currentScope;

        public static void Initialize(Func<IContextScope<TContext>> resolver)
        {
            _resolver = resolver;
        }

        public static IContextScope<TContext> Current
        {
            get
            {
                if (_currentScope != null && !_currentScope.IsDisposed)
                {
                    return _currentScope;
                }
                else if (_resolver != null)
                {
                    return _resolver.Invoke();
                }
                else
                {
                    throw new Exception("Could not create a ContextScope");
                }
            }
        }
    }
}
