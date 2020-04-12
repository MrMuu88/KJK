namespace KJK.Data.Models {
	public class Choice{
		public string Text { get; set; }
		public int Reference { get; set; }
		public bool Special { get; set; }

		public Choice(string txt, int reference)
		{
			Text = txt;
			Reference = reference;
		}
	}
}
