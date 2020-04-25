using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager
{
    class Resources
    {
        public string ResourceName;
        public string ResourceType;
        public bool Material;
        public int Max;
        public int StandardRate;
        public int OverTime;
        public int Cost;


        public Resources(string resource,string type,bool material,int max,int standardrate,int overtime,int cost)
        {
            ResourceName = resource;
            ResourceType = type;
            Material = material;
            Max = max;
            StandardRate = standardrate;
            OverTime = overtime;
            Cost = cost;
        }
    }
}
