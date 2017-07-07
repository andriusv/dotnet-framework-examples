using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Json;

namespace JsonTests
{
    [TestClass]
    public class JsonValidatorTests
    {
        static string _json = "{\"name\":\"test\"}";        

        [TestMethod]
        public void ShouldPass_IfValidJson()
        {            
            Assert.IsTrue(JsonValidator.IsValidJson(_json));
        }

        [TestMethod]
        public void ShouldNotPass_IfJsonStringHasNoBeginningTag()
        {
            string _jsonNotValid = _json.Remove(0, 1);
            Assert.IsFalse(JsonValidator.IsValidJson(_jsonNotValid));
        }

        [TestMethod]
        public void ShouldNotPass_IfJsonStringBeginsWith2Tags()
        {
            string _jsonNotValid = "{" + _json;
            Assert.IsFalse(JsonValidator.IsValidJson(_jsonNotValid));
        }

        [TestMethod]
        public void ShouldNotPass_IfJsonStringEndsWith2Tags()
        {
            string _jsonNotValid = _json + "{";
            Assert.IsFalse(JsonValidator.IsValidJson(_jsonNotValid));
        }

        [TestMethod]
        public void ShouldNotPass_IfJsonStringEndsWithNoTag()
        {
            string _jsonNotValid = _json.Substring(_json.Length - 1);
            Assert.IsFalse(JsonValidator.IsValidJson(_jsonNotValid));
        }
    }
}
