using MotionPlanning.Auxiliary;
using MotionPlanning.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Statements
{
    public class HomeTest
    {
        [Test]
        // Testing identification
        public void Identification()
        {
            string gcode = "G28 X141.379 Y84.536 E324.40933";
            IURScript statement = Identifier.Identify(gcode);
            Assert.That(statement.GetType(), Is.EqualTo(typeof(Home)));
        }
    }
}
