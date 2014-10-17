using System;
using System.Collections.Generic;
using Server.Pack;
using ZyGames.Framework.Common.Serialization;

public class Action10001 : GameAction
{

	Response10001Pack responsePack;
	
	public Action10001()
		: base((int)ActionType.UserLogin)
	{
	}
	
	protected override void SendParameter(NetWriter writer, object userData)
	{
		writer.writeString("UserName", "Jon11");
		writer.writeInt32("Password", 100);
	}
	
	protected override void DecodePackage(NetReader reader)
	{
		
		responsePack = ProtoBufUtils.Deserialize<Response10001Pack>(reader.Buffer);
		String strErrorLog = "";


		switch ((LoginError)responsePack.ErrorCode) 
		{
		case LoginError.LE_NOT_EXIST:strErrorLog.Insert(0, "用户名不存在"); break;
		case LoginError.LE_PSD_ERROR:strErrorLog.Insert(0, "密码错误"); break;
		default: strErrorLog.Insert(0, "登陆成功");break;
		}
		
//		UnityEngine.Debug.Log(strErrorLog);
		
		
	}
	
	protected override void Process(object userData)
	{
	}
}