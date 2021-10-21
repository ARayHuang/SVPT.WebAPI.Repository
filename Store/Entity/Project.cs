using System;
using System.Collections.Generic;

namespace SVPT.WebAPI.Store.Entity
{
    public class Project : Default
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
