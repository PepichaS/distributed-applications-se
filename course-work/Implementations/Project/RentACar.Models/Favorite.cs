using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.Models
{
    public class Favorite
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public string VehicleId { get; set; }

        public virtual User User { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
