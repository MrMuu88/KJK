using System.Collections;
using System.Collections.Generic;

namespace KJK.Data.Models {

	public class Player {
		#region Fields,Properties,Events ##############################################################

		public ICollection<Item> Inventory { get; set; }
			

		#endregion

		#region Methods, Tasks, commands ##############################################################

		public void Rest() { }

		public void UseItem() { }


		#endregion

		#region Ctors #################################################################################

		public Player() { }

		#endregion
	}//clss

	
}//ns
