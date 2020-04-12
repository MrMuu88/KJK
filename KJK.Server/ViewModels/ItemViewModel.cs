using KJK.Data.Models;

namespace KJK.Server.ViewModels
{
	public class ItemViewModel :BaseViewModel<Item>
	{
		public int Id {get=>Model.Id; set=>Model.Id=value;}
		public string Description {get=>Model.Description; set=>Model.Description=value;}
		public bool IsConsumable {get=>Model.IsConsumable; set=>Model.IsConsumable=value;}
		public int MaxStack {get=>Model.MaxStack; set=>Model.MaxStack=value;}
		public string Name {get=>Model.Name; set=>Model.Name=value;}
		public ItemSlot Slot {get=>Model.Slot; set=>Model.Slot=value;}
		public ItemType Type {get=>Model.Type; set=>Model.Type=value;}
		public float Weight {get=>Model.Weight; set=>Model.Weight=value;}

		public ItemViewModel() : this(new Item()) { }

		public ItemViewModel(Item model) : base(model) { }
	}
}