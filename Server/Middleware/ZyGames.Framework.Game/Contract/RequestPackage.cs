﻿/****************************************************************************
Copyright (c) 2013-2015 scutgame.com

http://www.scutgame.com

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
****************************************************************************/
using System;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using ProtoBuf;
using ZyGames.Framework.Common.Serialization;

namespace ZyGames.Framework.Game.Contract
{
    /// <summary>
    /// Request message package
    /// </summary>
    [ProtoContract, Serializable]
    public class RequestPackage
    {
        /// <summary>
        /// init
        /// </summary>
        public RequestPackage()
        {

        }
        /// <summary>
        /// init
        /// </summary>
        public RequestPackage(int msgId, string sessionId, int actionId, int userId)
        {
            MsgId = msgId;
            SessionId = sessionId;
            ProxySid = Guid.Empty;
            ActionId = actionId;
            UserId = userId;
        }

        /// <summary>
        /// message id of client request
        /// </summary>
        [ProtoMember(1)]
        public int MsgId { get; protected set; }
        /// <summary>
        /// Action route key
        /// </summary>
        [ProtoMember(2)]
        public int ActionId { get; protected set; }

        /// <summary>
        /// 服务器间内部通讯通道
        /// </summary>
        [ProtoMember(3)]
        public string RouteName { get; set; }
        /// <summary>
        /// session id of client
        /// </summary>
        [ProtoMember(4)]
        public string SessionId { get; protected set; }

        /// <summary>
        /// session id of client
        /// </summary>
        [ProtoMember(5)]
        public int UserId { get; protected set; }

        /// <summary>
        /// is proxy server connect
        /// </summary>
        [ProtoMember(6)]
        public bool IsProxyRequest { get; set; }

        /// <summary>
        /// Proxy server connect sid
        /// </summary>
        [ProtoMember(7)]
        public Guid ProxySid { get; set; }

        /// <summary>
        /// 是否是Url格式参数类型
        /// </summary>
        [ProtoMember(8)]
        public bool IsUrlParam { get; internal protected set; }

        /// <summary>
        /// param for url request
        /// </summary>
        [ProtoMember(9)]
        public string UrlParam { get; set; }


        /// <summary>
        /// Message of custom
        /// </summary>
        public object Message { get; set; }

        /// <summary>
        /// GameSession
        /// </summary>
        [JsonIgnore]
        public GameSession Session { get; internal protected set; }
        /// <summary>
        /// Receive time
        /// </summary>
        public DateTime ReceiveTime { get; internal protected set; }
    }
}