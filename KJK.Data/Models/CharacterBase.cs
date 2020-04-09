namespace KJK.Data.Models {

	public class CharacterBase: BaseModel
	{
		public string Name { get; set; }

		public int Strength { get; set; }
		public int Stamina { get; set; }
		public int Dexterity { get; set; }
		public int Intelect { get; set; }
		public int Wisdom { get; set; }
		public int Charisma { get; set; }

		public int Health { get; set; }
		public int Mana { get; set; }

	}//clss

}//ns
