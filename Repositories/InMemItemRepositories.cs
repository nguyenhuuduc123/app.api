namespace Catalog.Entities{
    

    public class InMemItemRepositories : IItemRepositories
    {
        private readonly List<Item> Items = new(){
                    new Item {Id = Guid.NewGuid(),Name = "bàn chải",Price = 10000, CreatedDate = DateTimeOffset.UtcNow},
                    new Item {Id = Guid.NewGuid(),Name = "xà phòng",Price = 9000, CreatedDate = DateTimeOffset.UtcNow},
                    new Item {Id = Guid.NewGuid(),Name = "nước rửa chén",Price = 11000, CreatedDate = DateTimeOffset.UtcNow},
                    new Item {Id = Guid.NewGuid(),Name = "dao",Price = 80000, CreatedDate = DateTimeOffset.UtcNow},
            };
        public IEnumerable<Item> GetItems()
        {

            return Items;
        }
        public Item GetItem(Guid id)
        {
            return (Items.Where(i => i.Id == id).ToList()).SingleOrDefault();
        }

        public void CreateIteam(Item item)
        {
            Items.Add(item);
        }

        public void UpdateItem(Item item)
        {
           var index = Items.FindIndex(i => i.Id == item.Id);
           Items[index] = item;
           
        }

        public void DeleteItem(Guid id)
        {
             var index = Items.FindIndex(i => i.Id == id);
             Items.RemoveAt(index);
        }
    }

}