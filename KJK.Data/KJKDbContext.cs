﻿using KJK.Data.Configurations;
using KJK.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KJK.Data {
	public class KJKDbContext :DbContext{
		public DbSet<Paragraph> Paragraphs { get; set; }
		public DbSet<Item> Items { get; set; }
		public DbSet<Monster> Monsters { get; set; }

		public KJKDbContext(DbContextOptions options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration(new ParagraphConfiguration());
		}
	}

}
