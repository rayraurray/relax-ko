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
    [Migration("20241111165019_TheRest")]
    partial class TheRest
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("CustomerOrder", b =>
                {
                    b.Property<int>("CustomersCustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrdersOrderId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CustomersCustomerId", "OrdersOrderId");

                    b.HasIndex("OrdersOrderId");

                    b.ToTable("CustomerOrder");

                    b.HasData(
                        new
                        {
                            CustomersCustomerId = 1,
                            OrdersOrderId = 1
                        },
                        new
                        {
                            CustomersCustomerId = 2,
                            OrdersOrderId = 2
                        },
                        new
                        {
                            CustomersCustomerId = 3,
                            OrdersOrderId = 1
                        });
                });

            modelBuilder.Entity("CustomerPayment", b =>
                {
                    b.Property<int>("CustomersCustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PaymentsPaymentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CustomersCustomerId", "PaymentsPaymentId");

                    b.HasIndex("PaymentsPaymentId");

                    b.ToTable("CustomerPayment");

                    b.HasData(
                        new
                        {
                            CustomersCustomerId = 1,
                            PaymentsPaymentId = 1
                        },
                        new
                        {
                            CustomersCustomerId = 2,
                            PaymentsPaymentId = 2
                        });
                });

            modelBuilder.Entity("MenuItemOrder", b =>
                {
                    b.Property<int>("MenuItemsMenuItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrdersOrderId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MenuItemsMenuItemId", "OrdersOrderId");

                    b.HasIndex("OrdersOrderId");

                    b.ToTable("MenuItemOrder");

                    b.HasData(
                        new
                        {
                            MenuItemsMenuItemId = 1,
                            OrdersOrderId = 1
                        },
                        new
                        {
                            MenuItemsMenuItemId = 2,
                            OrdersOrderId = 1
                        },
                        new
                        {
                            MenuItemsMenuItemId = 3,
                            OrdersOrderId = 2
                        },
                        new
                        {
                            MenuItemsMenuItemId = 4,
                            OrdersOrderId = 2
                        });
                });

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

            modelBuilder.Entity("RelaxingKoala.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContactInfo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            ContactInfo = "john@example.com",
                            Name = "John Doe"
                        },
                        new
                        {
                            CustomerId = 2,
                            ContactInfo = "jane@example.com",
                            Name = "Jane Smith"
                        },
                        new
                        {
                            CustomerId = 3,
                            ContactInfo = "alice@example.com",
                            Name = "Alice Johnson"
                        });
                });

            modelBuilder.Entity("RelaxingKoala.Models.Delivery", b =>
                {
                    b.Property<int>("DeliveryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DeliveryAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DeliveryTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DeliveryId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("Deliveries");

                    b.HasData(
                        new
                        {
                            DeliveryId = 1,
                            ContactNumber = "123-456-7890",
                            DeliveryAddress = "123 Main St",
                            DeliveryTime = new DateTime(2024, 11, 12, 0, 50, 18, 770, DateTimeKind.Local).AddTicks(5916),
                            OrderId = 1
                        });
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
                            OrderTime = new DateTime(2024, 11, 11, 22, 50, 18, 770, DateTimeKind.Local).AddTicks(5790)
                        },
                        new
                        {
                            KitchenId = 2,
                            IsPrepared = false,
                            MenuItemId = 2,
                            OrderTime = new DateTime(2024, 11, 11, 21, 50, 18, 770, DateTimeKind.Local).AddTicks(5805)
                        },
                        new
                        {
                            KitchenId = 3,
                            IsPrepared = true,
                            MenuItemId = 3,
                            OrderTime = new DateTime(2024, 11, 11, 20, 50, 18, 770, DateTimeKind.Local).AddTicks(5806)
                        },
                        new
                        {
                            KitchenId = 4,
                            IsPrepared = true,
                            MenuItemId = 4,
                            OrderTime = new DateTime(2024, 11, 11, 22, 20, 18, 770, DateTimeKind.Local).AddTicks(5807)
                        },
                        new
                        {
                            KitchenId = 5,
                            IsPrepared = false,
                            MenuItemId = 5,
                            OrderTime = new DateTime(2024, 11, 11, 23, 5, 18, 770, DateTimeKind.Local).AddTicks(5808)
                        },
                        new
                        {
                            KitchenId = 6,
                            IsPrepared = true,
                            MenuItemId = 6,
                            OrderTime = new DateTime(2024, 11, 11, 21, 20, 18, 770, DateTimeKind.Local).AddTicks(5809)
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

            modelBuilder.Entity("RelaxingKoala.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DeliveryId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            DeliveryId = 1,
                            OrderTime = new DateTime(2024, 11, 11, 19, 50, 18, 770, DateTimeKind.Local).AddTicks(5933),
                            PaymentId = 1
                        },
                        new
                        {
                            OrderId = 2,
                            OrderTime = new DateTime(2024, 11, 11, 21, 50, 18, 770, DateTimeKind.Local).AddTicks(5935),
                            PaymentId = 2
                        });
                });

            modelBuilder.Entity("RelaxingKoala.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("Amount")
                        .HasColumnType("REAL");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("PaymentStatus")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("PaymentTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("PaymentType")
                        .HasColumnType("INTEGER");

                    b.HasKey("PaymentId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("Payments");

                    b.HasData(
                        new
                        {
                            PaymentId = 1,
                            Amount = 450f,
                            OrderId = 1,
                            PaymentStatus = true,
                            PaymentTime = new DateTime(2024, 11, 11, 20, 50, 18, 770, DateTimeKind.Local).AddTicks(5951),
                            PaymentType = 1
                        },
                        new
                        {
                            PaymentId = 2,
                            Amount = 300f,
                            OrderId = 2,
                            PaymentStatus = false,
                            PaymentTime = new DateTime(2024, 11, 11, 22, 50, 18, 770, DateTimeKind.Local).AddTicks(5953),
                            PaymentType = 2
                        });
                });

            modelBuilder.Entity("RelaxingKoala.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ReservationTime")
                        .HasColumnType("TEXT");

                    b.HasKey("ReservationId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            ReservationId = 1,
                            CustomerId = 1,
                            ReservationTime = new DateTime(2024, 11, 12, 23, 50, 18, 770, DateTimeKind.Local).AddTicks(5968)
                        },
                        new
                        {
                            ReservationId = 2,
                            CustomerId = 2,
                            ReservationTime = new DateTime(2024, 11, 13, 23, 50, 18, 770, DateTimeKind.Local).AddTicks(5970)
                        });
                });

            modelBuilder.Entity("RelaxingKoala.Models.RestaurantTable", b =>
                {
                    b.Property<int>("RestaurantTableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("RestaurantTableId");

                    b.ToTable("RestaurantTables");

                    b.HasData(
                        new
                        {
                            RestaurantTableId = 1,
                            Name = "Table A"
                        },
                        new
                        {
                            RestaurantTableId = 2,
                            Name = "Table B"
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

            modelBuilder.Entity("ReservationRestaurantTable", b =>
                {
                    b.Property<int>("ReservationsReservationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TablesRestaurantTableId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ReservationsReservationId", "TablesRestaurantTableId");

                    b.HasIndex("TablesRestaurantTableId");

                    b.ToTable("ReservationRestaurantTable");

                    b.HasData(
                        new
                        {
                            ReservationsReservationId = 1,
                            TablesRestaurantTableId = 1
                        },
                        new
                        {
                            ReservationsReservationId = 2,
                            TablesRestaurantTableId = 2
                        });
                });

            modelBuilder.Entity("CustomerOrder", b =>
                {
                    b.HasOne("RelaxingKoala.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomersCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RelaxingKoala.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CustomerPayment", b =>
                {
                    b.HasOne("RelaxingKoala.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomersCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RelaxingKoala.Models.Payment", null)
                        .WithMany()
                        .HasForeignKey("PaymentsPaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MenuItemOrder", b =>
                {
                    b.HasOne("RelaxingKoala.Models.MenuItem", null)
                        .WithMany()
                        .HasForeignKey("MenuItemsMenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RelaxingKoala.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("RelaxingKoala.Models.Delivery", b =>
                {
                    b.HasOne("RelaxingKoala.Models.Order", "Order")
                        .WithOne("Delivery")
                        .HasForeignKey("RelaxingKoala.Models.Delivery", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
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

            modelBuilder.Entity("RelaxingKoala.Models.Payment", b =>
                {
                    b.HasOne("RelaxingKoala.Models.Order", "Order")
                        .WithOne("Payment")
                        .HasForeignKey("RelaxingKoala.Models.Payment", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RelaxingKoala.Models.Reservation", b =>
                {
                    b.HasOne("RelaxingKoala.Models.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
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

            modelBuilder.Entity("ReservationRestaurantTable", b =>
                {
                    b.HasOne("RelaxingKoala.Models.Reservation", null)
                        .WithMany()
                        .HasForeignKey("ReservationsReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RelaxingKoala.Models.RestaurantTable", null)
                        .WithMany()
                        .HasForeignKey("TablesRestaurantTableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RelaxingKoala.Models.Customer", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("RelaxingKoala.Models.Order", b =>
                {
                    b.Navigation("Delivery")
                        .IsRequired();

                    b.Navigation("Payment")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
