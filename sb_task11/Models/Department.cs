using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sb_task11.Models
{
    public class Department : CompanyEntity
    {
        public Collection<CompanyEntity> Entities { get; set; } = new();
        public int CalculateSalaries(Department d)
        {
            int sum = 0;
            foreach (var entity in d.Entities)
            {
                if (entity is Worker && !(entity is Boss))
                {
                    sum += ((Worker)entity).GetSalary();
                }
                if (entity is Department)
                {
                    sum += CalculateSalaries(((Department)entity));
                }
            }

            return sum;
        }
    }
}
