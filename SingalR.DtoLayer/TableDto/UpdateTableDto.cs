using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingalR.DtoLayer.TableDto
{
    public class UpdateTableDto
    {
        public int RestaurantTableId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
