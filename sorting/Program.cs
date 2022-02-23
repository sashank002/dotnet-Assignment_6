using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp18jan2022
{
    class SelectionSorter
    {
        static public void Sort<T>(IList<T> sortArray, Func<T, T, bool> comparision)
        {

            for (int i = 0; i < sortArray.Count - 1; i++)
            {
                int key = i;
                for (int j = i + 1; j < sortArray.Count; j++)
                {
                    // find minimum element from the array
                    if (comparision(sortArray[j], sortArray[key]))
                    {
                        key = j;
                    }
                }
                // place the minimum element in the correct position
                T temp = sortArray[i];
                sortArray[i] = sortArray[key];
                sortArray[key] = temp;
            }

        }

    }
    public enum Designations
    {
        CEO = 5,
        CFO = 4,
        sde = 2,
        ba = 1,
        pm = 3
    }

    class Employee
    {
        int empid;
        public float salary;
        public string name;
        public Designations designation;

        public Employee(int EmpId, float Salary, string Name, Designations design)
        {
            this.empid = EmpId;
            this.salary = Salary;
            this.name = Name;
            this.designation = design;

        }

        internal static bool CompareSalary(Employee e1, Employee e2)
        {
            return e1.salary < e2.salary;
        }

        internal static bool CompareDesignations(Employee e1, Employee e2)
        {
            return e1.designation > e2.designation;
        }
    }
    public class TestGenericMethods
    {
        public static void Main(string[] args)
        {
            List<Employee> emplist = new List<Employee>(30);

            emplist.Add(new Employee(10, 10000, "MNRT", Designations.pm));
            emplist.Add(new Employee(5, 500000, "ABCD", Designations.CFO));
            emplist.Add(new Employee(8, 12000000, "EFGH", Designations.CEO));

            emplist.Add(new Employee(1, 25000, "JKLM", Designations.sde));
            emplist.Add(new Employee(19, 5000, "ZQOP", Designations.ba));

            Console.WriteLine("\n");

            // based on designation
            SelectionSorter.Sort<Employee>(emplist, Employee.CompareDesignations);
            Console.WriteLine("Sorting on basis of Designation (Highest to Lowest) : \n");
            foreach (Employee e1 in emplist)
            {
                Console.WriteLine(e1.name + "   " + e1.designation);
            }

            Console.WriteLine("\n");

            // based on salary
            SelectionSorter.Sort<Employee>(emplist, Employee.CompareSalary);
            Console.WriteLine("Sorting on basis of Salary (Lowest to Highest) : \n");
            foreach (Employee e1 in emplist)
            {
                Console.WriteLine(e1.name + "   " + e1.salary);
            }
        }
    }
}
