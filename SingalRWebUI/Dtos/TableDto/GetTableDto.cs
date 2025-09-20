using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingalRWebUI.Dtos.TableDto
{
    public class GetTableDto
    {
        public int RestaurantTableId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
