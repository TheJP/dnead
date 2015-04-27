using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    class QualityItemFactory
    {
        public QualityItem CreateQualityItem(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    return new InversedQualityItem(item);
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new TicketItem(item);
                case "Sulfuras, Hand of Ragnaros":
                    return new NonDecayingItem(item);
                default:
                    return new DefaultQualityItem(item);
            }
        }
    }
}
