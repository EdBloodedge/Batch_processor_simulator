﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    class Proceso
    {
        private string _Name;
        private int _TimeMax;
        private string _opName;
        private string _id;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public int TimeMax
        {
            get { return _TimeMax; }
            set { _TimeMax = value; }
        }

        public string opName
        {
            get { return _opName; }
            set { _opName = value; }
        }

        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
