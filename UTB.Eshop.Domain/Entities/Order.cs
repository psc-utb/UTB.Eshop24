using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UTB.Eshop.Domain.Entities.Interfaces;

namespace UTB.Eshop.Domain.Entities
{
    [Table(nameof(Order))]
    public class Order : Entity<int>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateTimeCreated { get; protected set; }

        [Required]
        public string OrderNumber { get; set; }

        [Required]
        public double TotalPrice { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public IUser<int> User { get; set; }

        public IList<OrderItem> OrderItems { get; set; }
    }
}
