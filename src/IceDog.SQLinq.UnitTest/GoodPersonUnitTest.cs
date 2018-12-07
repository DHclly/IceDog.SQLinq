using System;
using System.Data.SqlClient;
using IceDog.SQLinq.UnitTest.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLinq;

namespace IceDog.SQLinq.UnitTest
{
    [TestClass]
    public class GoodPersonUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var query = from d in new SQLinq<GoodPerson>()
                        where d.FirstName.StartsWith("C")
                             && d.Age > 18
                        orderby d.FirstName
                        select new
                        {
                            id = d.ID,
                            firstName = d.FirstName
                        };
            var queryResult = query.ToSQL();
            // get the full SQL code
            var sqlCode = queryResult.ToQuery();

            // get the query parameters necessary to execute the above query
            var sqlParameters = queryResult.Parameters;
            var dbconnection = new SqlConnection();
            var cmd = new SqlCommand(sqlCode,dbconnection);
            foreach (var p in sqlParameters)
            {
                cmd.Parameters.AddWithValue(p.Key, p.Value);
            }
            // now execute the command and get the results from the database
        }

        [TestMethod]
        public void TestMethod2()
        {
        }
    }
}
