using System.Collections.Generic;
using ProtoBuf;

namespace Server.Pack
{
    [ProtoContract]
    public class Response10000Pack
    {
        [ProtoMember(101)]
        public int UserID { get; set; }


        [ProtoMember(102)]
        public string UserName { get; set; }


    }

}
