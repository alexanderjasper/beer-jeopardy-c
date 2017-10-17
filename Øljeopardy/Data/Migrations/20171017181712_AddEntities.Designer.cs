﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Øljeopardy.Data;
using Øljeopardy.Models;
using System;

namespace Øljeopardy.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20171017181712_AddEntities")]
    partial class AddEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Øljeopardy.Models.AnswerQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer");

                    b.Property<string>("Question");

                    b.HasKey("Id");

                    b.ToTable("AnswerQuestions");
                });

            modelBuilder.Entity("Øljeopardy.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Øljeopardy.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AnswerQuestion100Id");

                    b.Property<Guid?>("AnswerQuestion200Id");

                    b.Property<Guid?>("AnswerQuestion300Id");

                    b.Property<Guid?>("AnswerQuestion400Id");

                    b.Property<Guid?>("AnswerQuestion500Id");

                    b.Property<string>("Name");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AnswerQuestion100Id");

                    b.HasIndex("AnswerQuestion200Id");

                    b.HasIndex("AnswerQuestion300Id");

                    b.HasIndex("AnswerQuestion400Id");

                    b.HasIndex("AnswerQuestion500Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Øljeopardy.Models.Game", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<DateTime>("ActiveTime");

                    b.Property<int>("GameStatus");

                    b.Property<string>("LatestChooserId");

                    b.Property<string>("Name");

                    b.Property<Guid>("SelectedGameCategoryId");

                    b.Property<string>("UserId");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.HasIndex("LatestChooserId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Øljeopardy.Models.GameCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryId");

                    b.Property<Guid>("GameId");

                    b.Property<Guid>("ParticipantId");

                    b.Property<Guid>("Won100UserId");

                    b.Property<Guid>("Won200UserId");

                    b.Property<Guid>("Won300UserId");

                    b.Property<Guid>("Won400UserId");

                    b.Property<Guid>("Won500UserId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("GameCategories");
                });

            modelBuilder.Entity("Øljeopardy.Models.Participant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("GameId");

                    b.Property<int>("TurnType");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Øljeopardy.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Øljeopardy.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Øljeopardy.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Øljeopardy.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Øljeopardy.Models.Category", b =>
                {
                    b.HasOne("Øljeopardy.Models.AnswerQuestion", "AnswerQuestion100")
                        .WithMany()
                        .HasForeignKey("AnswerQuestion100Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Øljeopardy.Models.AnswerQuestion", "AnswerQuestion200")
                        .WithMany()
                        .HasForeignKey("AnswerQuestion200Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Øljeopardy.Models.AnswerQuestion", "AnswerQuestion300")
                        .WithMany()
                        .HasForeignKey("AnswerQuestion300Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Øljeopardy.Models.AnswerQuestion", "AnswerQuestion400")
                        .WithMany()
                        .HasForeignKey("AnswerQuestion400Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Øljeopardy.Models.AnswerQuestion", "AnswerQuestion500")
                        .WithMany()
                        .HasForeignKey("AnswerQuestion500Id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Øljeopardy.Models.Game", b =>
                {
                    b.HasOne("Øljeopardy.Models.GameCategory", "SelectedGameCategory")
                        .WithOne("Game")
                        .HasForeignKey("Øljeopardy.Models.Game", "Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Øljeopardy.Models.ApplicationUser", "LatestChooser")
                        .WithMany()
                        .HasForeignKey("LatestChooserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Øljeopardy.Models.GameCategory", b =>
                {
                    b.HasOne("Øljeopardy.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Øljeopardy.Models.Participant", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Øljeopardy.Models.Participant", b =>
                {
                    b.HasOne("Øljeopardy.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
