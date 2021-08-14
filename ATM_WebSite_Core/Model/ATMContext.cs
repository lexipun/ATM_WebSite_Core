using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ATM_WebSite_Core.Model
{
    public class ATMContext: DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<Card>()
                .HasRequired(s => s.User)
                .WithMany(g => g.Cards)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<Transaction>()
                .HasRequired(s => s.Card)
                .WithMany(g => g.Transactions)
                .HasForeignKey(s => s.CardId);
        }
    }


}

