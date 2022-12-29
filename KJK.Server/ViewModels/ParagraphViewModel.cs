using KJK.Data.Models;
using System.Collections.Generic;

namespace KJK.Server.ViewModels
{
	public class ParagraphViewModel:BaseViewModel
	{

		public int Id { get; set; }
		public string Text {get;set;}
		public ICollection<Choice> Choices {get;set;}

	}
}
