﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KALAYUNITSM.ENTITY
{
    public class ZTreeNode
    {
        /// <summary>
        /// 节点ID。
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 父节点ID。
        /// </summary>
        public string pId { get; set; }
        /// <summary>
        /// 节点名称。
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 是否展开。
        /// </summary>
        public bool open { get; set; }
        /// <summary>
        /// 是否选中。
        /// </summary>
        public bool @checked { get; set; }
    }
}
