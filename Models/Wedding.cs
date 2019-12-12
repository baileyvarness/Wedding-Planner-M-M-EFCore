using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId { get; set; }

        [Required(ErrorMessage = "Wedder One is required.")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        [Display(Name = "Wedder One")]
        public string WedderOne { get; set; }
        
        [Required(ErrorMessage = "Wedder Two is required.")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        [Display(Name = "Wedder Two")]
        public string WedderTwo { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        [Display(Name = "Date")]
        //TO MAKE IT DATE ONLY WITHOUT THE TIME
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        [Display(Name = "Wedding Address")]
        public string Address { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public User Creator { get; set; }

        public List<RSVP> WeddingsToAttend {get;set;}
    }
}