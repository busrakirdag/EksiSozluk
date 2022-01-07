using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk
{
    public class AppDbContext : DbContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-KVU89L7\SQLEXPRESS;Database=EksiSozluk;uid=sa;pwd=123");
        }

        public DbSet<Kullanici> Kullanici { get; set; }

        public DbSet<Konu> Konu { get; set; }

        public DbSet<Baslik> Baslik { get; set; }

        public DbSet<Entry> Entry_ { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Konu>().ToTable("Konular");
            modelBuilder.Entity<Baslik>().ToTable("Başlıklar");
            modelBuilder.Entity<Entry>().ToTable("Entry");
            modelBuilder.Entity<Kullanici>().ToTable("Kullanıcılar");
            modelBuilder.Entity<Entry>().HasKey(c => c.EntryID);
            modelBuilder.Entity<Baslik>().Property(c => c.BaslikAdi)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("Başlık");


            modelBuilder.Entity<Entry>()
                .HasOne(c => c.Baslik)
                .WithMany(c => c.Entry)
                .HasForeignKey(c => c.BaslkID);

            modelBuilder.Entity<Entry>()
                .HasOne(c => c.Kullanici)
                .WithMany(c => c.Entry)
                .HasForeignKey(c => c.KullancID);

            modelBuilder.Entity<Entry>().Property(c => c.Icerik)
                .HasMaxLength(1000)
                .IsRequired()
                .HasColumnName("İçerik");

            modelBuilder.Entity<Baslik>()
                .HasOne(c => c.Konu)
                .WithMany(c => c.Baslik)
                .HasForeignKey(c => c.KonID);

            modelBuilder.Entity<Kullanici>().Property(c => c.KullaniciAdi)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("Kullanıcı Adı");
        }
    }
}
