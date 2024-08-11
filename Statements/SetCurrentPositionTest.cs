using MotionPlanning.Auxiliary;
using MotionPlanning.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotionPlanning.Job;
using MotionPlanning.Coordinates;
using MotionPlanning.Workspace;
using MotionPlanning.State;

namespace UnitTest.Statements
{
    public class SetCurrentPositionTest
    {
        [Test]
        // Testing identification
        public void Identification()
        {
            Coordinate2D coord1 = new(10f, 10f);
            Coordinate2D coord2 = new(100f, 100f);
            Workspace workspace = new(coord1, coord2, 100, 10);
            Job job = new Job(workspace);
            string gcode = "G92 X141.379 Y84.536 E324.40933";
            IURScript statement = Identifier.Identify(gcode, job);
            Assert.That(statement.GetType(), Is.EqualTo(typeof(SetCurrentPosition)));            
        }

        [Test]
        // Testing no coordinates provided
        public void NoCoordinates()
        {
            string gcode = "G92 E324.40933";
            SetCurrentPosition statement = new(gcode);
            Assert.That(statement.X, Is.EqualTo(float.MinValue));
            Assert.That(statement.Y, Is.EqualTo(float.MinValue));
            Assert.That(statement.Z, Is.EqualTo(float.MinValue));
        }

        [Test]
        // Test all axes to zero
        public void AllAxesToZero()
        {
            float tolerance = 0.001f;
            List<string> statements;
            Coordinate2D coord1 = new(10f, 10f);
            Coordinate2D coord2 = new(100f, 100f);
            Workspace workspace = new(coord1, coord2, 100, 10);
            Job job = new Job(workspace);
            State st = job.GetState();

            string gcode1 = "G1 X5.0 Y20.0 Z20.0";
            string gcode2 = "G1 X25.0 Y40.0 Z40.0";
            string gcode3 = "G92";
            string gcode4 = "G1 X10.0 Y30.0 Z30.0";

            job.AddStatement(Identifier.Identify(gcode1, job));
            job.AddStatement(Identifier.Identify(gcode2, job));
            job.AddStatement(Identifier.Identify(gcode3, job));
            job.AddStatement(Identifier.Identify(gcode4, job));

            statements = job.GetURScript();

            Assert.That(st.XShift, Is.AtLeast(55f - tolerance));
            Assert.That(st.XShift, Is.AtMost(55f + tolerance));
            Assert.That(st.YShift, Is.AtLeast(55f - tolerance));
            Assert.That(st.YShift, Is.AtMost(55f + tolerance));
            Assert.That(st.ZShift, Is.AtLeast(30f - tolerance));
            Assert.That(st.ZShift, Is.AtMost(30f + tolerance));

            Assert.That(st.X, Is.AtLeast(65f - tolerance));
            Assert.That(st.X, Is.AtMost(65f + tolerance));
            Assert.That(st.Y, Is.AtLeast(85f - tolerance));
            Assert.That(st.Y, Is.AtMost(85f + tolerance));
            Assert.That(st.Z, Is.AtLeast(60f - tolerance));
            Assert.That(st.Z, Is.AtMost(60f + tolerance));
        }

        [Test]
        // Test only x-axis
        public void OnlyXAxis()
        {
            float tolerance = 0.001f;
            List<string> statements;
            Coordinate2D coord1 = new(10f, 10f);
            Coordinate2D coord2 = new(100f, 100f);
            Workspace workspace = new(coord1, coord2, 100, 10);
            Job job = new Job(workspace);
            State st = job.GetState();

            string gcode1 = "G1 X5.0 Y20.0 Z20.0";
            string gcode2 = "G1 X25.0 Y40.0 Z40.0";
            string gcode3 = "G92 X10.0";
            string gcode4 = "G1 X10.0 Y30.0 Z30.0";

            job.AddStatement(Identifier.Identify(gcode1, job));
            job.AddStatement(Identifier.Identify(gcode2, job));
            job.AddStatement(Identifier.Identify(gcode3, job));
            job.AddStatement(Identifier.Identify(gcode4, job));

            statements = job.GetURScript();

            Assert.That(st.XShift, Is.AtLeast(45f - tolerance));
            Assert.That(st.XShift, Is.AtMost(45f + tolerance));
            Assert.That(st.YShift, Is.AtLeast(15f - tolerance));
            Assert.That(st.YShift, Is.AtMost(15f + tolerance));
            Assert.That(st.ZShift, Is.AtLeast(-10f - tolerance));
            Assert.That(st.ZShift, Is.AtMost(-10f + tolerance));

            Assert.That(st.X, Is.AtLeast(55f - tolerance));
            Assert.That(st.X, Is.AtMost(55f + tolerance));
            Assert.That(st.Y, Is.AtLeast(45f - tolerance));
            Assert.That(st.Y, Is.AtMost(45f + tolerance));
            Assert.That(st.Z, Is.AtLeast(20f - tolerance));
            Assert.That(st.Z, Is.AtMost(20f + tolerance));
        }

