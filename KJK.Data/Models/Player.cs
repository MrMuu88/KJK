using System.Collections.Generic;

namespace KJK.Data.Models
{

	public class Player:CharacterBase{
		public ICollection<Item> Inventory { get; set; }


	}//clss
}//ns
