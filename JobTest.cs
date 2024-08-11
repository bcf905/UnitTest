using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotionPlanning.Job;
using MotionPlanning.State;
using MotionPlanning.Statements;
using MotionPlanning.Auxiliary;
using System.Windows.Shapes;
using MotionPlanning.Coordinates;
using MotionPlanning.Workspace;

namespace UnitTest
{
    public class JobTest
    {
        [Test]
        // Testing for a job's valid statements
        public void ValidStatements()
        {
            string gcode1 = "G1 X141.379 Y84.536 E324.40933";
            string gcode2 = "G0 X141.379 Y84.536 E324.40933";
            string gcode3 = "G11 X141.379 Y84.536 E324.40933";

            Coordinate2D coord1 = new(10f, 10f);
            Coordinate2D coord2 = new(100f, 100f);
            Workspace workspace = new(coord1, coord2, 100, 10);

            Job job = new Job(workspace);

            IURScript linear = Identifier.Identify(gcode1, job);
            IURScript rapid = Identifier.Identify(gcode2, job);
            IURScript invalid = Identifier.Identify(gcode3, job);


            job.AddStatement(linear);
            job.AddStatement(rapid);
            job.AddStatement(invalid);

            List<string> urscript = job.GetURScript();

            Assert.That(urscript.Count, Is.EqualTo(2));
        }
        [Test]
        // Testing a job for bounds
        public void Bounds()
        {
            float tolerance = 0.0001f;
            Coordinate2D coord1 = new(10f, 10f);
            Coordinate2D coord2 = new(100f, 100f);
            Workspace workspace = new(coord1, coord2, 100, 10);
            Job job = new Job(workspace);
            string gcode = "G0 X141.379 Y84.536 E324.40933";
            IURScript statement = Identifier.Identify(gcode, job);
            job.AddStatement(statement);
            string gcode2 = "G0 X141.379 Y84.536 Z1.25 E324.40933";
            IURScript statement2 = Identifier.Identify(gcode2, job);
            job.AddStatement(statement2);
            string gcode3 = "G0 X111.379 Y94.536 Z10.25 E324.40933";
            IURScript statement3 = Identifier.Identify(gcode3, job);
            job.AddStatement(statement3);

            Assert.That(job.MinX, Is.AtLeast(111.379 - tolerance));
            Assert.That(job.MinX, Is.AtMost(111.379 + tolerance));
            Assert.That(job.MaxX, Is.AtLeast(141.379 - tolerance));
            Assert.That(job.MaxX, Is.AtMost(141.379 + tolerance));
            Assert.That(job.MinY, Is.AtLeast(84.536 - tolerance));
            Assert.That(job.MinY, Is.AtMost(84.536 + tolerance));
            Assert.That(job.MaxY, Is.AtLeast(94.536 - tolerance));
            Assert.That(job.MaxY, Is.AtMost(94.536 + tolerance));
            Assert.That(job.MinZ, Is.AtLeast(1.25 - tolerance));
            Assert.That(job.MinZ, Is.AtMost(1.25 + tolerance));
            Assert.That(job.MaxZ, Is.AtLeast(10.25 - tolerance));
            Assert.That(job.MaxZ, Is.AtMost(10.25 + tolerance));
        }

        [Test]
        // Test shifting values on all axes
        public void ShiftXYZ()
        {
            float tolerance = 0.001f;

            Coordinate2D coord1 = new(10f, 10f);
            Coordinate2D coord2 = new(100f, 100f);
            Workspace workspace = new(coord1, coord2, 100, 10);

            Job job = new Job(workspace);

            string gcode1 = "G0 X5.00 Y20.00 Z1.00 E324.40933";
            string gcode2 = "G0 X25.00 Y40.00 E324.40933";
            string gcode3 = "G0 X20.379 Y34.536 Z56.00 E324.40933";

            IURScript statement1 = Identifier.Identify(gcode1, job);
            job.AddStatement(statement1);

            IURScript statement2 = Identifier.Identify(gcode2, job);
            job.AddStatement(statement2);

            IURScript statement3 = Identifier.Identify(gcode3, job);
            job.AddStatement(statement3);

            List<string> statements = job.GetURScript();

            Assert.That(job.XShift, Is.AtLeast(30f - tolerance));
            Assert.That(job.XShift, Is.AtMost(30f + tolerance));
            Assert.That(job.YShift, Is.AtLeast(15f - tolerance));
            Assert.That(job.YShift, Is.AtMost(15f + tolerance));
            Assert.That(job.ZShift, Is.AtLeast(9f - tolerance));
            Assert.That(job.ZShift, Is.AtMost(9f + tolerance));

            State st = job.GetState();
            Assert.That(st.XShift, Is.AtLeast(30f - tolerance));
            Assert.That(st.XShift, Is.AtMost(30f + tolerance));
            Assert.That(st.YShift, Is.AtLeast(15f - tolerance));
            Assert.That(st.YShift, Is.AtMost(15f + tolerance));
            Assert.That(st.ZShift, Is.AtLeast(9f - tolerance));
            Assert.That(st.ZShift, Is.AtMost(9f + tolerance));
        }
    }
}
