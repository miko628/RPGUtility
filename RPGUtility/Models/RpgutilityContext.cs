﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RPGUtility.Models;

public partial class RpgutilityContext : DbContext
{
    public RpgutilityContext()
    {
    }

    public RpgutilityContext(DbContextOptions<RpgutilityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Act> Acts { get; set; }

    public virtual DbSet<Armor> Armors { get; set; }

    public virtual DbSet<Battle> Battles { get; set; }

    public virtual DbSet<Campaign> Campaigns { get; set; }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Statistic> Statistics { get; set; }

    public virtual DbSet<Talent> Talents { get; set; }

    public virtual DbSet<Weapon> Weapons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost; port=5433; userid=postgres; password=password; database=RPGUtility;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Act>(entity =>
        {
            entity.HasKey(e => e.ActId).HasName("Act_pkey");

            entity.Property(e => e.ActId).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Campaign).WithMany(p => p.Acts)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Act_campaign_id_fkey");
        });

        modelBuilder.Entity<Armor>(entity =>
        {
            entity.HasKey(e => e.ArmorId).HasName("Armor_pkey");

            entity.Property(e => e.ArmorId).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Character).WithMany(p => p.Armors)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Armor_character_id_fkey");
        });

        modelBuilder.Entity<Battle>(entity =>
        {
            entity.HasKey(e => e.BattleId).HasName("Battle_pkey");

            entity.Property(e => e.BattleId)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn();

            entity.HasOne(d => d.BattleNavigation).WithOne(p => p.Battle).HasConstraintName("Battle_battle_id_fkey");

            entity.HasMany(d => d.Characters).WithMany(p => p.Battles)
                .UsingEntity<Dictionary<string, object>>(
                    "BattleDetail",
                    r => r.HasOne<Character>().WithMany()
                        .HasForeignKey("CharacterId")
                        .HasConstraintName("Battle_details_character_id_fkey"),
                    l => l.HasOne<Battle>().WithMany()
                        .HasForeignKey("BattleId")
                        .HasConstraintName("Battle_details_battle_id_fkey"),
                    j =>
                    {
                        j.HasKey("BattleId", "CharacterId").HasName("Battle_details_pkey");
                        j.ToTable("Battle_details");
                        j.IndexerProperty<int>("BattleId").HasColumnName("battle_id");
                        j.IndexerProperty<int>("CharacterId").HasColumnName("character_id");
                    });
        });

        modelBuilder.Entity<Campaign>(entity =>
        {
            entity.HasKey(e => e.CampaignId).HasName("Campaign_pkey");

            entity.Property(e => e.CampaignId).UseIdentityAlwaysColumn();
        });

        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.CharacterId).HasName("Character_pkey");

            entity.Property(e => e.CharacterId).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Campaign).WithMany(p => p.Characters)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Character_campaign_id_fkey");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("Item_pkey");

            entity.Property(e => e.ItemId).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Character).WithMany(p => p.Items)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Item_character_id_fkey");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.SkillId).HasName("Skill_pkey");

            entity.Property(e => e.SkillId).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Character).WithMany(p => p.Skills)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Skill_character_id_fkey");
        });

        modelBuilder.Entity<Statistic>(entity =>
        {
            entity.HasKey(e => e.StatisticsId).HasName("Statistics_pkey");

            entity.Property(e => e.StatisticsId)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Statistics).WithOne(p => p.Statistic).HasConstraintName("Statistics_statistics_id_fkey");
        });

        modelBuilder.Entity<Talent>(entity =>
        {
            entity.HasKey(e => e.TalentId).HasName("Talent_pkey");

            entity.Property(e => e.TalentId).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Character).WithMany(p => p.Talents)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Talent_character_id_fkey");
        });

        modelBuilder.Entity<Weapon>(entity =>
        {
            entity.HasKey(e => e.WeaponId).HasName("Weapon_pkey");

            entity.Property(e => e.WeaponId).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Character).WithMany(p => p.Weapons)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Weapon_character_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
