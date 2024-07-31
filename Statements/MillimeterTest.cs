using MotionPlanning.Auxiliary;
using MotionPlanning.State;
using MotionPlanning.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotionPlanning.Job;
namespace UnitTest.Statements
{
    public class MillimeterTest
    {
        [Test]
        // Testing identification
        public void Identification()
        {
            Job job = new Job();
            string gcode = "G21 X141.379 Y84.536 E324.40933";
            IURScript statement = Identifier.Identify(gcode, job);
            Assert.That(statement.GetType(), Is.EqualTo(typeof(Millimeter)));
        }
        [Test]
        // Testing millimeter setting
        public void SetMillimeter()
        {
            string gcode = "G21 X141.379 Y84.536 E324.40933";
            Millimeter statement = new Millimeter(gcode);
            State st = new State();
            string result = statement.URScript(st);
            Assert.That(st.Millimeter, Is.True);
        }
    }
}
