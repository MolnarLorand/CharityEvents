using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CharityEvents.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public String Email { get; set; }

        public String UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
        

        //rel
        public List<OrderItem> OrderItems { get; set; }
    }
}
