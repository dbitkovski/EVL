﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model;

namespace Model.Migrations
{
    [DbContext(typeof(EvlContext))]
    [Migration("20191219092032_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity("Model.Entites.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Property");

                    b.Property<string>("QuestionText");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Model.Entites.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<double>("Probability");

                    b.HasKey("Id");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("Model.Entites.Weight", b =>
                {
                    b.Property<int>("ResultId");

                    b.Property<int>("QuestionId");

                    b.Property<double>("PMinus");

                    b.Property<double>("PPlus");

                    b.HasKey("ResultId", "QuestionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Weights");
                });

            modelBuilder.Entity("Model.Entites.Weight", b =>
                {
                    b.HasOne("Model.Entites.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Model.Entites.Result", "Result")
                        .WithMany("Weights")
                        .HasForeignKey("ResultId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
