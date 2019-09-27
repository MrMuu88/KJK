namespace KJK.Model {

	public class CharacterBase {
		#region Fields,Properties,Events ##############################################################

		public int ID { get; set; }
		public string Name { get; set; }

		public int Strength { get; set; }
		public int Stamina { get; set; }
		public int Dexterity { get; set; }
		public int Intelect { get; set; }
		public int Wisdom { get; set; }
		public int Charisma { get; set; }


		public int Health { get; set; }
		public int Mana { get; set; }


		#endregion

		#region Methods, Tasks, commands ##############################################################



		#endregion

		#region Ctors #################################################################################

		public CharacterBase() { }

		#endregion
	}//clss

}//ns
