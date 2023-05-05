using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
namespace RPGUtility;

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
        => optionsBuilder.UseNpgsql(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasSequence<int>("seq_campaign","public");

        modelBuilder.Entity<Act>(entity =>
        {
            entity.HasKey(e => e.ActId).HasName("Act_pkey");

            entity.ToTable("Act");

            entity.Property(e => e.ActId)
                .HasDefaultValueSql("values(nextval('seq_campaign')")
                .HasColumnName("act_id");
            entity.Property(e => e.CampaignId).HasColumnName("campaign_id");
            entity.Property(e => e.Description).HasColumnName("description");

            entity.HasOne(d => d.Campaign).WithMany(p => p.Acts)
                .HasForeignKey(d => d.CampaignId)
                .HasConstraintName("Act_campaign_id_fkey");
        });

        modelBuilder.Entity<Armor>(entity =>
        {
            entity.HasKey(e => e.ArmorId).HasName("Armor_pkey");

            entity.ToTable("Armor");

            entity.Property(e => e.ArmorId)
                .ValueGeneratedNever()
                .HasColumnName("armor_id");
            entity.Property(e => e.Boots).HasColumnName("boots");
            entity.Property(e => e.CharacterId).HasColumnName("character_id");
            entity.Property(e => e.Chestplate).HasColumnName("chestplate");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Head).HasColumnName("head");
            entity.Property(e => e.Leggings).HasColumnName("leggings");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Type)
                .HasColumnType("character varying")
                .HasColumnName("type");

            entity.HasOne(d => d.Character).WithMany(p => p.Armors)
                .HasForeignKey(d => d.CharacterId)
                .HasConstraintName("Armor_character_id_fkey");
        });

        modelBuilder.Entity<Battle>(entity =>
        {
            entity.HasKey(e => e.BattleId).HasName("Battle_pkey");

            entity.ToTable("Battle");

            entity.Property(e => e.BattleId)
                .ValueGeneratedNever()
                .HasColumnName("battle_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Description).HasColumnName("description");

            entity.HasOne(d => d.BattleNavigation).WithOne(p => p.Battle)
                .HasForeignKey<Battle>(d => d.BattleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Battle_battle_id_fkey");

            entity.HasMany(d => d.Characters).WithMany(p => p.Battles)
                .UsingEntity<Dictionary<string, object>>(
                    "BattleDetail",
                    r => r.HasOne<Character>().WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Battle_details_character_id_fkey"),
                    l => l.HasOne<Battle>().WithMany()
                        .HasForeignKey("BattleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
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
            entity.Property(e => e.CampaignId)
               .HasDefaultValueSql("nextval('seq_campaign'::regclass)")
               .HasColumnName("campaign_id");

            entity.HasKey(e => e.CampaignId).HasName("Campaign_pkey");


            entity.ToTable("Campaign");

           
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.GameMaster) 
                .HasColumnType("character varying")
                .HasColumnName("game_master");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Year)
                .HasColumnType("character varying")
                .HasColumnName("year");
        });

        modelBuilder.Entity<Character>(entity =>
        {
            entity.Property(e => e.CharacterId)
                .ValueGeneratedNever()
                .HasColumnName("character_id");
            entity.HasKey(e => e.CharacterId).HasName("Character_pkey");

            entity.ToTable("Character");

            
            entity.Property(e => e.Background).HasColumnName("background");
            entity.Property(e => e.BirthYear).HasColumnName("birth_year");
            entity.Property(e => e.BrassPenniews).HasColumnName("brass_penniews");
            entity.Property(e => e.CampaignId).HasColumnName("campaign_id");
            entity.Property(e => e.Career)
                .HasColumnType("character varying")
                .HasColumnName("career");
            entity.Property(e => e.CarrerExits)
                .HasColumnType("character varying")
                .HasColumnName("carrer_exits");
            entity.Property(e => e.CarrerPath)
                .HasColumnType("character varying")
                .HasColumnName("carrer_path");
            entity.Property(e => e.CharacterImage).HasColumnName("character_image");
            entity.Property(e => e.Characteristics).HasColumnName("characteristics");
            entity.Property(e => e.Eyes)
                .HasColumnType("character varying")
                .HasColumnName("eyes");
            entity.Property(e => e.Gender)
                .HasColumnType("character varying")
                .HasColumnName("gender");
            entity.Property(e => e.GoldCrowns).HasColumnName("gold_crowns");
            entity.Property(e => e.Hair)
                .HasColumnType("character varying")
                .HasColumnName("hair");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.Languages).HasColumnName("languages");
            entity.Property(e => e.MainDelty)
                .HasColumnType("character varying")
                .HasColumnName("main_delty");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.PlaceBirth)
                .HasColumnType("character varying")
                .HasColumnName("place_birth");
            entity.Property(e => e.Race)
                .HasColumnType("character varying")
                .HasColumnName("race");
            entity.Property(e => e.Relatives)
                .HasColumnType("character varying")
                .HasColumnName("relatives");
            entity.Property(e => e.SilverShillings).HasColumnName("silver_shillings");
            entity.Property(e => e.StarSign)
                .HasColumnType("character varying")
                .HasColumnName("star_sign");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.Campaign).WithMany(p => p.Characters)
                .HasForeignKey(d => d.CampaignId)
                .HasConstraintName("Character_campaign_id_fkey");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("Item_pkey");

            entity.ToTable("Item");

            entity.Property(e => e.ItemId)
                .ValueGeneratedNever()
                .HasColumnName("item_id");
            entity.Property(e => e.CharacterId).HasColumnName("character_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Character).WithMany(p => p.Items)
                .HasForeignKey(d => d.CharacterId)
                .HasConstraintName("Item_character_id_fkey");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.SkillId).HasName("Skill_pkey");

            entity.ToTable("Skill");

            entity.Property(e => e.SkillId)
                .ValueGeneratedNever()
                .HasColumnName("skill_id");
            entity.Property(e => e.CharacterId).HasColumnName("character_id");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");

            entity.HasOne(d => d.Character).WithMany(p => p.Skills)
                .HasForeignKey(d => d.CharacterId)
                .HasConstraintName("Skill_character_id_fkey");
        });

        modelBuilder.Entity<Statistic>(entity =>
        {
            entity.HasKey(e => e.StatisticsId).HasName("Statistics_pkey");

            entity.Property(e => e.StatisticsId)
                .ValueGeneratedNever()
                .HasColumnName("statistics_id");
            entity.Property(e => e.AdvanceAgility).HasColumnName("advance_agility");
            entity.Property(e => e.AdvanceAttacks).HasColumnName("advance_attacks");
            entity.Property(e => e.AdvanceBallisticSkill).HasColumnName("advance_ballistic_skill");
            entity.Property(e => e.AdvanceFatePoints).HasColumnName("advance_fate_points");
            entity.Property(e => e.AdvanceFellowship).HasColumnName("advance_fellowship");
            entity.Property(e => e.AdvanceInsanityPoints).HasColumnName("advance_insanity_points");
            entity.Property(e => e.AdvanceIntelligence).HasColumnName("advance_intelligence");
            entity.Property(e => e.AdvanceMagic).HasColumnName("advance_magic");
            entity.Property(e => e.AdvanceMovement).HasColumnName("advance_movement");
            entity.Property(e => e.AdvanceStrength).HasColumnName("advance_strength");
            entity.Property(e => e.AdvanceStrengthBonus).HasColumnName("advance_strength_bonus");
            entity.Property(e => e.AdvanceToughness).HasColumnName("advance_toughness");
            entity.Property(e => e.AdvanceToughnessBonus).HasColumnName("advance_toughness_bonus");
            entity.Property(e => e.AdvanceWeaponSkill).HasColumnName("advance_weapon_skill");
            entity.Property(e => e.AdvanceWillpower).HasColumnName("advance_willpower");
            entity.Property(e => e.AdvanceWounds).HasColumnName("advance_wounds");
            entity.Property(e => e.Agility).HasColumnName("agility");
            entity.Property(e => e.Attacks).HasColumnName("attacks");
            entity.Property(e => e.BallisticSkill).HasColumnName("ballistic_skill");
            entity.Property(e => e.CurrentAgility).HasColumnName("current_agility");
            entity.Property(e => e.CurrentAttacks).HasColumnName("current_attacks");
            entity.Property(e => e.CurrentBallisticSkill).HasColumnName("current_ballistic_skill");
            entity.Property(e => e.CurrentFatePoints).HasColumnName("current_fate_points");
            entity.Property(e => e.CurrentFellowship).HasColumnName("current_fellowship");
            entity.Property(e => e.CurrentInsanityPoints).HasColumnName("current_insanity_points");
            entity.Property(e => e.CurrentIntelligence).HasColumnName("current_intelligence");
            entity.Property(e => e.CurrentMagic).HasColumnName("current_magic");
            entity.Property(e => e.CurrentMovement).HasColumnName("current_movement");
            entity.Property(e => e.CurrentStrength).HasColumnName("current_strength");
            entity.Property(e => e.CurrentStrengthBonus).HasColumnName("current_strength_bonus");
            entity.Property(e => e.CurrentToughness).HasColumnName("current_toughness");
            entity.Property(e => e.CurrentToughnessBonus).HasColumnName("current_toughness_bonus");
            entity.Property(e => e.CurrentWeaponSkill).HasColumnName("current_weapon_skill");
            entity.Property(e => e.CurrentWillpower).HasColumnName("current_willpower");
            entity.Property(e => e.CurrentWounds).HasColumnName("current_wounds");
            entity.Property(e => e.FatePoints).HasColumnName("fate_points");
            entity.Property(e => e.Fellowship).HasColumnName("fellowship");
            entity.Property(e => e.InsanityPoints).HasColumnName("insanity_points");
            entity.Property(e => e.Intelligence).HasColumnName("intelligence");
            entity.Property(e => e.Magic).HasColumnName("magic");
            entity.Property(e => e.Movement).HasColumnName("movement");
            entity.Property(e => e.Strength).HasColumnName("strength");
            entity.Property(e => e.StrengthBonus).HasColumnName("strength_bonus");
            entity.Property(e => e.Toughness).HasColumnName("toughness");
            entity.Property(e => e.ToughnessBonus).HasColumnName("toughness_bonus");
            entity.Property(e => e.WeaponSkill).HasColumnName("weapon_skill");
            entity.Property(e => e.Willpower).HasColumnName("willpower");
            entity.Property(e => e.Wounds).HasColumnName("wounds");

            entity.HasOne(d => d.Statistics).WithOne(p => p.Statistic)
                .HasForeignKey<Statistic>(d => d.StatisticsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Statistics_statistics_id_fkey");
        });

        modelBuilder.Entity<Talent>(entity =>
        {
            entity.HasKey(e => e.TalentId).HasName("Talent_pkey");

            entity.ToTable("Talent");

            entity.Property(e => e.TalentId)
                .ValueGeneratedNever()
                .HasColumnName("talent_id");
            entity.Property(e => e.CharacterId).HasColumnName("character_id");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");

            entity.HasOne(d => d.Character).WithMany(p => p.Talents)
                .HasForeignKey(d => d.CharacterId)
                .HasConstraintName("Talent_character_id_fkey");
        });

        modelBuilder.Entity<Weapon>(entity =>
        {
            entity.HasKey(e => e.WeaponId).HasName("Weapon_pkey");

            entity.ToTable("Weapon");

            entity.Property(e => e.WeaponId)
                .ValueGeneratedNever()
                .HasColumnName("weapon_id");
            entity.Property(e => e.CharacterId).HasColumnName("character_id");
            entity.Property(e => e.Damage).HasColumnName("damage");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Type)
                .HasColumnType("character varying")
                .HasColumnName("type");

            entity.HasOne(d => d.Character).WithMany(p => p.Weapons)
                .HasForeignKey(d => d.CharacterId)
                .HasConstraintName("Weapon_character_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
