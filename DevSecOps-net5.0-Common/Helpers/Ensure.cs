using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace DevSecOps_net5._0_Common.Helpers
{
    public static class Ensure
    {
        [DebuggerStepThrough]
        public static T NotNull<T>(Expression<Func<T>> memberToCheckForNull) where T : class
        {
            if (memberToCheckForNull == null)
            {
                throw new NullReferenceException("No value given to check for null!");
            }
            var compiledExpression = memberToCheckForNull.Compile();
            var result = compiledExpression(); 
            if (compiledExpression() == null)
            {
                throw new ArgumentNullException((memberToCheckForNull.Body as MemberExpression)?.Member.Name);
            }

            return result;
        }
    }
}