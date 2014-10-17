using System;
using System.Data;
using GameServer.Model;
using ZyGames.Framework.Cache.Generic;
using ZyGames.Framework.Common.Serialization;
using ZyGames.Framework.Game.Contract;
using ZyGames.Framework.Game.Service;
using Server.Pack;



namespace GameServer.CsScript.Action
{
   
    /// <summary>
    /// 10001_登陆
    /// </summary>
    public class Action10001 : BaseAction
    {
        private string UserName;
        private string Password;
        private int UserID;

        private Response10001Pack responsePack;
        

        public Action10001(HttpGet httpGet)
            : base(ActionIDDefine.Cst_Action10001, httpGet)
        {
            
        }

        public override void BuildPacket()
        {
                this.PushIntoStack(UserID);

        }

        protected override byte[] BuildResponsePack()
        {
            responsePack = new Response10001Pack();
            responsePack.UserID = UserID;
            responsePack.UserName = UserName;

            return ProtoBufUtils.Serialize(responsePack);

        }

        public override bool GetUrlElement()
        {
            if (httpGet.GetString("UserName", ref UserName)            
                 &&httpGet.GetString("Password", ref Password))
            {
                return true;
            }
            return false;
        }

        public override bool TakeAction()
        {
            

            var cache = new PersonalCacheStruct<UserAccount>();
            var res = cache.FindGlobal(m => m.UserName.Equals(UserName));
            if (res.Count > 0)
            {

                if ( res[0].Password.Equals(Password) )
                {
                    responsePack.UserID = res[0].UserId;
                    responsePack.UserName = res[0].UserName;
                }
                else
                {
                    // 密码错误
                    responsePack.ErrorCode = (int)LoginError.LE_PSD_ERROR;
                }


                
            }
            else
            {
                // 不存在用户
                UserId = 0;
                responsePack.ErrorCode = (int)LoginError.LE_NOT_EXIST;
            }

            return true;
        }
    }
}
