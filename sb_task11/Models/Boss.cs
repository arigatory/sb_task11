using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sb_task11.Models
{
    public class Boss : Worker, IHaveSalary
    {
        private static readonly int _minimumSalary = 1300;
        public Department SuperwisedDepartment { get; set; }
        public int CalculateSalary { get; }

        public override int GetSalary()
        {
            int calculatedSalary = SuperwisedDepartment.CalculateSalaries(SuperwisedDepartment);
            return calculatedSalary > _minimumSalary ? calculatedSalary : _minimumSalary;
        }
    }
}
