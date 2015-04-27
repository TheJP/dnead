using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console
{
    public class Inventory
    {
        private readonly QualityItemFactory factory = new QualityItemFactory();
        public readonly IList<QualityItem> Items;

        public Inventory(Item singleItem)
        {
            Items = new List<QualityItem>
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
            //foreach (Item item in Items)
            //{
            //    if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
            //    {
            //        if (item.Quality > 0)
            //        {
            //            if (item.Name != "Sulfuras, Hand of Ragnaros")
            //            {
            //                item.Quality = item.Quality - 1;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (item.Quality < 50)
            //        {
            //            item.Quality = item.Quality + 1;

            //            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            //            {
            //                if (item.SellIn < 11)
            //                {
            //                    if (item.Quality < 50)
            //                    {
            //                        item.Quality = item.Quality + 1;
            //                    }
            //                }

            //                if (item.SellIn < 6)
            //                {
            //                    if (item.Quality < 50)
            //                    {
            //                        item.Quality = item.Quality + 1;
            //                    }
            //                }
            //            }
            //        }
            //    }

            //    if (item.Name != "Sulfuras, Hand of Ragnaros")
            //    {
            //        item.SellIn = item.SellIn - 1;
            //    }

            //    if (item.SellIn < 0)
            //    {
            //        if (item.Name != "Aged Brie")
            //        {
            //            if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
            //            {
            //                if (item.Quality > 0)
            //                {
            //                    if (item.Name != "Sulfuras, Hand of Ragnaros")
            //                    {
            //                        item.Quality = item.Quality - 1;
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                item.Quality = item.Quality - item.Quality;
            //            }
            //        }
            //        else
            //        {
            //            if (item.Quality < 50)
            //            {
            //                item.Quality = item.Quality + 1;
            //            }
            //        }
            //    }
            //}
        }
    }
}