        [Test]
        // Test only y-axis
        public void OnlyYAxis()
        {
            float tolerance = 0.001f;
            List<string> statements;
            Coordinate2D coord1 = new(10f, 10f);
            Coordinate2D coord2 = new(100f, 100f);
            Workspace workspace = new(coord1, coord2, 100, 10);
            Job job = new Job(workspace);
            State st = job.GetState();

            string gcode1 = "G1 X5.0 Y20.0 Z20.0";
            string gcode2 = "G1 X25.0 Y40.0 Z40.0";
            string gcode3 = "G92 Y10.0";
            string gcode4 = "G1 X10.0 Y30.0 Z30.0";

            job.AddStatement(Identifier.Identify(gcode1, job));
            job.AddStatement(Identifier.Identify(gcode2, job));
            job.AddStatement(Identifier.Identify(gcode3, job));
            job.AddStatement(Identifier.Identify(gcode4, job));

            statements = job.GetURScript();

            Assert.That(st.XShift, Is.AtLeast(30f - tolerance));
            Assert.That(st.XShift, Is.AtMost(30f + tolerance));
            Assert.That(st.YShift, Is.AtLeast(45f - tolerance));
            Assert.That(st.YShift, Is.AtMost(45f + tolerance));
            Assert.That(st.ZShift, Is.AtLeast(-10f - tolerance));
            Assert.That(st.ZShift, Is.AtMost(-10f + tolerance));

            Assert.That(st.X, Is.AtLeast(40f - tolerance));
            Assert.That(st.X, Is.AtMost(40f + tolerance));
            Assert.That(st.Y, Is.AtLeast(75f - tolerance));
            Assert.That(st.Y, Is.AtMost(75f + tolerance));
            Assert.That(st.Z, Is.AtLeast(20f - tolerance));
            Assert.That(st.Z, Is.AtMost(20f + tolerance));
        }

        [Test]
        // Test only z-axis
        public void OnlyZAxis()
        {
            float tolerance = 0.001f;
            List<string> statements;
            Coordinate2D coord1 = new(10f, 10f);
            Coordinate2D coord2 = new(100f, 100f);
            Workspace workspace = new(coord1, coord2, 100, 10);
            Job job = new Job(workspace);
            State st = job.GetState();

            string gcode1 = "G1 X5.0 Y20.0 Z20.0";
            string gcode2 = "G1 X25.0 Y40.0 Z40.0";
            string gcode3 = "G92 Z10.0";
            string gcode4 = "G1 X10.0 Y30.0 Z30.0";

            job.AddStatement(Identifier.Identify(gcode1, job));
            job.AddStatement(Identifier.Identify(gcode2, job));
            job.AddStatement(Identifier.Identify(gcode3, job));
            job.AddStatement(Identifier.Identify(gcode4, job));

            statements = job.GetURScript();

            Assert.That(st.XShift, Is.AtLeast(30f - tolerance));
            Assert.That(st.XShift, Is.AtMost(30f + tolerance));
            Assert.That(st.YShift, Is.AtLeast(15f - tolerance));
            Assert.That(st.YShift, Is.AtMost(15f + tolerance));
            Assert.That(st.ZShift, Is.AtLeast(20f - tolerance));
            Assert.That(st.ZShift, Is.AtMost(20f + tolerance));

            Assert.That(st.X, Is.AtLeast(40f - tolerance));
            Assert.That(st.X, Is.AtMost(40f + tolerance));
            Assert.That(st.Y, Is.AtLeast(45f - tolerance));
            Assert.That(st.Y, Is.AtMost(45f + tolerance));
            Assert.That(st.Z, Is.AtLeast(50f - tolerance));
            Assert.That(st.Z, Is.AtMost(50f + tolerance));
        }

    }
}
