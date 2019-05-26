using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TastkManager.Tests
{
    public static class TestExtensions
    {

        public static void GreaterThan(this Assert assert, int expected, int actual)
        {
            if (actual > expected)
                return;

            throw new AssertFailedException($@"Value not greater than expected. 
Expected: over <{expected}>
Actual: <{actual}>");
        }

    }
}
