using DeductibleApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace DeductibleApi.DataAccess
{
    public class DataStore : IDataStore
    {
        private List<DeductibleItem> Items = new List<DeductibleItem>();
        private int id = 0;
        public void AddItem(DeductibleItem item) {
            item.Id = id++;
            Items.Add(item);
        }

        public DeductibleItem GetItem(long id) => Items.First(i => i.Id == id);

    }
}
