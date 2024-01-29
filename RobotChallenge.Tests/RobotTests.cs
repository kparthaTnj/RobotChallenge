using Moq;
using System.Windows.Input;
using Service;
using Service.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Robot.Tests;

namespace Robot.Tests
{
    public class RobotTests
    {
        ISimulator simulator; Invoker invoker;
        [SetUp]
        public void Setup()
        {
            simulator = Utility.GetRequiredService<ISimulator>();
            invoker = Utility.GetRequiredService<Invoker>();
        }

        [Test]
        public void Test1()
        {                   
            var result  = invoker.ProcessCommand(new string[] { "PLACE 0,0,NORTH", "MOVE", "REPORT" }); 
            Assert.That(result, Is.EqualTo("0,1,NORTH"));
        }

        [Test]
        public void Test2()
        {
            var result = invoker.ProcessCommand(new string[] { "PLACE 0,0,NORTH", "LEFT", "REPORT" });
            Assert.That(result, Is.EqualTo("0,0,WEST"));
        }       

        [Test]
        public void Test3()
        {
            var result = invoker.ProcessCommand(new string[] { "PLACE 1,2,EAST", "MOVE","MOVE","LEFT","MOVE", "REPORT" });
            Assert.That(result, Is.EqualTo("3,3,NORTH"));
        }

        [Test]
        public void Test4()
        {
            var result = invoker.ProcessCommand(new string[] { "PLACE 1,1,WEST", "MOVE", "MOVE", "LEFT", "MOVE", "REPORT" });
            Assert.That(result, Is.EqualTo("0,0,SOUTH"));
        }

        [Test]
        public void Test5()
        {
            var result = invoker.ProcessCommand(new string[] { "PLACE 0,0,SOUTH", "LEFT","MOVE", "REPORT" });
            Assert.That(result, Is.EqualTo("1,0,EAST"));
        }

        [Test]
        public void NegativeTest()
        {
            var result = invoker.ProcessCommand(new string[] { "PLACE 0,5,NORTH", "MOVE", "REPORT" });
            Assert.AreEqual(result, "Please verify the commands/inputs and log file for more informations");
        }
    }
}