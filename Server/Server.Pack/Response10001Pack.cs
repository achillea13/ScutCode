using System.Collections.Generic;
using ProtoBuf;

namespace Server.Pack
{
    [ProtoContract]
    public class Response10001Pack
    {


        [ProtoMember(101)]
        public int UserID { get; set; }


        [ProtoMember(102)]
        public string UserName { get; set; }


        [ProtoMember(103)]
        public int ErrorCode { get; set; }

    }

}
