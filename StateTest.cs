using MotionPlanning.Coordinates;
using MotionPlanning.State;
using MotionPlanning.Statements;
using MotionPlanning.Workspace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class StateTest
    {
        [Test]
        // Testing movement
        public void Move()
        {
            float tolerance = 0.00001f;
            Coordinate2D coord1 = new(10f, 10f);
            Coordinate2D coord2 = new(100f, 100f);
            Workspace workspace = new(coord1, coord2, 100, 10);
            State st = new State(workspace);
            string gcode1 = "G0 X141.379 Y84.536 E324.40933";
            RapidMove stm1 = new RapidMove(gcode1);
            stm1.URScript(st);
            string gcode2 = "G0 X114.379 Y48.536 Z10.04 E324.40933";
            RapidMove stm2 = new RapidMove(gcode2);
            stm2.URScript(st);
            Assert.That(st.X, Is.AtLeast(114.379 - tolerance));
            Assert.That(st.X, Is.AtMost(114.379 + tolerance));
            Assert.That(st.Y, Is.AtLeast(48.536 - tolerance));
            Assert.That(st.Y, Is.AtMost(48.536 + tolerance));
            Assert.That(st.Z, Is.AtLeast(10.04 - tolerance));
            Assert.That(st.Z, Is.AtMost(10.04 + tolerance));
        }
        [Test]
        // Testing relative positioning
        public void RelativePositioning()
        {
            float tolerance = 0.00001f;
            Coordinate2D coord1 = new(10f, 10f);
            Coordinate2D coord2 = new(100f, 100f);
            Workspace workspace = new(coord1, coord2, 100, 10);
            State st = new State(workspace);
            string gcode1 = "G0 X141.379 Y84.536 E324.40933";
            RapidMove stm1 = new RapidMove(gcode1);
            stm1.URScript(st);
            st.Relative = true;
            string gcode2 = "G0 X10.000 Y10.000 E324.40933";
            RapidMove stm2 = new RapidMove(gcode2);
            stm2.URScript(st);
            Assert.That(st.X, Is.AtLeast(151.379 - tolerance));
            Assert.That(st.X, Is.AtMost(151.379 + tolerance));
            Assert.That(st.Y, Is.AtLeast(94.536 - tolerance));
            Assert.That(st.Y, Is.AtMost(94.536 + tolerance));
            Assert.That(st.Z, Is.AtMost(float.MinValue + tolerance));
        }
        [Test]
        // Testing a statement with inches
        public void Inches()
        {
            float tolerance = 0.0001f;
            Coordinate2D coord1 = new(10f, 10f);
            Coordinate2D coord2 = new(100f, 100f);
            Workspace workspace = new(coord1, coord2, 100, 10);
            State st = new State(workspace);
            st.Millimeter = false;
            string gcode = "G0 X141.379 Y84.536 E324.40933";
            RapidMove stm = new RapidMove(gcode);
            stm.URScript(st);
            Assert.That(st.X, Is.AtLeast(3591.0266 - tolerance));
            Assert.That(st.X, Is.AtMost(3591.0266 + tolerance));
            Assert.That(st.Y, Is.AtLeast(2147.2144 - tolerance));
            Assert.That(st.Y, Is.AtMost(2147.2144 + tolerance));
            Assert.That(st.Z, Is.AtMost(float.MinValue + tolerance));
        }
    }
}
