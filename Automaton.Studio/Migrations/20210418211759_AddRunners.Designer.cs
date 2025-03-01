﻿// <auto-generated />
using System;
using Automaton.Studio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Automaton.Studio.Migrations
{
    [DbContext(typeof(AutomatonDbContext))]
    [Migration("20210418211759_AddRunners")]
    partial class AddRunners
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Automaton.Studio.Entities.AspNetRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "NormalizedName" }, "RoleNameIndex")
                        .IsUnique()
                        .HasFilter("([NormalizedName] IS NOT NULL)");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Automaton.Studio.Entities.AspNetRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "RoleId" }, "IX_AspNetRoleClaims_RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Automaton.Studio.Entities.AspNetUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "NormalizedEmail" }, "EmailIndex");

                    b.HasIndex(new[] { "NormalizedUserName" }, "UserNameIndex")
                        .IsUnique()
                        .HasFilter("([NormalizedUserName] IS NOT NULL)");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Automaton.Studio.Entities.AspNetUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "UserId" }, "IX_AspNetUserClaims_UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Automaton.Studio.Entities.AspNetUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex(new[] { "UserId" }, "IX_AspNetUserLogins_UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Automaton.Studio.Entities.AspNetUserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Automaton.Studio.Entities.AspNetUserToken", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Automaton.Studio.Entities.Bookmark", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ActivityId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ActivityType")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenantId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("WorkflowInstanceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ActivityId" }, "IX_Bookmark_ActivityId");

                    b.HasIndex(new[] { "ActivityType" }, "IX_Bookmark_ActivityType");

                    b.HasIndex(new[] { "ActivityType", "TenantId", "Hash" }, "IX_Bookmark_ActivityType_TenantId_Hash");

                    b.HasIndex(new[] { "Hash" }, "IX_Bookmark_Hash");

                    b.HasIndex(new[] { "TenantId" }, "IX_Bookmark_TenantId");

                    b.HasIndex(new[] { "WorkflowInstanceId" }, "IX_Bookmark_WorkflowInstanceId");

                    b.ToTable("Bookmarks");
                });

            modelBuilder.Entity("Automaton.Studio.Entities.WorkflowDefinition", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DefinitionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("DeleteCompletedInstances")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsLatest")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSingleton")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PersistenceBehavior")
                        .HasColumnType("int");

                    b.Property<string>("TenantId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "DefinitionId", "Version" }, "IX_WorkflowDefinition_DefinitionId_VersionId");

                    b.HasIndex(new[] { "IsLatest" }, "IX_WorkflowDefinition_IsLatest");

                    b.HasIndex(new[] { "IsPublished" }, "IX_WorkflowDefinition_IsPublished");

                    b.HasIndex(new[] { "Name" }, "IX_WorkflowDefinition_Name");

                    b.HasIndex(new[] { "TenantId" }, "IX_WorkflowDefinition_TenantId");

                    b.HasIndex(new[] { "Version" }, "IX_WorkflowDefinition_Version");

                    b.ToTable("WorkflowDefinitions");
                });

            modelBuilder.Entity("Automaton.Studio.Entities.WorkflowExecutionLogRecord", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ActivityId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ActivityType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenantId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("Timestamp")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("WorkflowInstanceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WorkflowExecutionLogRecords");
                });

            modelBuilder.Entity("Automaton.Studio.Entities.WorkflowInstance", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset?>("CancelledAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ContextId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ContextType")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CorrelationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DefinitionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset?>("FaultedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("FinishedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("LastExecutedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenantId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.Property<int>("WorkflowStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ContextId" }, "IX_WorkflowInstance_ContextId");

                    b.HasIndex(new[] { "ContextType" }, "IX_WorkflowInstance_ContextType");

                    b.HasIndex(new[] { "CorrelationId" }, "IX_WorkflowInstance_CorrelationId");

                    b.HasIndex(new[] { "CreatedAt" }, "IX_WorkflowInstance_CreatedAt");

                    b.HasIndex(new[] { "DefinitionId" }, "IX_WorkflowInstance_DefinitionId");

                    b.HasIndex(new[] { "FaultedAt" }, "IX_WorkflowInstance_FaultedAt");

                    b.HasIndex(new[] { "FinishedAt" }, "IX_WorkflowInstance_FinishedAt");

                    b.HasIndex(new[] { "LastExecutedAt" }, "IX_WorkflowInstance_LastExecutedAt");

                    b.HasIndex(new[] { "Name" }, "IX_WorkflowInstance_Name");

                    b.HasIndex(new[] { "TenantId" }, "IX_WorkflowInstance_TenantId");

                    b.HasIndex(new[] { "WorkflowStatus" }, "IX_WorkflowInstance_WorkflowStatus");

                    b.HasIndex(new[] { "WorkflowStatus", "DefinitionId", "Version" }, "IX_WorkflowInstance_WorkflowStatus_DefinitionId_Version");

                    b.ToTable("WorkflowInstances");
                });

            modelBuilder.Entity("Automaton.Studio.Runner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConnectionId")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Runners");
                });

            modelBuilder.Entity("Automaton.Studio.Entities.AspNetRoleClaim", b =>
                {
                    b.HasOne("Automaton.Studio.Entities.AspNetRole", "Role")
                        .WithMany("AspNetRoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Automaton.Studio.Entities.AspNetUserClaim", b =>
                {
                    b.HasOne("Automaton.Studio.Entities.AspNetUser", "User")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Automaton.Studio.Entities.AspNetUserLogin", b =>
                {
                    b.HasOne("Automaton.Studio.Entities.AspNetUser", "User")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Automaton.Studio.Entities.AspNetUserRole", b =>
                {
                    b.HasOne("Automaton.Studio.Entities.AspNetRole", "Role")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Automaton.Studio.Entities.AspNetUser", "User")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Automaton.Studio.Entities.AspNetUserToken", b =>
                {
                    b.HasOne("Automaton.Studio.Entities.AspNetUser", "User")
                        .WithMany("AspNetUserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Automaton.Studio.Runner", b =>
                {
                    b.HasOne("Automaton.Studio.Entities.AspNetUser", "User")
                        .WithMany("Runners")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Automaton.Studio.Entities.AspNetRole", b =>
                {
                    b.Navigation("AspNetRoleClaims");

                    b.Navigation("AspNetUserRoles");
                });

            modelBuilder.Entity("Automaton.Studio.Entities.AspNetUser", b =>
                {
                    b.Navigation("AspNetUserClaims");

                    b.Navigation("AspNetUserLogins");

                    b.Navigation("AspNetUserRoles");

                    b.Navigation("AspNetUserTokens");

                    b.Navigation("Runners");
                });
#pragma warning restore 612, 618
        }
    }
}
