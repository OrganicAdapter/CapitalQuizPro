using System;
using System.Collections.Generic;
using System.Text;
using UniversalExtensions.Navigation;

namespace CapitalQuiz.Implementations
{
    public class TypeService : ITypeService
    {
        public Type GetType(string type)
        {
            return Type.GetType(type);
        }
    }
}
