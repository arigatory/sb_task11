using sb_task11.Models;
using System;

namespace sb_task11
{
    class Program
    {
        static void Main(string[] args)
        {
            CompanyEntity company = CreateCompany();

            PrintCompany(company);
        }

        static void PrintCompany(CompanyEntity companyEntity, int level = 0)
        {
            if (companyEntity == null)
            {
                return;
            }
            string indentation = new string('\t', level);
            if (companyEntity is Worker)
            {
                Console.WriteLine($"{indentation}Сотрудник: {companyEntity.Name}; Зарплата: ${((Worker)companyEntity).GetSalary()}");
            }
            if (companyEntity is Department)
            {
                Console.WriteLine($"{indentation}Подразделение: {companyEntity.Name}");
                foreach (var entity in ((Department)companyEntity).Entities)
                {
                    PrintCompany(entity,level+1);
                } 
            }
            if (companyEntity is Boss)
            {
                Console.WriteLine($"{indentation}Начальник данного подразделения: {companyEntity.Name}; Зарплата: ${((Boss)companyEntity).GetSalary()}");
            }
        }


        static CompanyEntity CreateCompany()
        {
            Department company = new Department { Name = "ООО \"Stalls\"" };
            Department developersDepartment = new Department { Name = "Департамент разработки" };
            Department qualityDepartment = new Department { Name = "Департамент контроля качества" };
            Department restDepartment = new Department { Name = "Департамент отдыха" };

            company.Entities.Add(developersDepartment);
            company.Entities.Add(qualityDepartment);
            company.Entities.Add(restDepartment);

            Worker workerIvan = new Worker { Name = "Иванов Иван Иванович", Salary=700};
            developersDepartment.Entities.Add(workerIvan);

            Department testDepartment = new Department { Name = "Департамент тестирования" };
            qualityDepartment.Entities.Add(testDepartment);
            Worker workerAndery = new Worker { Name = "Петров Андрей Андреевич", Salary = 750 };
            testDepartment.Entities.Add(workerAndery);
            Intern workerAlla = new Intern { Name = "Сидорова Алла Игоревна", Salary = 500 };
            testDepartment.Entities.Add(workerAlla);

            Department gameDepartment = new Department { Name = "Департамент игр" };
            restDepartment.Entities.Add(gameDepartment);
            Department travelDepartment = new Department { Name = "Департамент путешествий" };
            restDepartment.Entities.Add(travelDepartment);

            Worker workerRed = new Worker { Name = "Краснов Максим Иванович", Salary = 800 };
            Worker workerBlue = new Worker { Name = "Синькин Сергей Олегович", Salary = 900 };
            Worker workerGreen = new Worker { Name = "Зеленко Светлана Игоревна", Salary = 600 };
            Intern workerBlack = new Intern { Name = "Чернова Ирина Юрьевна", Salary = 500 };
            Worker workerWhite = new Worker { Name = "Белова Елена Владиславовна", Salary = 550 };

            restDepartment.Entities.Add(workerRed);
            restDepartment.Entities.Add(workerBlue);
            gameDepartment.Entities.Add(workerGreen);
            travelDepartment.Entities.Add(workerBlack);
            travelDepartment.Entities.Add(workerWhite);

            Boss bossIvan = new Boss { Name = "Антонов Иван Сергеевич", SuperwisedDepartment=developersDepartment };
            Boss bossOleg = new Boss { Name = "Антонов Олег Сергеевич", SuperwisedDepartment=gameDepartment };
            Boss bossAnton = new Boss { Name = "Антонов Антон Сергеевич", SuperwisedDepartment=restDepartment };
            Boss bossOlga = new Boss { Name = "Антонова Ольна Юрьевна", SuperwisedDepartment=travelDepartment };
            Boss bossMaria = new Boss { Name = "Антонов Мария Владимировна", SuperwisedDepartment=testDepartment };
            Boss bossPetr = new Boss { Name = "Янов Петр Дмитриевич", SuperwisedDepartment=company };

            developersDepartment.Entities.Add(bossIvan);
            gameDepartment.Entities.Add(bossOleg);
            restDepartment.Entities.Add(bossAnton);
            travelDepartment.Entities.Add(bossOlga);
            testDepartment.Entities.Add(bossMaria);
            company.Entities.Add(bossPetr);

            return company;
        }

    }
}
