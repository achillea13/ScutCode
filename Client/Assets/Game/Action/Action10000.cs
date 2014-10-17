using System;
using System.Collections.Generic;
using Server.Pack;
using ZyGames.Framework.Common.Serialization;

public class Action10000 : GameAction
{

	private static int iIdx = 1;
	Response10000Pack requestPack;

    public Action10000()
        : base((int)ActionType.UserRegister)
    {
    }

    protected override void SendParameter(NetWriter writer, object userData)
    {
        writer.writeString("UserName", "Jon"+iIdx++);
        writer.writeInt32("Password", 100);
    }

    protected override void DecodePackage(NetReader reader)
    {

		requestPack = ProtoBufUtils.Deserialize<Response10000Pack>(reader.Buffer);

		UnityEngine.Debug.Log(string.Format("ok, userid:{0}", requestPack.UserID));


    }

    protected override void Process(object userData)
    {
    }
}
