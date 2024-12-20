﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RelaxingKoala.Data;

#nullable disable

namespace RelaxingKoala.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241111130138_AddStatistics")]
    partial class AddStatistics
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("MenuMenuItem", b =>
                {
                    b.Property<int>("ItemsMenuItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MenusMenuId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ItemsMenuItemId", "MenusMenuId");

                    b.HasIndex("MenusMenuId");

                    b.ToTable("MenuMenuItem");

                    b.HasData(
                        new
                        {
                            ItemsMenuItemId = 1,
                            MenusMenuId = 1
                        },
                        new
                        {
                            ItemsMenuItemId = 2,
                            MenusMenuId = 1
                        },
                        new
                        {
                            ItemsMenuItemId = 3,
                            MenusMenuId = 2
                        },
                        new
                        {
                            ItemsMenuItemId = 4,
                            MenusMenuId = 2
                        },
                        new
                        {
                            ItemsMenuItemId = 5,
                            MenusMenuId = 3
                        },
                        new
                        {
                            ItemsMenuItemId = 6,
                            MenusMenuId = 3
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "ProviderKey");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("RelaxingKoala.Models.Kitchen", b =>
                {
                    b.Property<int>("KitchenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPrepared")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MenuItemId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("TEXT");

                    b.HasKey("KitchenId");

                    b.HasIndex("MenuItemId");

                    b.ToTable("Kitchens");

                    b.HasData(
                        new
                        {
                            KitchenId = 1,
                            IsPrepared = false,
                            MenuItemId = 1,
                            OrderTime = new DateTime(2024, 11, 11, 19, 1, 37, 656, DateTimeKind.Local).AddTicks(6803)
                        },
                        new
                        {
                            KitchenId = 2,
                            IsPrepared = false,
                            MenuItemId = 2,
                            OrderTime = new DateTime(2024, 11, 11, 18, 1, 37, 656, DateTimeKind.Local).AddTicks(8011)
                        },
                        new
                        {
                            KitchenId = 3,
                            IsPrepared = true,
                            MenuItemId = 3,
                            OrderTime = new DateTime(2024, 11, 11, 17, 1, 37, 656, DateTimeKind.Local).AddTicks(8016)
                        },
                        new
                        {
                            KitchenId = 4,
                            IsPrepared = true,
                            MenuItemId = 4,
                            OrderTime = new DateTime(2024, 11, 11, 18, 31, 37, 656, DateTimeKind.Local).AddTicks(8018)
                        },
                        new
                        {
                            KitchenId = 5,
                            IsPrepared = false,
                            MenuItemId = 5,
                            OrderTime = new DateTime(2024, 11, 11, 19, 16, 37, 656, DateTimeKind.Local).AddTicks(8019)
                        },
                        new
                        {
                            KitchenId = 6,
                            IsPrepared = true,
                            MenuItemId = 6,
                            OrderTime = new DateTime(2024, 11, 11, 17, 31, 37, 656, DateTimeKind.Local).AddTicks(8020)
                        });
                });

            modelBuilder.Entity("RelaxingKoala.Models.Menu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MenuId");

                    b.ToTable("Menus");

                    b.HasData(
                        new
                        {
                            MenuId = 1,
                            Description = "Delicious Meals from the Northern Parts of Italy",
                            Name = "Italian Menu"
                        },
                        new
                        {
                            MenuId = 2,
                            Description = "Scrumptiousness By the Ocean",
                            Name = "Seafood Menu"
                        },
                        new
                        {
                            MenuId = 3,
                            Description = "Absolute Healthiness lol",
                            Name = "Vegan Menu"
                        });
                });

            modelBuilder.Entity("RelaxingKoala.Models.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("MenuItemId");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            MenuItemId = 1,
                            Description = "Classic Italian pasta dish with eggs, cheese, pancetta, and pepper.",
                            Name = "Spaghetti Carbonara",
                            Price = 12.99f
                        },
                        new
                        {
                            MenuItemId = 2,
                            Description = "Traditional pizza with fresh tomatoes, mozzarella cheese, and basil.",
                            Name = "Margherita Pizza",
                            Price = 10.5f
                        },
                        new
                        {
                            MenuItemId = 3,
                            Description = "Rich and creamy lobster soup with a hint of sherry.",
                            Name = "Lobster Bisque",
                            Price = 15.75f
                        },
                        new
                        {
                            MenuItemId = 4,
                            Description = "Fresh Atlantic salmon grilled to perfection with lemon butter sauce.",
                            Name = "Grilled Salmon",
                            Price = 18f
                        },
                        new
                        {
                            MenuItemId = 5,
                            Description = "Healthy vegan salad with quinoa, avocado, cherry tomatoes, and a light vinaigrette.",
                            Name = "Quinoa Salad",
                            Price = 9.5f
                        },
                        new
                        {
                            MenuItemId = 6,
                            Description = "Plant-based burger with lettuce, tomato, vegan cheese, and a special sauce.",
                            Name = "Vegan Burger",
                            Price = 11.25f
                        });
                });

            modelBuilder.Entity("RelaxingKoala.Models.Statistics", b =>
                {
                    b.Property<int>("StatisticsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AverageOrderTime")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MenuItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfOrders")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("RecordedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("StatisticsId");

                    b.HasIndex("MenuItemId");

                    b.ToTable("Statistics");

                    b.HasData(
                        new
                        {
                            StatisticsId = 1,
                            AverageOrderTime = 20,
                            MenuItemId = 1,
                            NumberOfOrders = 150,
                            RecordedDate = new DateOnly(2024, 11, 10)
                        },
                        new
                        {
                            StatisticsId = 2,
                            AverageOrderTime = 18,
                            MenuItemId = 2,
                            NumberOfOrders = 120,
                            RecordedDate = new DateOnly(2024, 11, 8)
                        },
                        new
                        {
                            StatisticsId = 3,
                            AverageOrderTime = 22,
                            MenuItemId = 3,
                            NumberOfOrders = 100,
                            RecordedDate = new DateOnly(2024, 11, 9)
                        },
                        new
                        {
                            StatisticsId = 4,
                            AverageOrderTime = 25,
                            MenuItemId = 4,
                            NumberOfOrders = 80,
                            RecordedDate = new DateOnly(2024, 10, 20)
                        },
                        new
                        {
                            StatisticsId = 5,
                            AverageOrderTime = 15,
                            MenuItemId = 5,
                            NumberOfOrders = 60,
                            RecordedDate = new DateOnly(2024, 10, 29)
                        },
                        new
                        {
                            StatisticsId = 6,
                            AverageOrderTime = 20,
                            MenuItemId = 6,
                            NumberOfOrders = 90,
                            RecordedDate = new DateOnly(2024, 10, 12)
                        });
                });

            modelBuilder.Entity("MenuMenuItem", b =>
                {
                    b.HasOne("RelaxingKoala.Models.MenuItem", null)
                        .WithMany()
                        .HasForeignKey("ItemsMenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RelaxingKoala.Models.Menu", null)
                        .WithMany()
                        .HasForeignKey("MenusMenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RelaxingKoala.Models.Kitchen", b =>
                {
                    b.HasOne("RelaxingKoala.Models.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");
                });

            modelBuilder.Entity("RelaxingKoala.Models.Statistics", b =>
                {
                    b.HasOne("RelaxingKoala.Models.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");
                });
#pragma warning restore 612, 618
        }
    }
}
