using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _12Enero_CodeBreaker;

namespace Tests
{
    [TestClass]
    public class CodeMachineTester
    {
        [TestMethod]
        public void BasicReturnShouldBeAValidString()
        {
            CodeMachine machine = new CodeMachine(string.Empty);
            Assert.IsNotNull(machine.Decode(""));
        }

        [TestMethod]
        public void CorrectCodeShouldHaveACorrectAnswer()
        {
            CodeMachine machine = new CodeMachine("AAAA");
            Assert.AreEqual(machine.Decode("AAAA"), "XXXX");
        }

        [TestMethod]
        public void AlmostCorrectCodeShouldHaveAnAlmostCorrectAnswer()
        {
            CodeMachine machine = new CodeMachine("AAAA");
            Assert.AreEqual(machine.Decode("AABA"), "XXX");
            Assert.AreEqual(machine.Decode("AAAB"), "XXX");
            Assert.AreEqual(machine.Decode("ABAA"), "XXX");
            Assert.AreEqual(machine.Decode("BAAA"), "XXX");
        }

        [TestMethod]
        public void UnorderedCodeShouldHaveXMarks()
        {
            CodeMachine machine = new CodeMachine("ABCD");
            Assert.AreEqual(machine.Decode("BCDA"), "****");
            Assert.AreEqual(machine.Decode("BCD"), "***");
        }

        [TestMethod]
        public void PasswordShouldHaveNoMoreThanFourCharacters()
        {
            CodeMachine machine = new CodeMachine("KKKK");
        }
    }
}
