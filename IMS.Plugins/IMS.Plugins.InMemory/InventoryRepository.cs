using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly List<Inventory> _inventory;

        public InventoryRepository()
        {
            _inventory = new List<Inventory>()
            {
                new Inventory{InventoryId =1,InventoryName = "Bike Seat", Quantity = 10, Price = 2 },
                new Inventory{InventoryId =2,InventoryName = "Bike Body", Quantity = 10, Price = 15 },
                new Inventory{InventoryId =3,InventoryName = "Bike Wheels", Quantity = 20, Price = 8 },
                new Inventory{InventoryId =4,InventoryName = "Bike pedals", Quantity = 20, Price = 1 }
            };
        }

        public Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            IEnumerable<Inventory> result;
            if (string.IsNullOrWhiteSpace(name))
                result = _inventory;
            else
                result = _inventory.Where(x => x.InventoryName != null && x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));

            return Task.FromResult(result);
        }
    }
}
