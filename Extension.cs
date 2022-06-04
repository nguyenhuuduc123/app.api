using Catalog.Dto;
using Catalog.Entities;

namespace Catalog {
    public static class Extension{
        public static ItemDto AsDto(this Item  i){
           return  new ItemDto{
                Id = i.Id,
                Name = i.Name,
                Price = i.Price,
                CreatedDate = i.CreatedDate};
        }
    }
}