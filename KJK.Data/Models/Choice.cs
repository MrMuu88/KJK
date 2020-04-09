namespace KJK.Model {
	public class Choice{
		public int ID { get; set; }
		public string Text { get; set; }
		public int Reference { get; set; }
		public bool Special { get; set; }
		public Paragraph Paragraph { get; set; }
	}
}
