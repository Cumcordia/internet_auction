﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auctions.Models
{
    public class Listing
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }
        public bool IsSold { get; set; } = false;
		public DateTime TimeOfClosure { get; set; }

        // Связь с категорией
        public int CategoryId { get; set; } // Внешний ключ для связи с таблицей категорий

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [Required]
        public string IdentityUserId { get; set; }
        [ForeignKey("IdentityUserId")]
        public IdentityUser User { get; set; }

        public List<Bid> Bids { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
