using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace toasty_railcar.Models
{
    public class Verse
    {
        public int Id { get; set; }
        public string Translation { get; set; }
        public string Testament { get; set; }
        public string Book { get; set; }
        public int Chapter { get; set; }
        public int VerseNumber { get; set; }
        public string VerseText { get; set; }
        public string Related { get; set; }
        public string Notes { get; set; }
        public string UpdatedBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime UpdatedDate { get; set; }

        public class VerseDBContext : DbContext
        {

            public DbSet<Verse> Verses { get; set; }
        }
    }
}