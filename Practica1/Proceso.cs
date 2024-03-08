using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1
{
    class Proceso
    {
        private string _Name;
        private int _TimeMax;
        private string _opName;
        private string _id;
        private GroupBox _gBox;
        private int _intTime;
        private Label _intLabel;
        private int _indexLabel;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public int indexLabel
        {
            get { return _indexLabel; }
            set { _indexLabel = value; }
        }
        public Label intLabel
        {
            get { return _intLabel; }
            set { _intLabel = value; }
        }
        public int intTime
        {
            get { return _intTime; }
            set { _intTime = value; }
        }
        public GroupBox gBox
        {
            get { return _gBox; }
            set { _gBox = value; }
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
