namespace KJK.Model {
    public class Item {
		
		public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public Paragraph Paragraph { get; set; }
    }
}
