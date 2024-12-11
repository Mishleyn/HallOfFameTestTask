﻿// <auto-generated />
using System;
using HallOfFameTestTask.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HallOfFameTestTask.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20241211070418_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("HallOfFameTestTask.Domain.Model.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("SkillsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("HallOfFameTestTask.Domain.Model.Person", b =>
                {
                    b.OwnsMany("HallOfFameTestTask.Domain.Model.Skill", "Skills", b1 =>
                        {
                            b1.Property<long>("PersonId")
                                .HasColumnType("INTEGER");

                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("TEXT");

                            b1.Property<byte>("Level")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("PersonId", "Id");

                            b1.ToTable("Skills");

                            b1.WithOwner()
                                .HasForeignKey("PersonId");
                        });

                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}
