using KJK.Data.Models;
using System.Collections.Generic;

namespace KJK.Server.ViewModels
{
	public class ParagraphViewModel:BaseViewModel<Paragraph>
	{

		public int Id { get => Model.Id; internal set => Model.Id = value; }
		public string Text { get => Model.Text; set => Model.Text = value; }
		public ICollection<Choice> Choices { get => Model.Choices; set => Model.Choices = value; }

		public ParagraphViewModel():this(new Paragraph()) { }
		public ParagraphViewModel(Paragraph model) : base(model) { }

}
}
