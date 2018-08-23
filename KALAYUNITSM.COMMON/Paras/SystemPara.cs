using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KALAYUNITSM.COMMON
{
    public class SystemPara
    {
        public string[,] SlaLevel()
        {
            string[,] menu = new string[3, 4];
            menu[0, 0] = "high";
            menu[0, 1] = "medium";
            menu[0, 2] = "low";
            menu[0, 3] = "low";
            menu[1, 0] = "high";
            menu[1, 1] = "medium";
            menu[1, 2] = "low";
            menu[1, 3] = "low";
            menu[2, 0] = "high";
            menu[2, 1] = "medium";
            menu[2, 2] = "low";
            menu[2, 3] = "low";
            return menu;
        }
    }
}
