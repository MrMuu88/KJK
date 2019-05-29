﻿// <auto-generated />
using System;
using KJK.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KJK.Data.Migrations
{
    [DbContext(typeof(KJKDBContext))]
    partial class KJKDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("KJK.Model.Choice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ParagraphID");

                    b.Property<int>("Reference");

                    b.Property<bool>("Special");

                    b.Property<string>("Text");

                    b.HasKey("ID");

                    b.HasIndex("ParagraphID");

                    b.ToTable("Choices");
                });

            modelBuilder.Entity("KJK.Model.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<bool>("IsConsumable");

                    b.Property<int>("MaxStack");

                    b.Property<string>("Name");

                    b.Property<int?>("ParagraphID");

                    b.Property<int>("Slot");

                    b.Property<int>("Type");

                    b.Property<float>("Weight");

                    b.HasKey("ID");

                    b.HasIndex("ParagraphID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("KJK.Model.Monster", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Charisma");

                    b.Property<string>("Description");

                    b.Property<int>("Dexterity");

                    b.Property<int>("Health");

                    b.Property<int>("Intelect");

                    b.Property<int>("Mana");

                    b.Property<string>("Name");

                    b.Property<int?>("ParagraphID");

                    b.Property<int>("Stamina");

                    b.Property<int>("Strength");

                    b.Property<int>("Wisdom");

                    b.HasKey("ID");

                    b.HasIndex("ParagraphID");

                    b.ToTable("Monsters");
                });

            modelBuilder.Entity("KJK.Model.Paragraph", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("SpecialEvent");

                    b.Property<string>("Text");

                    b.HasKey("ID");

                    b.ToTable("Paragraphs");
                });

            modelBuilder.Entity("KJK.Model.Choice", b =>
                {
                    b.HasOne("KJK.Model.Paragraph", "Paragraph")
                        .WithMany("Choices")
                        .HasForeignKey("ParagraphID");
                });

            modelBuilder.Entity("KJK.Model.Item", b =>
                {
                    b.HasOne("KJK.Model.Paragraph")
                        .WithMany("Items")
                        .HasForeignKey("ParagraphID");
                });

            modelBuilder.Entity("KJK.Model.Monster", b =>
                {
                    b.HasOne("KJK.Model.Paragraph")
                        .WithMany("Monsters")
                        .HasForeignKey("ParagraphID");
                });
#pragma warning restore 612, 618
        }
    }
}
