using KJK.Data.Models;

namespace KJK.Server.ViewModels
{
	public class MonsterViewModel : BaseViewModel<Monster>
	{
		public int Id {get=>Model.Id; set=>Model.Id=value;}
		public string Name {get=>Model.Name; set=>Model.Name=value;}
		public string Description {get=>Model.Description; set=>Model.Description=value;}
		public int Strength {get=>Model.Strength; set=>Model.Strength=value;}
		public int Stamina {get=>Model.Stamina; set=>Model.Stamina=value;}
		public int Dexterity {get=>Model.Dexterity; set=>Model.Dexterity=value;}
		public int Charisma {get=>Model.Charisma; set=>Model.Charisma=value;}
		public int Intelect {get=>Model.Intelect; set=>Model.Intelect=value;}
		public int Wisdom {get=>Model.Wisdom; set=>Model.Wisdom=value;}
		public int Health {get=>Model.Health; set=>Model.Health=value;}
		public int Mana {get=>Model.Mana; set=>Model.Mana=value;}

		public MonsterViewModel() : this(new Monster()) { }
		public MonsterViewModel(Monster model) : base(model) { }
	}
}