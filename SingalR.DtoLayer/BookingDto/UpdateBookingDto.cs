using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingalR.DtoLayer.BookingDto
{
    public class UpdateBookingDto
    {
        public int BookingId { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public int PersonCount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
