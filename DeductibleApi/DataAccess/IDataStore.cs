using DeductibleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeductibleApi.DataAccess
{
    public interface IDataStore
    {
        void AddItem(DeductibleItem item);
        DeductibleItem GetItem(long id);
    }
}
