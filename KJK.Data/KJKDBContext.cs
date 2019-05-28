﻿using KJK.Model;
using Microsoft.EntityFrameworkCore;

namespace KJK.Data {
	public class KJKDBContext :DbContext{
		private string constr;

		DbSet<Paragraph> Paragraphs { get; set; }
		DbSet<Choice> Choices { get; set; }
		DbSet<Item> Items { get; set; }
		DbSet<Monster> Monsters { get; set; }

		public KJKDBContext() {
			constr = @"Data Source=D:\Projects\KJK\KJK.db";
		}
		public KJKDBContext(string connectionString = @"Data Source=D:\Projects\KJK\KJK.db") {
			constr = connectionString;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlite(constr);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			//Fluent API modifications
			base.OnModelCreating(modelBuilder);
		}
	}

}
