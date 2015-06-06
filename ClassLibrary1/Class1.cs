using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestTask;

namespace ClassLibrary1
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test1()
        {
            FileClass f = new FileClass();
            Assert.AreEqual(f.Filepath, null);
            Assert.AreEqual(f.Dictionarypath, null);
            Assert.AreEqual(f.N, 100000);
        }
        [Test]
        public void Test2()
        {
            FileClass f = new FileClass();
            f.Filepath = @"C:\Users\Елизавета\Documents\Файлы - примеры\1txtfile.txt";
            f.Dictionarypath = @"C:\Users\Елизавета\Documents\Файлы - примеры\2txtfile.txt";
            Assert.AreNotEqual(f.Filepath, f.Dictionarypath);
            f.ProcessFiles();
        }
    }
}
