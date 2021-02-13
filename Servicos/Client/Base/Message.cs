using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AppWeb.Servicos.Client.Base
{
    [DataContract]
    public class Message<T>
    {
        [DataMember(Name = "success")]
        public bool Success { get; set; }

        [DataMember(Name = "data")]
        public T Data { get; set; }

        [DataMember(Name = "errors")]
        public List<string> Errors { get; set; }

    }
}
