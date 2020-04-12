using KJK.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KJK.Server.ViewModels
{
	public class ParagraphViewModel:BaseViewModel<Paragraph>
	{

		public int Id { get => Model.Id; internal set => Model.Id = value; }
		public string Text { get => Model.Text; set => Model.Text = value; }
		public ICollection<Choice> Choices { get => Model.Choices; set => Model.Choices = value; }

		public ICollection<ItemViewModel> Items{
			get => Model.Items.Select(i => new ItemViewModel(i)).ToList();
			set => Model.Items = value.Select(ivm => ivm.Model).ToList();
		}

		public ICollection<MonsterViewModel> Monsters
		{
			get => Model.Monsters.Select(m => new MonsterViewModel(m)).ToList();
			set => Model.Monsters = value.Select(mvm => mvm.Model).ToList();
		}

		public ParagraphViewModel(Paragraph model) : base(model) { }

}
}
