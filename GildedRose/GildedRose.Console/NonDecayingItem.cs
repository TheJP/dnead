using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    class NonDecayingItem : QualityItem
    {
        public NonDecayingItem(Item item) : base(item)
        {
        }

        public override void UpdateQuality()
        {
            //Quality and SellIn remain the same
        }

        public override void UpdateSellIn()
        {
            //Quality and SellIn remain the same
        }
    }
}
