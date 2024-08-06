using MotionPlanning.Auxiliary;
using MotionPlanning.Job;
using MotionPlanning.State;
using MotionPlanning.Statements;
using MotionPlanning.Coordinates;
using MotionPlanning.Workspace;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class ReadGCodeTest
    {
        [Test]
        // Testing reading testfile.gcode and identifying statements
        public void ReadTestFile()
        {
            string fileLocation = Path.Combine(Environment.CurrentDirectory, "testfile.gcode");
            StreamReader reader = new StreamReader(fileLocation);
            Coordinate2D coord1 = new(10f,10f);
            Coordinate2D coord2 = new(100f,100f);
            Workspace workspace = new(coord1, coord2, 100, 10);
            Job job = GCode.Read(reader, workspace);

            List<string> urscript = job.GetURScript();
            Assert.That(urscript.Count, Is.EqualTo(17));
        }
    }
}
