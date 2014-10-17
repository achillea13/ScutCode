using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Pack
{
    public class SVector3
    {
        public float z;

        public float y;

        public float x;

        public SVector3() { }
        public SVector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    public class SVector2
    {
        public float x;
        public float y;

        public SVector2() { }
        public SVector2(float x, float y)
        {
            this.x = x;
            this.y = y;

        }
    }
}
