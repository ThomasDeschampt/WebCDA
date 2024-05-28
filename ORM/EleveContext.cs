using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Models;

namespace ORM
{
    public partial class EleveContext : DbContext
    {

        //------------------------------------------------------------------------------------------------------------------------------
        //pool de connexion avec le pattern singleton
        //patern singleton -- Pour disposer d'une seule instance et éviter des connexions
        //inutiles qui dégradent les performances de la BDD
        private static readonly object _padlock = new object();
        private static EleveContext? _instance;
        //méthode statique qui renvoit une instance de EleveContext
        public static EleveContext Instance
        {
            get
            {
                //check pour éviter l'accés multi-thread
                lock (_padlock)
                {
                    if (_instance == null) //si null on instancié le DbContext
                        _instance = new EleveContext();
                    return _instance;
                }
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------



        public EleveContext()
        {
        }

        public EleveContext(DbContextOptions<EleveContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localDB)\\mssqllocaldb;Initial Catalog=CDA;Integrated Security=True;Encrypt=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                //entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nom).HasMaxLength(50);

                entity.Property(e => e.Prenom).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
