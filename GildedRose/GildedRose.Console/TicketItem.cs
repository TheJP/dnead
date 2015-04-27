using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    public class TicketItem : InversedQualityItem
    {
        public const int STEP_ONE = 11;
        public const int STEP_TWO = 6;
        public TicketItem(Item item) : base(item)
        {
        }

        public override void UpdateQuality()
        {
            base.UpdateQuality();
            if (SellIn < STEP_ONE)
            {
                Quality += 1;
            }
            if (SellIn < STEP_TWO)
            {
                Quality += 1;
            }
        }
        public override void UpdateSellIn()
        {
            SellIn -= 1;
            if (SellIn <= 0)
            {
                Quality = 0;
            }
        }
    }
}
