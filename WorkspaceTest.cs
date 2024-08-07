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
using NUnit.Framework.Constraints;

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
            float offset = 0f;
            Workspace workspace = new Workspace(lowerleft, upperright, height, offset);
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
            float offset = 0f;
            Workspace workspace = new Workspace(upperright, lowerleft, height, offset);
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
            float offset = 0f;
            Workspace workspace = new Workspace(upperleft, lowerright, height, offset);
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
            float offset = 0f;
            Workspace workspace = new Workspace(lowerright, upperleft, height, offset);
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
            Coordinate2D upperleft = new Coordinate2D(10, 10);
            Coordinate2D lowerright = new Coordinate2D(100, 100);
            float height = 100;
            float offset = 0f;
            Workspace workspace = new Workspace(lowerright, upperleft, height, offset);
            Job job = new Job(workspace);
            string gcode1 = "G0 X41.379 Y84.536 E324.40933";
            string gcode2 = "G0 X11.379 Y84.536 E324.40933";
            string gcode3 = "G0 X11.379 Y34.536 Z56.34 E324.40933";

            IURScript statement1 = Identifier.Identify(gcode1, job);
            IURScript statement2 = Identifier.Identify(gcode2, job);
            IURScript statement3 = Identifier.Identify(gcode3, job);

            Assert.That(workspace.IsJobValid(job), Is.True);
        }
        [Test]
        // Testing for invalid job regarding to x-axis
        public void InvalidJobXAxis()
        {
            Coordinate2D upperleft = new Coordinate2D(10, 10);
            Coordinate2D lowerright = new Coordinate2D(100, 100);
            float height = 100;
            float offset = 0f;
            Workspace workspace = new Workspace(lowerright, upperleft, height, offset);
            Job job = new Job(workspace);
            string gcode1 = "G0 X41.379 Y84.536 E324.40933";
            string gcode2 = "G0 X141.379 Y84.536 E324.40933";
            string gcode3 = "G0 X11.379 Y34.536 Z56.34 E324.40933";

            IURScript statement1 = Identifier.Identify(gcode1, job);
            IURScript statement2 = Identifier.Identify(gcode2, job);
            IURScript statement3 = Identifier.Identify(gcode3, job);

            Assert.That(workspace.IsJobValid(job), Is.False);
        }
        [Test]
        // Testing for invalid job regarding to y-axis
        public void InvalidJobYAxis()
        {
            Coordinate2D upperleft = new Coordinate2D(10, 10);
            Coordinate2D lowerright = new Coordinate2D(100, 100);
            float height = 100;
            float offset = 0f;
            Workspace workspace = new Workspace(lowerright, upperleft, height, offset);
            Job job = new Job(workspace);
            string gcode1 = "G0 X41.379 Y84.536 E324.40933";
            string gcode2 = "G0 X11.379 Y184.536 E324.40933";
            string gcode3 = "G0 X11.379 Y34.536 Z56.34 E324.40933";

            IURScript statement1 = Identifier.Identify(gcode1, job);
            IURScript statement2 = Identifier.Identify(gcode2, job);
            IURScript statement3 = Identifier.Identify(gcode3, job);

            Assert.That(workspace.IsJobValid(job), Is.False);
        }
        [Test]
        // Testing for invalid job regarding to height
        public void InvalidJobHeight()
        {
            Coordinate2D upperleft = new Coordinate2D(10, 10);
            Coordinate2D lowerright = new Coordinate2D(100, 100);
            float height = 100;
            float offset = 0f;
            Workspace workspace = new Workspace(lowerright, upperleft, height, offset);
            Job job = new Job(workspace);
            string gcode1 = "G0 X41.379 Y84.536 Z0.0 E324.40933";
            string gcode2 = "G0 X11.379 Y14.536 E324.40933";
            string gcode3 = "G0 X11.379 Y34.536 Z156.34 E324.40933";

            IURScript statement1 = Identifier.Identify(gcode1, job);
            IURScript statement2 = Identifier.Identify(gcode2, job);
            IURScript statement3 = Identifier.Identify(gcode3, job);

            Assert.That(workspace.IsJobValid(job), Is.False);
        }
        [Test]
        // Testing shifting for job
        public void Calibration()
        {
            float tolerance = 0.001f;
            
            Coordinate2D coord1 = new Coordinate2D(10, 10);
            Coordinate2D coord2 = new Coordinate2D(100, 100);
            float height = 100;
            float offset = 0f;
            Workspace workspace = new Workspace(coord1, coord2, height, offset);
            Job job = new Job(workspace);

            Assert.That(workspace.LowerX, Is.AtLeast(10 - tolerance));
            Assert.That(workspace.LowerX, Is.AtMost(10 + tolerance));
            Assert.That(workspace.LowerY, Is.AtLeast(10 - tolerance));
            Assert.That(workspace.LowerY, Is.AtMost(10 + tolerance));
            Assert.That(workspace.UpperX, Is.AtLeast(100 - tolerance));
            Assert.That(workspace.UpperX, Is.AtMost(100 + tolerance));
            Assert.That(workspace.UpperY, Is.AtLeast(100 - tolerance));
            Assert.That(workspace.UpperY, Is.AtMost(100 + tolerance));

            string gcode1 = "G0 X5.00 Y20.00 Z1.00 E324.40933";
            string gcode2 = "G0 X25.00 Y40.00 E324.40933";
            string gcode3 = "G0 X20.379 Y34.536 Z56.00 E324.40933";

            IURScript statement1 = Identifier.Identify(gcode1, job);
            IURScript statement2 = Identifier.Identify(gcode2, job);
            IURScript statement3 = Identifier.Identify(gcode3, job);

            job.AddStatement(statement1);
            job.AddStatement(statement2);
            job.AddStatement(statement3);

            Assert.That(job.MinX, Is.AtLeast(5 - tolerance));
            Assert.That(job.MinX, Is.AtMost(5 + tolerance));
            Assert.That(job.MaxX, Is.AtLeast(25 - tolerance));
            Assert.That(job.MaxX, Is.AtMost(25 + tolerance));
            Assert.That(job.MinY, Is.AtLeast(20 - tolerance));
            Assert.That(job.MinY, Is.AtMost(20 + tolerance));
            Assert.That(job.MaxY, Is.AtLeast(40 - tolerance));
            Assert.That(job.MaxY, Is.AtMost(40 + tolerance));
            Assert.That(job.MinZ, Is.AtLeast(1 - tolerance));
            Assert.That(job.MinZ, Is.AtMost(1 + tolerance));
            Assert.That(job.MaxZ, Is.AtLeast(56 - tolerance));
            Assert.That(job.MaxZ, Is.AtMost(56 + tolerance));

            Assert.That(job.XShift, Is.AtLeast(30 - tolerance));
            Assert.That(job.XShift, Is.AtMost(30 + tolerance));
            Assert.That(job.YShift, Is.AtLeast(15 - tolerance));
            Assert.That(job.YShift, Is.AtMost(15 + tolerance));
            Assert.That(job.ZShift, Is.AtLeast(-1 - tolerance));
            Assert.That(job.ZShift, Is.AtMost(-1 + tolerance));
        }
        [Test]
        // Testing bounds of workspace origin
        public void BoundsOrigin()
        {
            float tolerance = 0.001f;
            Coordinate2D upperleft = new Coordinate2D(10, 10);
            Coordinate2D lowerright = new Coordinate2D(100, 100);
            float height = 100;
            float offset = 10f;
            Workspace workspace = new Workspace(lowerright, upperleft, height, offset);

            Assert.That(workspace.Origin.X, Is.AtLeast(45 - tolerance));
            Assert.That(workspace.Origin.X, Is.AtMost(45 + tolerance));
            Assert.That(workspace.Origin.Y, Is.AtLeast(45 - tolerance));
            Assert.That(workspace.Origin.Y, Is.AtMost(45 + tolerance));
            Assert.That(workspace.Origin.Z, Is.AtLeast(45 - tolerance));
            Assert.That(workspace.Origin.Z, Is.AtMost(45 + tolerance));
        }
        [Test]
        // Testing bounds of workspace low corner 1
        public void BoundsCorner1Low()
        {
            float tolerance = 0.001f;
            Coordinate2D upperleft = new Coordinate2D(10, 10);
            Coordinate2D lowerright = new Coordinate2D(100, 100);
            float height = 100;
            float offset = 10f;
            Workspace workspace = new Workspace(lowerright, upperleft, height, offset);

            Assert.That(workspace.Corner1Low.X, Is.AtLeast(10 - tolerance));
            Assert.That(workspace.Corner1Low.X, Is.AtMost(10 + tolerance));
            Assert.That(workspace.Corner1Low.Y, Is.AtLeast(10 - tolerance));
            Assert.That(workspace.Corner1Low.Y, Is.AtMost(10 + tolerance));
            Assert.That(workspace.Corner1Low.Z, Is.AtLeast(10 - tolerance));
            Assert.That(workspace.Corner1Low.Z, Is.AtMost(10 + tolerance));
        }
        [Test]
        // Testing bounds of workspace high corner 1
        public void BoundsCorner1High()
        {
            float tolerance = 0.001f;
            Coordinate2D upperleft = new Coordinate2D(10, 10);
            Coordinate2D lowerright = new Coordinate2D(100, 100);
            float height = 100;
            float offset = 10f;
            Workspace workspace = new Workspace(lowerright, upperleft, height, offset);

            Assert.That(workspace.Corner1High.X, Is.AtLeast(10 - tolerance));
            Assert.That(workspace.Corner1High.X, Is.AtMost(10 + tolerance));
            Assert.That(workspace.Corner1High.Y, Is.AtLeast(10 - tolerance));
            Assert.That(workspace.Corner1High.Y, Is.AtMost(10 + tolerance));
            Assert.That(workspace.Corner1High.Z, Is.AtLeast(100 - tolerance));
            Assert.That(workspace.Corner1High.Z, Is.AtMost(100 + tolerance));
        }
        [Test]
        // Testing bounds of workspace low corner 2
        public void BoundsCorner2Low()
        {
            float tolerance = 0.001f;
            Coordinate2D upperleft = new Coordinate2D(10, 10);
            Coordinate2D lowerright = new Coordinate2D(100, 100);
            float height = 100;
            float offset = 10f;
            Workspace workspace = new Workspace(lowerright, upperleft, height, offset);

            Assert.That(workspace.Corner2Low.X, Is.AtLeast(10 - tolerance));
            Assert.That(workspace.Corner2Low.X, Is.AtMost(10 + tolerance));
            Assert.That(workspace.Corner2Low.Y, Is.AtLeast(100 - tolerance));
            Assert.That(workspace.Corner2Low.Y, Is.AtMost(100 + tolerance));
            Assert.That(workspace.Corner2Low.Z, Is.AtLeast(10 - tolerance));
            Assert.That(workspace.Corner2Low.Z, Is.AtMost(10 + tolerance));
        }
        [Test]
        // Testing bounds of workspace high corner 2
        public void BoundsCorner2High()
        {
            float tolerance = 0.001f;
            Coordinate2D upperleft = new Coordinate2D(10, 10);
            Coordinate2D lowerright = new Coordinate2D(100, 100);
            float height = 100;
            float offset = 10f;
            Workspace workspace = new Workspace(lowerright, upperleft, height, offset);

            Assert.That(workspace.Corner2High.X, Is.AtLeast(10 - tolerance));
            Assert.That(workspace.Corner2High.X, Is.AtMost(10 + tolerance));
            Assert.That(workspace.Corner2High.Y, Is.AtLeast(100 - tolerance));
            Assert.That(workspace.Corner2High.Y, Is.AtMost(100 + tolerance));
            Assert.That(workspace.Corner2High.Z, Is.AtLeast(100 - tolerance));
            Assert.That(workspace.Corner2High.Z, Is.AtMost(100 + tolerance));
        }
        [Test]
        // Testing bounds of workspace low corner 3
        public void BoundsCorner3Low()
        {
            float tolerance = 0.001f;
            Coordinate2D upperleft = new Coordinate2D(10, 10);
            Coordinate2D lowerright = new Coordinate2D(100, 100);
            float height = 100;
            float offset = 10f;
            Workspace workspace = new Workspace(lowerright, upperleft, height, offset);

            Assert.That(workspace.Corner3Low.X, Is.AtLeast(100 - tolerance));
            Assert.That(workspace.Corner3Low.X, Is.AtMost(100 + tolerance));
            Assert.That(workspace.Corner3Low.Y, Is.AtLeast(100 - tolerance));
            Assert.That(workspace.Corner3Low.Y, Is.AtMost(100 + tolerance));
            Assert.That(workspace.Corner3Low.Z, Is.AtLeast(10 - tolerance));
            Assert.That(workspace.Corner3Low.Z, Is.AtMost(10 + tolerance));
        }
        [Test]
        // Testing bounds of workspace high corner 3
        public void BoundsCorner3High()
        {
            float tolerance = 0.001f;
            Coordinate2D upperleft = new Coordinate2D(10, 10);
            Coordinate2D lowerright = new Coordinate2D(100, 100);
            float height = 100;
            float offset = 10f;
            Workspace workspace = new Workspace(lowerright, upperleft, height, offset);

            Assert.That(workspace.Corner3High.X, Is.AtLeast(100 - tolerance));
            Assert.That(workspace.Corner3High.X, Is.AtMost(100 + tolerance));
            Assert.That(workspace.Corner3High.Y, Is.AtLeast(100 - tolerance));
            Assert.That(workspace.Corner3High.Y, Is.AtMost(100 + tolerance));
            Assert.That(workspace.Corner3High.Z, Is.AtLeast(100 - tolerance));
            Assert.That(workspace.Corner3High.Z, Is.AtMost(100 + tolerance));
        }
        [Test]
        // Testing bounds of workspace low corner 4
        public void BoundsCorner4Low()
        {
            float tolerance = 0.001f;
            Coordinate2D upperleft = new Coordinate2D(10, 10);
            Coordinate2D lowerright = new Coordinate2D(100, 100);
            float height = 100;
            float offset = 10f;
            Workspace workspace = new Workspace(lowerright, upperleft, height, offset);

            Assert.That(workspace.Corner4Low.X, Is.AtLeast(100 - tolerance));
            Assert.That(workspace.Corner4Low.X, Is.AtMost(100 + tolerance));
            Assert.That(workspace.Corner4Low.Y, Is.AtLeast(10 - tolerance));
            Assert.That(workspace.Corner4Low.Y, Is.AtMost(10 + tolerance));
            Assert.That(workspace.Corner4Low.Z, Is.AtLeast(10 - tolerance));
            Assert.That(workspace.Corner4Low.Z, Is.AtMost(10 + tolerance));
        }
        [Test]
        // Testing bounds of workspace high corner 4
        public void BoundsCorner4High()
        {
            float tolerance = 0.001f;
            Coordinate2D upperleft = new Coordinate2D(10, 10);
            Coordinate2D lowerright = new Coordinate2D(100, 100);
            float height = 100;
            float offset = 10f;
            Workspace workspace = new Workspace(lowerright, upperleft, height, offset);

            Assert.That(workspace.Corner4High.X, Is.AtLeast(100 - tolerance));
            Assert.That(workspace.Corner4High.X, Is.AtMost(100 + tolerance));
            Assert.That(workspace.Corner4High.Y, Is.AtLeast(10 - tolerance));
            Assert.That(workspace.Corner4High.Y, Is.AtMost(10 + tolerance));
            Assert.That(workspace.Corner4High.Z, Is.AtLeast(100 - tolerance));
            Assert.That(workspace.Corner4High.Z, Is.AtMost(100 + tolerance));
        }
    }
}
