using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KALAYUNITSM.ENTITY
{
    public class LayUI<TEntity> where TEntity : class
    {
        public int code { get; set; }
        public bool result { get; set; }
        public string msg { get; set; }
        public List<TEntity> data { get; set; }
        public long count { get; set; } 
    }
}
