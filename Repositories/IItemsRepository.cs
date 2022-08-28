using System;
using Catalog.Entities;

namespace Catalog.Repository
{
    public interface IItemsRepository
    {
        Item GetItem(Guid id);

        IEnumerable<Item> GetItems();
    }
}