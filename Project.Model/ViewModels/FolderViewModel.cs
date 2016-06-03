using Newtonsoft.Json;
using Project.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.ViewModels
{
    [DataContract]
    public class FolderViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int? ParentId { get; set; }

        [DataMember]
        public virtual Folder Parent { get; set; }

        [DataMember]
        public virtual ICollection<Folder> Children { get; set; }
    }
}
