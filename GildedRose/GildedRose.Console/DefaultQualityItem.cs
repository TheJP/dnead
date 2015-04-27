using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    public class DefaultQualityItem : QualityItemBase
    {
        public DefaultQualityItem(Item item) : base(item)
        {
        }

        public override void UpdateQuality()
        {
            Quality -= 1;
        }

        public override void UpdateSellIn()
        {
            SellIn -= 1;
            if (SellIn < 0)
            {
                Quality -= 1;
            }
        }
    }
}
