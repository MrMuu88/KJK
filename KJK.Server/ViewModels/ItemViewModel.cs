using KJK.Data.Models;

namespace KJK.Server.ViewModels
{
	public class ItemViewModel :BaseViewModel
	{
		public string Description { get; set; }
		public bool IsConsumable {get;set;}
		public int MaxStack {get;set;}
		public string Name {get;set;}
		public ItemSlot Slot {get;set;}
		public ItemType Type {get;set;}
		public float Weight {get;set;}

	}
}