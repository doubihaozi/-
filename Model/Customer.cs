using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Customer
    {
        public  string LoginName { get; set; }
        public  string Password { get; set; }
        public  string CustomerName{get;set;}
        public  int State { get; set; }
        public  string Email { get; set; }
        public  string Question { get; set; }
        public  string Answer { get; set; }
        public  DateTime LastLogDate { get; set; }
        public  string Phone { get; set; }
        public  string QQMSN { get; set; }
        public  string Gender { get; set; }
        public  DateTime Birthday { get; set; }
    }
}
