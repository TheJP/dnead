using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console
{
    public class Inventory
    {
        private readonly QualityItemFactory factory = new QualityItemFactory();
        public readonly IList<IQualityItem> Items;

        public Inventory(Item singleItem)
        {
            Items = new List<IQualityItem>
            {
                factory.CreateQualityItem(singleItem)
            };
        }

        public Inventory(List<Item> list)
        {
            Items = list.Select(i => factory.CreateQualityItem(i)).ToList();
        }

        public Inventory()
        {
        }

        public void AddItem(Item item)
        {
            Items.Add(factory.CreateQualityItem(item));
        }


        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                item.UpdateQuality();
                item.UpdateSellIn();
            }
        }
    }
}