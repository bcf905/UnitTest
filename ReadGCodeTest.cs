using MotionPlanning.Auxiliary;
using MotionPlanning.Job;
using MotionPlanning.State;
using MotionPlanning.Statements;
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
            Job job = GCode.Read(reader);

            List<string> urscript = job.GetURScript();
            Assert.That(urscript.Count, Is.EqualTo(17));
        }
    }
}
