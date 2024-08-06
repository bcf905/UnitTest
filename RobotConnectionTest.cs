using MotionPlanning.State;
using MotionPlanning.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotionPlanning.Auxiliary;

namespace UnitTest
{
    public class RobotConnectionTest
    {
        [Test]
        // Testing Connection
        public void ConnectionTest()
        {
            string result = RobotConnection.TestConnection();
            Assert.That(result, Is.EqualTo("Message send!"));
        }
        [Test]
        // Test of sending a script
        public void ScriptTest()
        {
            string ip = "192.168.56.101";
            string script = "def test_move():\n" +
                "   global P_start_p=p[.6206, -.1497, .2609, 2.2919, -2.1463, -.0555]\n" +
                "   global P_mid_p=p[.6206, -.1497, .3721, 2.2919, -2.1463, -.0555]\n" +
                "   global P_end_p=p[.6206, -.1497, .4658, 2.2919, -2.1463, -.0555]\n" +
                "   while (True):\n" +
                "      movel(P_start_p, a=1.2, v=0.25)\n" +
                "      movel(P_mid_p, a=1.2, v=0.25)\n" +
                "      movel(P_end_p, a=1.2, v=0.25)\n" +
                "   end\n" +
                "end\n";

            string result = RobotConnection.SendMessage(ip, script);
            //Assert.That(result, Is.EqualTo("Send: power on\nMessage send!\nSend: power off\n"));
            Assert.That(result, Is.EqualTo("Message send!"));
        }
    }
}
