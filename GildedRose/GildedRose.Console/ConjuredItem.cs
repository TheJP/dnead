using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    public class ConjuredItem : IQualityItem
    {
        private QualityItemBase QualityItemBase { get; set; }
        public ConjuredItem(QualityItemBase itemBase)
        {
            this.QualityItemBase = itemBase;
        }

        public void UpdateQuality()
        {
            //Converged effect: Quality is updated twice
            QualityItemBase.UpdateQuality();
            QualityItemBase.UpdateQuality();
        }

        public void UpdateSellIn()
        {
            QualityItemBase.UpdateSellIn();
        }
    }
}
