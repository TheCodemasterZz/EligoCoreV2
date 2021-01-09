using System;
using System.Collections.Generic;

namespace EligoCore.Domain.Entities.References
{
    public class RefCountry : EntityWithKey<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public RefCountry()
        {
        }

        public RefCountry(string name, string code)
        {
            Name = name;
            Code = code;
        }
    }
}