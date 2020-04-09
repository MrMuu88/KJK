namespace KJK.Data.Models {
	public class Choice : BaseModel{
		public string Text { get; set; }
		public int Reference { get; set; }
		public bool Special { get; set; }
		public Paragraph Paragraph { get; set; }
	}
}
