namespace KJK.Data.Models {
	public class Item : BaseModel
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public float Weight { get; set; }
		public int MaxStack { get; set; }
		public bool IsConsumable { get; set; }
		public ItemSlot Slot { get; set; }
		public ItemType Type { get; set; }

		
	}

}
