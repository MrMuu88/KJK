namespace KJK.Model {
	public class Item {

		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public ItemType Type { get; set; }

		public float Weight { get; set; }

		public int MaxStack { get; set; }
		public bool IsConsumable { get; set; }
		public ItemSlot Slot { get; set; }

		
	}

	public enum ItemSlot {None,Head,Chest,Legs,Boots,MainHand,Offhand,TwoHand,Trinket}
	public enum ItemType {Junk,Armor,Weapon,Consumable,Quest}
}
