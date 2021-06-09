using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    public class CustomThreeuple<T1,T2,T3>
    {
        public T1 item1 { get; set; }
        public T2 item2 { get; set; }
        public T3 item3 { get; set; }
    }
}
