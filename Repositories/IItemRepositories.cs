namespace Catalog.Entities {
    public interface IItemRepositories
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        void CreateIteam(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Guid id);
    }
}