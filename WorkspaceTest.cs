using MotionPlanning.State;
using MotionPlanning.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotionPlanning.Workspace;
using MotionPlanning.Coordinates;
using MotionPlanning.Job;
using MotionPlanning.Auxiliary;
using System.Windows.Shapes;

namespace UnitTest
{
    public class WorkspaceTest
    {
        [Test]
        // Testing area for lower left and upper right
        public void AreaLowerLeftUpperRight()
        {
            float tolerance = 0.1f;
            Coordinate2D lowerleft = new Coordinate2D(10, 10);
            Coordinate2D upperright = new Coordinate2D(20, 20);
            float height = 10;
            Workspace workspace = new Workspace(lowerleft, upperright, height);
            Assert.That(workspace.LowerX, Is.AtLeast(10 - tolerance));
            Assert.That(workspace.LowerX, Is.AtMost(10 + tolerance));
            Assert.That(workspace.UpperX, Is.AtLeast(20 - tolerance));
            Assert.That(workspace.UpperX, Is.AtMost(20 + tolerance));
            Assert.That(workspace.LowerY, Is.AtLeast(10 - tolerance));
            Assert.That(workspace.LowerY, Is.AtMost(10 + tolerance));
            Assert.That(workspace.UpperY, Is.AtLeast(20 - tolerance));
            Assert.That(workspace.UpperY, Is.AtMost(20 + tolerance));
            Assert.That(workspace.Height, Is.AtLeast(10 - tolerance));
            Assert.That(workspace.Height, Is.AtMost(10 + tolerance));
        }
        [Test]
        // Testing area for upper right and lower left
        public void AreaUpperRightLowerLeft()
        {
            float tolerance = 0.1f;
            Coordinate2D lowerleft = new Coordinate2D(10, 10);
            Coordinate2D upperright = new Coordinate2D(20, 20);
            float height = 10;
            Workspace workspace = new Workspace(upperright, lowerleft, height);
            Assert.That(workspace.LowerX, Is.AtLeast(10 - tolerance));
            Assert.That(workspace.LowerX, Is.AtMost(10 + tolerance));
            Assert.That(workspace.UpperX, Is.AtLeast(20 - tolerance));
            Assert.That(workspace.UpperX, Is.AtMost(20 + tolerance));
            Assert.That(workspace.LowerY, Is.AtLeast(10 - tolerance));
            Assert.That(workspace.LowerY, Is.AtMost(10 + tolerance));
            Assert.That(workspace.UpperY, Is.AtLeast(20 - tolerance));
            Assert.That(workspace.UpperY, Is.AtMost(20 + tolerance));
            Assert.That(workspace.Height, Is.AtLeast(10 - tolerance));
            Assert.That(workspace.Height, Is.AtMost(10 + tolerance));
        }
        [Test]
        // Testing area for upper left and lower right
        public void AreaUpperLeftLowerRight()
        {
            float tolerance = 0.1f;
            Coordinate2D upperleft = new Coordinate2D(10, 20);
            Coordinate2D lowerright = new Coordinate2D(20, 10);
            float height = 10;
            Workspace workspace = new Workspace(upperleft, lowerright, height);
            Assert.That(workspace.LowerX, Is.AtLeast(10 - tolerance));
            Assert.That(workspace.LowerX, Is.AtMost(10 + tolerance));
            Assert.That(workspace.UpperX, Is.AtLeast(20 - tolerance));
            Assert.That(workspace.UpperX, Is.AtMost(20 + tolerance));
            Assert.That(workspace.LowerY, Is.AtLeast(10 - tolerance));
            Assert.That(workspace.LowerY, Is.AtMost(10 + tolerance));
            Assert.That(workspace.UpperY, Is.AtLeast(20 - tolerance));
            Assert.That(workspace.UpperY, Is.AtMost(20 + tolerance));
            Assert.That(workspace.Height, Is.AtLeast(10 - tolerance));
            Assert.That(workspace.Height, Is.AtMost(10 + tolerance));
        }
        [Test]
        // Testing area for lower right and upper left 
        public void AreaLowerRightUpperLeft()
        {
            float tolerance = 0.1f;
            Coordinate2D upperleft = new Coordinate2D(10, 20);
            Coordinate2D lowerright = new Coordinate2D(20, 10);
            float height = 10;
            Workspace workspace = new Workspace(lowerright, upperleft, height);
            Assert.That(workspace.LowerX, Is.AtLeast(10 - tolerance));
            Assert.That(workspace.LowerX, Is.AtMost(10 + tolerance));
            Assert.That(workspace.UpperX, Is.AtLeast(20 - tolerance));
            Assert.That(workspace.UpperX, Is.AtMost(20 + tolerance));
            Assert.That(workspace.LowerY, Is.AtLeast(10 - tolerance));
            Assert.That(workspace.LowerY, Is.AtMost(10 + tolerance));
            Assert.That(workspace.UpperY, Is.AtLeast(20 - tolerance));
            Assert.That(workspace.UpperY, Is.AtMost(20 + tolerance));
            Assert.That(workspace.Height, Is.AtLeast(10 - tolerance));
            Assert.That(workspace.Height, Is.AtMost(10 + tolerance));
        }
        [Test]
        // Testing for valid job
        public void ValidJob()
        {
            Job job = new Job();
            Coordinate2D upperleft = new Coordinate2D(10, 10);
            Coordinate2D lowerright = new Coordinate2D(100, 100);
            float height = 100;
            Workspace workspace = new Workspace(lowerright, upperleft, height);
            string gcode1 = "G0 X41.379 Y84.536 E324.40933";
            string gcode2 = "G0 X11.379 Y84.536 E324.40933";
            string gcode3 = "G0 X11.379 Y34.536 Z56.34 E324.40933";

            IURScript statement1 = Identifier.Identify(gcode1, job);
            IURScript statement2 = Identifier.Identify(gcode2, job);
            IURScript statement3 = Identifier.Identify(gcode3, job);

            Assert.That(workspace.IsJobValid(job), Is.True);
        }
        [Test]
        // Testing for invalid job regaring to x-axis
        public void InvalidJobXAxis()
        {
            Job job = new Job();
            Coordinate2D upperleft = new Coordinate2D(10, 10);
            Coordinate2D lowerright = new Coordinate2D(100, 100);
            float height = 100;
            Workspace workspace = new Workspace(lowerright, upperleft, height);
            string gcode1 = "G0 X41.379 Y84.536 E324.40933";
            string gcode2 = "G0 X141.379 Y84.536 E324.40933";
            string gcode3 = "G0 X11.379 Y34.536 Z56.34 E324.40933";

            IURScript statement1 = Identifier.Identify(gcode1, job);
            IURScript statement2 = Identifier.Identify(gcode2, job);
            IURScript statement3 = Identifier.Identify(gcode3, job);

            Assert.That(workspace.IsJobValid(job), Is.False);
        }
        [Test]
        // Testing for invalid job regaring to y-axis
        public void InvalidJobYAxis()
        {
            Job job = new Job();
            Coordinate2D upperleft = new Coordinate2D(10, 10);
            Coordinate2D lowerright = new Coordinate2D(100, 100);
            float height = 100;
            Workspace workspace = new Workspace(lowerright, upperleft, height);
            string gcode1 = "G0 X41.379 Y84.536 E324.40933";
            string gcode2 = "G0 X11.379 Y184.536 E324.40933";
            string gcode3 = "G0 X11.379 Y34.536 Z56.34 E324.40933";

            IURScript statement1 = Identifier.Identify(gcode1, job);
            IURScript statement2 = Identifier.Identify(gcode2, job);
            IURScript statement3 = Identifier.Identify(gcode3, job);

            Assert.That(workspace.IsJobValid(job), Is.False);
        }
        [Test]
        // Testing for invalid job regaring to height
        public void InvalidJobHeight()
        {
            Job job = new Job();
            Coordinate2D upperleft = new Coordinate2D(10, 10);
            Coordinate2D lowerright = new Coordinate2D(100, 100);
            float height = 100;
            Workspace workspace = new Workspace(lowerright, upperleft, height);
            string gcode1 = "G0 X41.379 Y84.536 E324.40933";
            string gcode2 = "G0 X11.379 Y14.536 E324.40933";
            string gcode3 = "G0 X11.379 Y34.536 Z156.34 E324.40933";

            IURScript statement1 = Identifier.Identify(gcode1, job);
            IURScript statement2 = Identifier.Identify(gcode2, job);
            IURScript statement3 = Identifier.Identify(gcode3, job);

            Assert.That(workspace.IsJobValid(job), Is.False);
        }
    }
}
