using SQLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceDog.SQLinq.UnitTest.Model
{
    [SQLinqTable("IDS_Good_Person")]
    public class GoodPerson
    {
        public Guid ID { get; set; }

        [SQLinqColumn("First_Name")]
        public string FirstName { get; set; }

        [SQLinqColumn("Last_Name")]
        public string LastName { get; set; }
        //如果列明和属性名一致，则不用写映射
        public int Age { get; set; }
    }
}
