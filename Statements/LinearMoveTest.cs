using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotionPlanning.Statements;
using MotionPlanning.State;
using MotionPlanning.Auxiliary;
using MotionPlanning.Job;
using MotionPlanning.Coordinates;
using MotionPlanning.Workspace;

namespace UnitTest.Statements
{
    public class LinearMoveTest
    {
        [Test]
        // Testing identification
        public void Identification()
        {
            Coordinate2D coord1 = new(10f, 10f);
            Coordinate2D coord2 = new(100f, 100f);
            Workspace workspace = new(coord1, coord2, 100, 10);
            Job job = new Job(workspace);
            string gcode = "G1 X141.379 Y84.536 E324.40933";
            IURScript statement = Identifier.Identify(gcode, job);
            Assert.That(statement.GetType(), Is.EqualTo(typeof(LinearMove)));
        }
        [Test]
        // Testing a valid statement
        public void ValidStatement()
        {
            float tolerance = 0.00001f;
            string gcode = "G1 X141.379 Y84.536 E324.40933";
            LinearMove stm = new LinearMove(gcode);
            Coordinate2D coord1 = new(10f, 10f);
            Coordinate2D coord2 = new(100f, 100f);
            Workspace workspace = new(coord1, coord2, 100, 10);
            State st = new State(workspace);
            Assert.That(stm.Valid, Is.True);
            Assert.That(stm.CommandType, Is.EqualTo('G'));
            Assert.That(stm.CommandNumber, Is.EqualTo(1));
            Assert.That(stm.X, Is.AtLeast(141.379 - tolerance));
            Assert.That(stm.X, Is.AtMost(141.379 + tolerance));
            Assert.That(stm.Y, Is.AtLeast(84.536 - tolerance));
            Assert.That(stm.Y, Is.AtMost(84.536 + tolerance));
            Assert.That(stm.Z, Is.AtMost(float.MinValue + tolerance));
        }

        [Test]
        // Testing shifted coordinate
        public void ShiftedCoordinate()
        {
            float tolerance = 0.001f;
            string gcode = "G1 X10.0 Y10.0 Z20.0";


            Coordinate2D coord1 = new(10f, 10f);
            Coordinate2D coord2 = new(100f, 100f);
            Workspace workspace = new(coord1, coord2, 100, 10);

            Job job = new Job(workspace);
            State st = job.GetState();

            job.AddStatement(Identifier.Identify(gcode, job));

            List<string> statements = job.GetURScript();


            Assert.That(job.XShift, Is.AtLeast(35f - tolerance));
            Assert.That(job.XShift, Is.AtMost(35f + tolerance));
            Assert.That(job.YShift, Is.AtLeast(35f - tolerance));
            Assert.That(job.YShift, Is.AtMost(35f + tolerance));
            Assert.That(job.ZShift, Is.AtLeast(-10f - tolerance));
            Assert.That(job.ZShift, Is.AtMost(-10f + tolerance));

            Assert.That(st.X, Is.AtLeast(45f - tolerance));
            Assert.That(st.X, Is.AtMost(45f + tolerance));
            Assert.That(st.Y, Is.AtLeast(45f - tolerance));
            Assert.That(st.Y, Is.AtMost(45f + tolerance));
            Assert.That(st.Z, Is.AtLeast(10f - tolerance));
            Assert.That(st.Z, Is.AtMost(10f + tolerance));
        }

        [Test]
        // Testing move statements
        public void Movement()
        {
            float tolerance = 0.001f;
            string gcode1 = "G1 X10.0 Y10.0 Z20.0";
            string gcode2 = "G1 X20.0";
            string gcode3 = "G1 Y20.0";
            string gcode4 = "G1 Z40.0";


            Coordinate2D coord1 = new(10f, 10f);
            Coordinate2D coord2 = new(100f, 100f);
            Workspace workspace = new(coord1, coord2, 100, 10);

            Job job = new Job(workspace);
            job.AddStatement(Identifier.Identify(gcode1, job));
            job.AddStatement(Identifier.Identify(gcode2, job));
            job.AddStatement(Identifier.Identify(gcode3, job));
            job.AddStatement(Identifier.Identify(gcode4, job));

            List<string> statements = job.GetURScript();

            State st = job.GetState();

            Assert.That(st.X, Is.AtLeast(20f + st.XShift - tolerance));
            Assert.That(st.X, Is.AtMost(20f + st.XShift + tolerance));
            Assert.That(st.Y, Is.AtLeast(20f + st.YShift - tolerance));
            Assert.That(st.Y, Is.AtMost(20f + st.YShift + tolerance));
            Assert.That(st.Z, Is.AtLeast(40f + st.ZShift - tolerance));
            Assert.That(st.Z, Is.AtMost(40f + st.ZShift + tolerance));
        }

    }
}
