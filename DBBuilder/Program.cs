using KJK.Data;
using KJK.Model;
using System;
using System.Collections.Generic;

namespace DBBuilder {
	class Program {
		static void Main(string[] args) {
			Console.WriteLine("Hello World!");

			IDataService dataService = new DbDataService();
			var p = new Paragraph() {
				Text="asdasd",
				SpecialEvent = false,
				Items = new List<Item>() {
					new Item(){ Description="desc",Name="some tool"},
					new Item(){ Description="desc2",Name="some tool2"},
					new Item(){ Description="desc3",Name="some tool3"},
				}
			};

			dataService.Add(p);
		}
	}
}
