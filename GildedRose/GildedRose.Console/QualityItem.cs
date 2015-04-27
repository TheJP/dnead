using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    public abstract class QualityItem
    {
        public const int MAX_QUALITY = 50;
        public const int MIN_QUALITY = 0;
        private Item Item { get; set; }
        protected QualityItem(Item item)
        {
            this.Item = item;
        }
        public string Name { get { return Item.Name; } set { Item.Name = value; } }

        public int SellIn { get { return Item.SellIn; } set { Item.SellIn = value; } }

        public int Quality
        {
            get { return Item.Quality; }
            set
            {
                if (value > MAX_QUALITY)
                {
                    Item.Quality = MAX_QUALITY;
                }
                else if (value < MIN_QUALITY)
                {
                    Item.Quality = MIN_QUALITY;
                }
                else
                {
                    Item.Quality = value;
                }
            }
        }

        public abstract void UpdateQuality();
        public abstract void UpdateSellIn();
    }
}
