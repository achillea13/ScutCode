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
    /// 10000_register【已完成】
    /// </summary>
    public class Action10000 : BaseAction
    {
        private string UserName;
        private string Password;
        private int UserID;

        private Response10000Pack responsePack;


        public Action10000(HttpGet httpGet)
            : base(ActionIDDefine.Cst_Action10000, httpGet)
        {

        }


        protected override byte[] BuildResponsePack()
        {
            responsePack = new Response10000Pack();
            responsePack.UserID = UserID;
            responsePack.UserName = UserName;

            return ProtoBufUtils.Serialize(responsePack);

        }

        public override bool GetUrlElement()
        {
            if (httpGet.GetString("UserName", ref UserName)
                 && httpGet.GetString("Password", ref Password))
            {

                return true;
            }
            return false;
        }

        public override bool TakeAction()
        {

            // 检查用户名合法性

            // 检查密码合法性


            var cache = new PersonalCacheStruct<UserAccount>();
            var res = cache.FindGlobal(m => m.UserName.Equals(UserName));
            if (res.Count > 0)
            {
                // 已被注册用户名

                UserId = 0;
            }
            else
            {
                // 可以注册
                var account = new UserAccount();
                account.UserName = UserName;
                account.Password = Password;
                account.UserId = (int)cache.GetNextNo();
                cache.Add(account);
                cache.Update();

                UserID = account.UserId;
            }


            return true;
        }
    }
}
