using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKPokeEditor.Class
{
    public class Pokemon
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int BaseHP { get; set; }
        public int BaseAttack { get; set; }
        public int BaseDefense { get; set; }
        public int BaseSpeed { get; set; }
        public int BaseSpAttack { get; set; }
        public int BaseSpDefense { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
    }
}
