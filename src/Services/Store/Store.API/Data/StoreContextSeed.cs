using MongoDB.Driver;
using Store.API.Entities;

namespace Store.API.Data
{
    public class StoreContextSeed
    {
        public static void SeedData(IMongoCollection<Item> itemCollection)
        {
            bool existProduct = itemCollection.Find(p => true).Any();

            if (!existProduct)
            {
                itemCollection.InsertManyAsync(GetPreconfiguredItems());
            }
        }

        private static IEnumerable<Item> GetPreconfiguredItems()
        {
            return new List<Item>()
            {
                new Item()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "IPhone X",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    Price = 950.00M,
                    Quantity = 2,
                    Category = "Smart Phone",
                    IsAvailable = true
                },
                new Item()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Samsung 10",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    Price = 840.00M,
                    Quantity = 3,
                    Category = "Smart Phone",
                    IsAvailable = false
                },
                new Item()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Huawei Plus",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    Price = 650.00M,
                    Quantity = 4,
                    Category = "White Appliances",
                    IsAvailable = true
                },
                new Item()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Xiaomi Mi 9",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    Price = 470.00M,
                    Quantity = 1,
                    Category = "White Appliances",
                    IsAvailable = true
                },
                new Item()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "HTC U11+ Plus",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    Price = 380.00M,
                    Quantity = 3,
                    Category = "Smart Phone",
                    IsAvailable = true
                },
                new Item()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "LG G7 ThinQ",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    Price = 240.00M,
                    Quantity = 5,
                    Category = "Home Kitchen",
                    IsAvailable = true
                }
            };
        }
    }
}
