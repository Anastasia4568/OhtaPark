using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okhta_Park
{
    internal class OrderServicesView
    {
        public string ClientId { get; set; }
        public string Login { get; set; }
        public string DateStart { get; set; }
        public string Status { get; set; }
        public string DateEnd { get; set; }
        public string Time { get; set; }
        public string Services { get; set; }

        public OrderServicesView(List<OrderServices> orderServices) 
        {
            ClientId = orderServices.First().Order.ClientId.ToString();
            Login = orderServices.First().Order.Client.Email.ToString();
            DateStart = orderServices.First().Order.DateStart.ToString();
            Status = orderServices.First().Order.Status.Name.ToString();
            DateEnd = orderServices.First().Order.DateEnd.ToString();
            Time = orderServices.First().Order.Time.ToString();
            Services = string.Empty;
            for(int i = 0; i < orderServices.Count - 1; i++)
            {
                Services += orderServices[i].Service.Name + "\n";
            }
            Services += orderServices[orderServices.Count - 1].Service.Name;
        }
    }
}
