using System;

namespace MafiaGame.Services.impl
{
    public class Validation
    {
        public static void RequireNonNull(Object obj, string paramName)
        {
            if(obj == null) throw new ArgumentNullException(paramName);
        }
    }
}