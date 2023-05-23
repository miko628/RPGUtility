using System;
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

    public virtual DbSet<Campaign> Campaigns { get; set; }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<SkillCategory> SkillCategories { get; set; }

    public virtual DbSet<Statistic> Statistics { get; set; }

    public virtual DbSet<Talent> Talents { get; set; }

    public virtual DbSet<TalentCategory> TalentCategories { get; set; }

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

            entity.HasOne(d => d.Campaign).WithMany(p => p.Acts).HasConstraintName("Act_campaign_id_fkey");
        });

        modelBuilder.Entity<Armor>(entity =>
        {
            entity.HasKey(e => e.ArmorId).HasName("Armor_pkey");

            entity.Property(e => e.ArmorId).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Character).WithMany(p => p.Armors).HasConstraintName("Armor_character_id_fkey");
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

            entity.HasOne(d => d.Campaign).WithMany(p => p.Characters).HasConstraintName("Character_campaign_id_fkey");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("Item_pkey");

            entity.Property(e => e.ItemId).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Character).WithMany(p => p.Items).HasConstraintName("Item_character_id_fkey");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.SkillId).HasName("Skill_pkey");

            entity.Property(e => e.SkillId).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Character).WithMany(p => p.Skills).HasConstraintName("Skill_character_id_fkey");

            entity.HasOne(d => d.Skillcategory).WithMany(p => p.Skills).HasConstraintName("Skill_skillcategory_id_fkey");
        });

        modelBuilder.Entity<SkillCategory>(entity =>
        {
            entity.HasKey(e => e.SkillId).HasName("SkillCategory_pkey");

            entity.Property(e => e.SkillId).UseIdentityAlwaysColumn();
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

            entity.HasOne(d => d.Character).WithMany(p => p.Talents).HasConstraintName("Talent_character_id_fkey");

            entity.HasOne(d => d.Talentcategory).WithMany(p => p.Talents).HasConstraintName("Talent_talentcategory_id_fkey");
        });

        modelBuilder.Entity<TalentCategory>(entity =>
        {
            entity.HasKey(e => e.TalentId).HasName("TalentCategory_pkey");

            entity.Property(e => e.TalentId).UseIdentityAlwaysColumn();
        });

        modelBuilder.Entity<Weapon>(entity =>
        {
            entity.HasKey(e => e.WeaponId).HasName("Weapon_pkey");

            entity.Property(e => e.WeaponId).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Character).WithMany(p => p.Weapons).HasConstraintName("Weapon_character_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
