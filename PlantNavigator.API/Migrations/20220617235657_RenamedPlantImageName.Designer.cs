﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlantNavigator.API.DbContexts;

#nullable disable

namespace PlantNavigator.API.Migrations
{
    [DbContext(typeof(PlantNavigatorContext))]
    [Migration("20220617235657_RenamedPlantImageName")]
    partial class RenamedPlantImageName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PlantNavigator.API.Entities.Classification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClassificationType")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Classifications");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.Disease", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("Diseases");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.FertilizerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("FertilizerTypes");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.FertilizingHabit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DaysFrequency")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TimeFrom")
                        .HasColumnType("int");

                    b.Property<int?>("TimeTo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FertilizingHabits");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.JoinEntities.FertilizingHabit_FertilizerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FertilizerTypeId")
                        .HasColumnType("int");

                    b.Property<int>("FertilizingHabitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FertilizerTypeId");

                    b.HasIndex("FertilizingHabitId");

                    b.ToTable("FertilizingHabits_FertilizerTypes");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.JoinEntities.Plant_Classification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClassificationId")
                        .HasColumnType("int");

                    b.Property<int>("PlantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassificationId");

                    b.HasIndex("PlantId");

                    b.ToTable("Plants_Classifications");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.JoinEntities.Plant_Disease", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Condition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiseaseId")
                        .HasColumnType("int");

                    b.Property<int>("PlantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DiseaseId");

                    b.HasIndex("PlantId");

                    b.ToTable("Plants_Diseases");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.JoinEntities.Plant_FertilizingHabit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FertilizingHabitId")
                        .HasColumnType("int");

                    b.Property<int>("PlantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FertilizingHabitId");

                    b.HasIndex("PlantId");

                    b.ToTable("Plants_FertilizingHabits");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.JoinEntities.Plant_Pest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Condition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PestId")
                        .HasColumnType("int");

                    b.Property<int>("PlantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PestId");

                    b.HasIndex("PlantId");

                    b.ToTable("Plants_Pests");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.JoinEntities.Plant_Soil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Condition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlantId")
                        .HasColumnType("int");

                    b.Property<int>("SoilId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlantId");

                    b.HasIndex("SoilId");

                    b.ToTable("Plants_Soils");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.JoinEntities.Plant_WateringHabit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlantId")
                        .HasColumnType("int");

                    b.Property<int>("WateringHabitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlantId");

                    b.HasIndex("WateringHabitId");

                    b.ToTable("Plants_WateringHabits");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.LightCondition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Intensity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("LightConditions");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.Pest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("Pests");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.Plant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FloweringFrom")
                        .HasColumnType("int");

                    b.Property<int?>("FloweringTo")
                        .HasColumnType("int");

                    b.Property<int?>("LightConditionId")
                        .HasColumnType("int");

                    b.Property<bool?>("MistingAppropriate")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("TemperatureFrom")
                        .HasColumnType("int");

                    b.Property<int?>("TemperatureTo")
                        .HasColumnType("int");

                    b.Property<int?>("WaterConditionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LightConditionId");

                    b.HasIndex("WaterConditionId");

                    b.ToTable("Plants");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.PlantImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlantId");

                    b.ToTable("PlantImages");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.Soil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("Soils");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.WaterCondition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Intensity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("WaterConditions");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.WateringHabit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DaysFrequency")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TimeFrom")
                        .HasColumnType("int");

                    b.Property<int?>("TimeTo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WateringHabits");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.JoinEntities.FertilizingHabit_FertilizerType", b =>
                {
                    b.HasOne("PlantNavigator.API.Entities.FertilizerType", "FertilizerType")
                        .WithMany("FertilizingHabit_FertilizerTypes")
                        .HasForeignKey("FertilizerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlantNavigator.API.Entities.FertilizingHabit", "FertilizingHabit")
                        .WithMany("FertilizingHabit_FertilizerTypes")
                        .HasForeignKey("FertilizingHabitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FertilizerType");

                    b.Navigation("FertilizingHabit");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.JoinEntities.Plant_Classification", b =>
                {
                    b.HasOne("PlantNavigator.API.Entities.Classification", "Classification")
                        .WithMany("Plant_Classifications")
                        .HasForeignKey("ClassificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlantNavigator.API.Entities.Plant", "Plant")
                        .WithMany("Plant_Classifications")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classification");

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.JoinEntities.Plant_Disease", b =>
                {
                    b.HasOne("PlantNavigator.API.Entities.Disease", "Disease")
                        .WithMany("Plant_Diseases")
                        .HasForeignKey("DiseaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlantNavigator.API.Entities.Plant", "Plant")
                        .WithMany("Plant_Diseases")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disease");

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.JoinEntities.Plant_FertilizingHabit", b =>
                {
                    b.HasOne("PlantNavigator.API.Entities.FertilizingHabit", "FertilizingHabit")
                        .WithMany("Plant_FertilizingHabits")
                        .HasForeignKey("FertilizingHabitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlantNavigator.API.Entities.Plant", "Plant")
                        .WithMany("Plant_FertilizingHabits")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FertilizingHabit");

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.JoinEntities.Plant_Pest", b =>
                {
                    b.HasOne("PlantNavigator.API.Entities.Pest", "Pest")
                        .WithMany("Plant_Pests")
                        .HasForeignKey("PestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlantNavigator.API.Entities.Plant", "Plant")
                        .WithMany("Plant_Pests")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pest");

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.JoinEntities.Plant_Soil", b =>
                {
                    b.HasOne("PlantNavigator.API.Entities.Plant", "Plant")
                        .WithMany("Plant_Soils")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlantNavigator.API.Entities.Soil", "Soil")
                        .WithMany("Plant_Soils")
                        .HasForeignKey("SoilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plant");

                    b.Navigation("Soil");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.JoinEntities.Plant_WateringHabit", b =>
                {
                    b.HasOne("PlantNavigator.API.Entities.Plant", "Plant")
                        .WithMany("Plant_WateringHabits")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlantNavigator.API.Entities.WateringHabit", "WateringHabit")
                        .WithMany("Plant_WateringHabits")
                        .HasForeignKey("WateringHabitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plant");

                    b.Navigation("WateringHabit");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.Plant", b =>
                {
                    b.HasOne("PlantNavigator.API.Entities.LightCondition", "LightCondition")
                        .WithMany()
                        .HasForeignKey("LightConditionId");

                    b.HasOne("PlantNavigator.API.Entities.WaterCondition", "WaterCondition")
                        .WithMany()
                        .HasForeignKey("WaterConditionId");

                    b.Navigation("LightCondition");

                    b.Navigation("WaterCondition");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.PlantImage", b =>
                {
                    b.HasOne("PlantNavigator.API.Entities.Plant", "Plant")
                        .WithMany()
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.Classification", b =>
                {
                    b.Navigation("Plant_Classifications");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.Disease", b =>
                {
                    b.Navigation("Plant_Diseases");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.FertilizerType", b =>
                {
                    b.Navigation("FertilizingHabit_FertilizerTypes");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.FertilizingHabit", b =>
                {
                    b.Navigation("FertilizingHabit_FertilizerTypes");

                    b.Navigation("Plant_FertilizingHabits");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.Pest", b =>
                {
                    b.Navigation("Plant_Pests");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.Plant", b =>
                {
                    b.Navigation("Plant_Classifications");

                    b.Navigation("Plant_Diseases");

                    b.Navigation("Plant_FertilizingHabits");

                    b.Navigation("Plant_Pests");

                    b.Navigation("Plant_Soils");

                    b.Navigation("Plant_WateringHabits");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.Soil", b =>
                {
                    b.Navigation("Plant_Soils");
                });

            modelBuilder.Entity("PlantNavigator.API.Entities.WateringHabit", b =>
                {
                    b.Navigation("Plant_WateringHabits");
                });
#pragma warning restore 612, 618
        }
    }
}
