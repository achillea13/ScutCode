using System;
using System.Collections.Generic;
using System.Text;

using Ltm.Base;

namespace Ltm.Config
{

    public class CfgManager : Singleton<CfgManager>
    {
        public enum CFG_TYPE
        {
            CT_DROP = 1,
        }


        private Dictionary<CFG_TYPE, BaseCfg> dictCfg = new Dictionary<CFG_TYPE,BaseCfg>();


        public void Init()
        {
            
            AddCfg(CFG_TYPE.CT_DROP, "Config/ai.txt");
        }


        public bool AddCfg(CFG_TYPE eType ,string _fileName)
        {

            BaseCfg cfg = new BaseCfg();
            if (cfg.Init(_fileName) == true)
            {
                dictCfg.Add(eType, cfg);

                return true;
            }
                

            return false;

        }

        // 获取相关配置
        // eType    :配置类型
        public BaseCfg GetCfg( CFG_TYPE eType )
        {
            BaseCfg bc = null;
            if (dictCfg.TryGetValue(eType, out bc))
                return bc;

            return null; 
        }

    }

}
