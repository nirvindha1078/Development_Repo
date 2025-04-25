using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_management_task
{
    public interface IGetBonus
    {
        Task<double> GetBonus();
    }

    public interface IDetails
    {
        Task Details(string id);
    }
}
