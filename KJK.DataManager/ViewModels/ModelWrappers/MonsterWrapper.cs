using KJK.Model;

namespace KJK.DataManager.ViewModels.ModelWrappers {

	public class MonsterWrapper : WrapperBase<Monster> {
		#region Fields,Properties,Events ##############################################################

		private bool modified;
		private string name;
		private string description;
		private int health;
		private int mana;
		private int stamina;
		private int strength;
		private int dexterity;
		private int intelect;
		private int wisdom;
		private int charisma;


		public int ID { get; private set; }

		public string DisplayMember { get => $"{ID} {Name} {((Modified)?"*":"")}"; }

		public bool ShouldRemove { get; set; } = false;

		public bool Modified {
			get => modified; 
			set { modified = value;
				RaisePropertyChanged();
				RaisePropertyChanged(nameof(DisplayMember));
			}
			
		}
		public string Name { 
			get => name; 
			set { name = value;
				RaisePropertyChanged();
				Modified = true;
			}
		}
		public string Description { 
			get => description; 
			set { description = value;
				RaisePropertyChanged();
				Modified = true;
			}
		}
		public int Health { 
			get => health; 
			set { health = value;
				RaisePropertyChanged();
				Modified = true;
			}
		}

		public int Mana { 
			get => mana; 
			set { mana = value;
				RaisePropertyChanged();
				Modified = true;
			}
		}
		public int Stamina { 
			get => stamina; 
			set { stamina = value;
				RaisePropertyChanged();
				Modified = true;
			}
		}
		public int Strength { 
			get => strength; 
			set { strength = value;
				RaisePropertyChanged();
				Modified = true;
			}
		}
		public int Dexterity { 
			get => dexterity; 
			set { dexterity = value;
				RaisePropertyChanged();
				Modified = true;
			}
		}
		public int Intelect { 
			get => intelect; 
			set { intelect = value;
				RaisePropertyChanged();
				Modified = true;
			}
		}
		public int Wisdom { 
			get => wisdom; 
			set { wisdom = value;
				RaisePropertyChanged();
				Modified = true;
			}
		}
		public int Charisma {
			get => charisma; 
			set { charisma = value;
				RaisePropertyChanged();
				Modified = true;
			}
		}



		#endregion

		#region Methods, Tasks, commands ##############################################################

		public override void Presist() {
			Model.ID = ID;
			Model.Name = Name;
			Model.Description = Description;
			Model.Health = Health;
			Model.Mana = Mana;
			Model.Stamina = Stamina;
			Model.Strength = Strength;
			Model.Dexterity = Dexterity;
			Model.Intelect = Intelect;
			Model.Wisdom = Wisdom;
			Model.Charisma = Charisma;
			Modified = false;
		}

		public override void Reset() {
			ID = Model.ID;
			name = Model.Name;
			description = Model.Description;
			health = Model.Health;
			mana = Model.Mana;
			stamina = Model.Stamina;
			strength = Model.Strength;
			dexterity = Model.Dexterity;
			intelect = Model.Intelect;
			wisdom = Model.Wisdom;
			charisma = Model.Charisma;
			Modified = false;
		}

		#endregion

		#region Ctors #################################################################################

		public MonsterWrapper(Monster model) {
			if (model != null) {
				Model = model;
				Reset();
			} else {
				Model = new Monster();
				Modified = true;
			}
		}

		#endregion
	}//clss

}//ns
