using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_management_task
{
    public class TeacherData()
    {
        public static Dictionary<string, Teacher> teacherData = new Dictionary<string, Teacher>();
    }
    public class StudentData()
    {
        public static Dictionary<string, Student> studentData = new Dictionary<string, Student>();
    }
    public class SecurityGuardData()
    {
        public static Dictionary<string, SecurityGuard> securityGuardData = new Dictionary<string, SecurityGuard>();
    }
    public class LabAssistantData()
    {
        public static Dictionary<string, LabAssistant> labAssistantData = new Dictionary<string, LabAssistant>();
    }

}
