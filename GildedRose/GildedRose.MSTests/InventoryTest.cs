using System.Collections.Generic;
using GildedRose.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.MSTests
{
	[TestClass]
	public class InventoryTest
	{
		
		[TestMethod]
		public void should_never_changes_quailty_of_Sulfuras()
		{
			Item sulfuras = new Item("Sulfuras, Hand of Ragnaros", 0, 80);

			Inventory sut = new Inventory(sulfuras);

			sut.UpdateQuality();

			Assert.AreEqual(80, sulfuras.Quality);


		}
		[TestMethod]
		public void should_never_changes_sellIn_of_Sulfuras()
		{
			Item sulfuras = new Item("Sulfuras, Hand of Ragnaros", 0, 80);

			Inventory sut = new Inventory(sulfuras);

			sut.UpdateQuality();

			Assert.AreEqual(0, sulfuras.SellIn);


		}



		[TestMethod]
		public void should_lower_the_sellIn_by_one_for_normal_items()
		{
			Item normalItem = new Item("+5 Dexterity Vest", 10, 20);

			Inventory sut = new Inventory(normalItem);

			sut.UpdateQuality();


			Assert.AreEqual(9, normalItem.SellIn);
		}

		[TestMethod]
		public void should_lower_the_quality_by_one_for_normal_items()
		{
			Item normalItem = new Item("+5 Dexterity Vest", 10, 20);

			Inventory sut = new Inventory(normalItem);

			sut.UpdateQuality();


			Assert.AreEqual(19, normalItem.Quality);
		}

		[TestMethod]
		public void should_not_lower_the_quality_below_zero()
		{
			Item normalItem = new Item("+5 Dexterity Vest", 10, 0);

			Inventory sut = new Inventory(normalItem);

			sut.UpdateQuality();


			Assert.AreEqual(0, normalItem.Quality);
		}

		[TestMethod]
		public void should_lower_the_quality_twice_as_fast_once_the_sell_in_date_has_passed()
		{
			Item normalItem = new Item("+5 Dexterity Vest", -1, 25);

			Inventory sut = new Inventory(normalItem);

			sut.UpdateQuality();

			Assert.AreEqual(23, normalItem.Quality);
		}


		[TestMethod]
		public void should_increase_the_quality_of_aged_brie_as_it_gets_older()
		{
			Item agedBrie = new Item("Aged Brie", 10, 25);

			Inventory sut = new Inventory(agedBrie);

			sut.UpdateQuality();


			Assert.AreEqual(26, agedBrie.Quality);
		}


		[TestMethod]
		public void should_Increase_Quality_by_2_of_brie()
		{
			Item agedBrie = new Item("Aged Brie", 0, 0);

			Inventory sut = new Inventory(agedBrie);

			sut.UpdateQuality();

			Assert.AreEqual(2, agedBrie.Quality);
		}

		[TestMethod]
		public void should_Increase_Quality_by_2_of_JackFruit()
		{
			// Arrange
			Item item = new Item("JackFruit", 1, 0);

			// Act
			new Inventory(item).UpdateQuality();
			
			// Assert
			Assert.AreEqual(2, item.Quality);
		}


		[TestMethod]
		public void should_not_increase_the_quality_of_aged_brie_over_50()
		{
			Item agedBrie = new Item("Aged Brie", 10, 50);

			Inventory sut = new Inventory(agedBrie);

			sut.UpdateQuality();


			Assert.AreEqual(50, agedBrie.Quality);
		}

		[TestMethod]
		public void should_lower_backstage_passes_to_zero_quality_once_concert_has_happened()
		{
			Item backStagePass = new Item("Backstage passes to a TAFKAL80ETC concert", -1, 20);

			Inventory sut = new Inventory(backStagePass);

			sut.UpdateQuality();


			Assert.AreEqual(0, backStagePass.Quality);
		}

		[TestMethod]
		public void should_increase_backstage_passes_quality_by_1_when_the_concert_is_more_than_10_days_away()
		{
			Item backStagePass = new Item("Backstage passes to a TAFKAL80ETC concert", 11, 20);

			Inventory sut = new Inventory(backStagePass);

			sut.UpdateQuality();


			Assert.AreEqual(21, backStagePass.Quality);
		}

		[TestMethod]
		public void should_increase_backstage_passes_quality_by_2_when_the_concert_is_10_days_or_less_away()
		{
			Item backStagePass = new Item("Backstage passes to a TAFKAL80ETC concert", 10, 27);

			Inventory sut = new Inventory(backStagePass);

			sut.UpdateQuality();
			
			Assert.AreEqual(29, backStagePass.Quality);
		}

		[TestMethod]
		public void should_increase_backstage_passes_quality_by_2_when_the_concert_is_6_days_or_less_away()
		{
			Item backStagePass = new Item("Backstage passes to a TAFKAL80ETC concert", 6, 0);

			Inventory sut = new Inventory(backStagePass);

			sut.UpdateQuality();


			Assert.AreEqual(2, backStagePass.Quality);
		}


		[TestMethod]
		public void should_increase_backstage_passes_quality_by_3_when_the_concert_is_5_days_or_less_away()
		{
			Item backStagePass = new Item("Backstage passes to a TAFKAL80ETC concert", 5, 44);

			Inventory sut = new Inventory(backStagePass);

			sut.UpdateQuality();


			Assert.AreEqual(47, backStagePass.Quality);
		}

		[TestMethod]
		public void should_not_increase_backstage_passes_above_a_quality_of_50()
		{
			Item backStagePassMoreThan10DaysAway = new Item("Backstage passes to a TAFKAL80ETC concert", 15, 50);

			Item backStagePass10DaysAway = new Item("Backstage passes to a TAFKAL80ETC concert", 5, 49);
			Item backStagePass5DaysAway = new Item("Backstage passes to a TAFKAL80ETC concert", 5, 48);

			Inventory sut = new Inventory(new List<Item>{ backStagePassMoreThan10DaysAway, backStagePass10DaysAway, backStagePass5DaysAway});

			sut.UpdateQuality();


			Assert.AreEqual(50, backStagePassMoreThan10DaysAway.Quality);
			Assert.AreEqual(50, backStagePass10DaysAway.Quality);
			Assert.AreEqual(50, backStagePass5DaysAway.Quality);
		}































		//[TestMethod]
		//public void should_decrease_Conjured_quality_twice_as_fast()
		//{
		//	var item = new Item("Conjured Mana Cake", 1, quality: 4);
		//	new Inventory(item).UpdateQuality();
		//	Assert.AreEqual(2, item.Quality);

		//	//RunUpdateQuality_AndAssertOnQuality(new Item(C.Conjured, 1, 1), 0);
		//	//RunUpdateQuality_AndAssertOnQuality(new Item(C.Conjured, 1, 2), 0);
		//	//RunUpdateQuality_AndAssertOnQuality(new Item(C.Conjured, 1, 3), 0);


		//}

		//private static void RunUpdateQuality_AndAssertOnQuality(Item item, int expectedQuality)
		//{
		//	new Inventory(item).UpdateQuality();

		//	Assert.AreEqual(expectedQuality, item.Quality);
		//}



	}
}
