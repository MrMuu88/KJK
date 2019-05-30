using KJK.Model;
using System.Collections.Generic;

namespace KJK.DataManager.ViewModels.ModelWrappers {

	public class MonsterWrapper : ViewModelBase {
		#region Fields,Properties,Events ##############################################################

		private int iD;
		private Monster Model { get; set; }

		public int ID { get => iD; private set => iD = value; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Health { get; set; }
		public int Mana { get; set; }
		public int Stamina { get; set; }
		public int Strength { get; set; }
		public int Dexterity { get; set; }
		public int Intelect { get; set; }
		public int Wisdom { get; set; }
		public int Charisma { get; set; }



		#endregion

		#region Methods, Tasks, commands ##############################################################



		#endregion

		#region Ctors #################################################################################

		public MonsterWrapper(Monster model) {
			Model = model;

			ID = Model.ID;
			Name = Model.Name;
			Description = Model.Description;
			Health = Model.Health;
			Mana = Model.Mana;
			Stamina = Model.Stamina;
			Strength = Model.Strength;
			Dexterity = Model.Dexterity;
			Intelect = Model.Intelect;
			Wisdom = Model.Wisdom;
			Charisma = Model.Charisma;
			
		}

		#endregion
	}//clss

}//ns
