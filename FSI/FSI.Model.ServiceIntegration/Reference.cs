using System.Collections.Generic;

namespace FSI.Model.ServiceIntegration
{
    public class Reference
    {

        public Reference(string refName)
        {
            ObjName = refName;
            Elements = new List<ReferenceElements>();
        }

        public string ObjName { get; set; }
        public string Path { get; set; }
        public string Initial { get; set; }
        public string Type { get; set; }
        public bool List { get; set; }
        public string NameSpace { get; set; }
        public int LevelsFromRoot { get; set; }
        public string xml{ get; set; }
        public List<ReferenceElements> Elements { get; set; }

    }
}
