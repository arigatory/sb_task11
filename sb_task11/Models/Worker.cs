namespace sb_task11.Models
{
    public class Worker : CompanyEntity, IHaveSalary
    {
        public int Salary { get; set; }

        public virtual int GetSalary()
        {
            return Salary;
        }
    }
}
