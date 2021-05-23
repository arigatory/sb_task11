using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sb_task11.Models
{
    public class Intern : Worker, IHaveSalary
    {
        public int GetSalary()
        {
            return Salary;
        }
    }
}
