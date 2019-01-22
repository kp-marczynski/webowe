using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Entities
{
    [Table("events")]
    public class Event
    {
        [Required] [Key] public int Id { get; set; }
        [Required] [StringLength(255)] public string Name { get; set; }
        [Required] public double Price { get; set; }

        [Required] [StringLength(255)] public string Place { get; set; }

        [Column("date")] public DateTime Date { get; set; }
        [Column("short_info")] public string ShortInfo { get; set; }
        [Column("image_url")] public string ImageUrl { get; set; }

        [Column("number_of_available_tickets")]
        public int NumberOfAvailableTickets { get; set; }

        [Column("created_by")]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        [Column("age_range")]
        [StringLength(50)]
        public string AgeRange { get; set; }

        [Column("additional_info")]
        [StringLength(255)]
        public string AdditionalInfo { get; set; }
    }
}