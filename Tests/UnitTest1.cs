namespace Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using CurseIO;
    using CurseIO.Enum;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int olaBahia;

            var teste = Curse.Clear("olá meu nome é shit e voce poderia fuck", out olaBahia);

        }
    }
}
