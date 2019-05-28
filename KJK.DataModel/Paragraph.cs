using System.Collections.Generic;

namespace KJK.Model {
    public class Paragraph{

        public int ID { get; set; }
        public string Text { get; set; }
        public ICollection<Choice> Choices { get; set; } = new List<Choice>();
        public ICollection<Monster> Monsters { get; set; } = new List<Monster>();
        public ICollection<Item> Items { get; set; } = new List<Item>();
        public bool SpecialEvent { get; set; }
        
	}
}
