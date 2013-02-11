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
            CodeMachine machine = CodeMachine.Generate("AAAA");
            Assert.IsNotNull(machine.Decode(""));
        }

        [TestMethod]
        public void CorrectCodeShouldHaveACorrectAnswer()
        {
            CodeMachine machine = CodeMachine.Generate("AAAA");
            Assert.AreEqual(machine.Decode("AAAA"), "XXXX");
        }

        [TestMethod]
        public void AlmostCorrectCodeShouldHaveAnAlmostCorrectAnswer()
        {
            CodeMachine machine = CodeMachine.Generate("AAAA");
            Assert.AreEqual(machine.Decode("AABA"), "XXX");
            Assert.AreEqual(machine.Decode("AAAB"), "XXX");
            Assert.AreEqual(machine.Decode("ABAA"), "XXX");
            Assert.AreEqual(machine.Decode("BAAA"), "XXX");
        }

        [TestMethod]
        public void UnorderedCodeShouldHaveXMarks()
        {
            CodeMachine machine = CodeMachine.Generate("ARMV");
            Assert.AreEqual(machine.Decode("VMRA"), "****");
            Assert.AreEqual(machine.Decode("RMV"), "***");
        }

        [TestMethod]
        [ExpectedException(typeof(WrongSizedPasswordException))]
        public void PasswordShouldHaveNoMoreThanFourCharacters()
        {
            CodeMachine machine = CodeMachine.Generate("KKKKK");
            Assert.IsNull(machine);
        }

        [TestMethod]
        [ExpectedException(typeof(IncorrectCharactersException))]
        public void PasswordShouldBeInsideRange() 
        {
            CodeMachine machine = CodeMachine.Generate("KKKK");
        }
    }
}
