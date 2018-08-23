using System;
using System.Collections.Generic;
using KALAYUNITSM.DATA;

namespace KALAYUNITSM.ENTITY
{
    public class Conf_CI_SEL
    {
        public List<position> positionlist { get; set; }

    }
    public class position
    {
        public List<string> p { get; set; }
        public List<c> c { get; set; }
    }
    public class c
    {
        public string n { get; set; }
        public List<a> a { get; set; }
    }
    public class a
    {
        public string s { get; set; }
    }
    public class Conf_CI_Combo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }

    }
}
