using System.Runtime.CompilerServices;
namespace KJK.DataManager.Helpers {

	public class LookupItem {
		#region Fields,Properties,Events ##############################################################
		public bool Modified { get; set; }

		public int ID { get; private set; }

		private string _displayMember;

		public string DisplayMember {
			get { return _displayMember+((Modified)?"*":""); }
			private set { _displayMember = value; }
		}



		#endregion

		#region Methods, Tasks, commands ##############################################################



		#endregion

		#region Ctors #################################################################################

		public LookupItem(int id,string displayMember) {
			ID = id;
			DisplayMember = displayMember;
		}

		#endregion
	}//clss

}//ns
