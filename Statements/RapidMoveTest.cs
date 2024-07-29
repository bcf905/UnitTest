﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotionPlanning.Statements;
using MotionPlanning.State;
using MotionPlanning.Auxiliary;

namespace UnitTest.Statements
{
    public class RapidMoveTest
    {
        [Test]
        // Testing identification
        public void Identification()
        {
            string gcode = "G0 X141.379 Y84.536 E324.40933";
            IURScript statement = Identifier.Identify(gcode);
            Assert.That(statement.GetType(), Is.EqualTo(typeof(RapidMove)));
        }
        [Test]
        // Testing a valid statement
        public void ValidStatement()
        {
            float tolerance = 0.00001f;
            string gcode = "G0 X141.379 Y84.536 E324.40933";
            RapidMove stm = new RapidMove(gcode);
            State st = new State();
            Assert.That(stm.Valid, Is.True);
            Assert.That(stm.CommandType, Is.EqualTo('G'));
            Assert.That(stm.CommandNumber, Is.EqualTo(0));
            Assert.That(stm.X, Is.AtLeast(141.379 - tolerance));
            Assert.That(stm.X, Is.AtMost(141.379 + tolerance));
            Assert.That(stm.Y, Is.AtLeast(84.536 - tolerance));
            Assert.That(stm.Y, Is.AtMost(84.536 + tolerance));
            Assert.That(stm.Z, Is.AtLeast(0.0 - tolerance));
            Assert.That(stm.Z, Is.AtMost(0.0 + tolerance));
            Assert.That(stm.URScript(st), Is.EqualTo("Rapid Move - X:141.379, Y:84.536, Z:0.000"));
            Assert.That(st.X, Is.AtLeast(141.379 - tolerance));
            Assert.That(st.X, Is.AtMost(141.379 + tolerance));
            Assert.That(st.Y, Is.AtLeast(84.536 - tolerance));
            Assert.That(st.Y, Is.AtMost(84.536 + tolerance));
            Assert.That(st.Z, Is.AtLeast(0.0 - tolerance));
            Assert.That(st.Z, Is.AtMost(0.0 + tolerance));
        }
    }
}
