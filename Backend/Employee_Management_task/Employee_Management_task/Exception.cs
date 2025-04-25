using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_task
{
    public class EmployeeNotFoundException : Exception
    {
        public EmployeeNotFoundException(string message) : base(message) { }
    }

    public class InvalidSalaryException : Exception
    {
        public InvalidSalaryException(string message) : base(message) { }
    }

    public class DuplicateEmployeeException : Exception
    {
        public DuplicateEmployeeException(string message) : base(message) { }
    }
}
