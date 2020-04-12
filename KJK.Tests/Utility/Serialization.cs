using KJK.Data.Models;
using KJK.Server.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace KJK.Tests.Utility
{
	[TestClass]
	public class Serialization
	{
		[TestMethod]
		[DynamicData(nameof(TC4Serialization), DynamicDataSourceType.Method)]
		public void SerializeModel(object model)
		{
			var jsonSettigns = new JsonSerializerSettings() {
				Formatting = Formatting.Indented,
				ReferenceLoopHandling = ReferenceLoopHandling.Serialize
			};
			var json = JsonConvert.SerializeObject(model, jsonSettigns);
			Trace.WriteLine(json);
		}

		private static IEnumerable<object[]> TC4Serialization()
		{
			var answer = new List<object[]>();

			var monster = new Monster()
			{
				Name = "Orc",
				Strength = 10,
				Dexterity = 5,
				Stamina = 8,
				Charisma = 2,
				Intelect = 3,
				Wisdom = 2,
				Health = 20,
				Mana = 3,
				Description = "A mean ass ork with a fucking big axe"
			};

			var item = new Item() { 
				Name = "Woodcutter's axe",
				Slot= ItemSlot.TwoHand,
				IsConsumable = false,
				MaxStack =1,
				Type =ItemType.Weapon,
				Weight=12,
				Description = "a big two handed axe, with a heavy one bladed head, mostly used by woodchoppers"
			};

			var paragraph = new Paragraph()
			{
				Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum laoreet tincidunt felis, nec fringilla tortor pulvinar nec. Sed eget euismod est. Morbi laoreet ullamcorper purus sed sodales. Phasellus nec lorem ante. Nunc viverra aliquam gravida. Phasellus tempor turpis venenatis, mattis turpis a, ullamcorper sem. Sed quis gravida metus. Suspendisse sit amet purus tortor.",
				SpecialEvent = false,
				Items = new List<Item>() { item},
				Monsters = new List<Monster>() {monster},
				Choices = new List<Choice>() { 
					new Choice("In tempor odio vitae ipsum viverra",2),
					new Choice("a congue dui congue",3),
					new Choice("Morbi eu sapien tristique, condimentum elit eget, congue quam",4),
				}
			};

			monster.Paragraph = paragraph;

			answer.Add(new[] { new ItemViewModel(item) });
			answer.Add(new[] { new MonsterViewModel(monster) });
			answer.Add(new[] { new ParagraphViewModel(paragraph) });
			return answer;
		}
	}
}
