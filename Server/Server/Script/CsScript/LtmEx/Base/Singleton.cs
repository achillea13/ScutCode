using System;
using System.Collections.Generic;
using System.Text;


namespace Ltm.Base
{

    /*------------------    单例基类    -----------------------*/
    
    public class Singleton<T> where T : new()
    {
        private static T _instance = default(T);

        protected Singleton(){}


        public static T GetInstance()
        {
            if (_instance == null)
                _instance = new T();

            return _instance;
        }


    }

}
