using System;
using System.Collections.Generic;

namespace DeductibleApi.Models
{
    public class DeductibleItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string[] Dependents { get; set; }
    }
}
