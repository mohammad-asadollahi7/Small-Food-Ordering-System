using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model;

public class Order
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public List<Food>? Foods { get; set; }
    public int TotalPrice { get; set; }
}
