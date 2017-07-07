using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Json;

namespace JsonTests
{
    [TestClass]
    public class JsonValidatorTests
    {
        static string _jsonObj = "{\"name\":\"test\"}";
        static string _jsonArr = "[{\"name\":\"test\"}]";

        #region Json as object

        [TestMethod]
        public void ShouldPass_IfValidJson()
        {            
            Assert.IsTrue(JsonValidator.IsValidJson(_jsonObj));
        }

        [TestMethod]
        public void ShouldNotPass_IfJsonStringHasNoBeginningTag()
        {
            string _jsonNotValid = _jsonObj.Remove(0, 1);
            Assert.IsFalse(JsonValidator.IsValidJson(_jsonNotValid));
        }

        [TestMethod]
        public void ShouldNotPass_IfJsonStringBeginsWith2Tags()
        {
            string _jsonNotValid = "{" + _jsonObj;
            Assert.IsFalse(JsonValidator.IsValidJson(_jsonNotValid));
        }

        [TestMethod]
        public void ShouldNotPass_IfJsonStringEndsWith2Tags()
        {
            string _jsonNotValid = _jsonObj + "{";
            Assert.IsFalse(JsonValidator.IsValidJson(_jsonNotValid));
        }

        [TestMethod]
        public void ShouldNotPass_IfJsonStringEndsWithNoTag()
        {
            string _jsonNotValid = _jsonObj.Substring(_jsonObj.Length - 1);
            Assert.IsFalse(JsonValidator.IsValidJson(_jsonNotValid));
        }        

        #endregion

        #region Json as array
        [TestMethod]
        public void ShouldPass_IfValidJsonArray()
        {
            Assert.IsTrue(JsonValidator.IsValidJson(_jsonArr));
        }

        [TestMethod]
        public void ShouldNotPass_IfJsonArrayStringHasNoBeginningTag()
        {
            string _jsonNotValid = _jsonArr.Remove(0, 1);
            Assert.IsFalse(JsonValidator.IsValidJson(_jsonNotValid));
        }

        [TestMethod]
        public void ShouldNotPass_IfJsonArrayStringBeginsWith2Tags()
        {
            string _jsonNotValid = "{" + _jsonArr;
            Assert.IsFalse(JsonValidator.IsValidJson(_jsonNotValid));
        }

        [TestMethod]
        public void ShouldNotPass_IfJsonArrayStringEndsWith2Tags()
        {
            string _jsonNotValid = _jsonArr + "{";
            Assert.IsFalse(JsonValidator.IsValidJson(_jsonNotValid));
        }

        [TestMethod]
        public void ShouldNotPass_IfJsonArrayStringEndsWithNoTag()
        {
            string _jsonNotValid = _jsonArr.Substring(_jsonArr.Length - 1);
            Assert.IsFalse(JsonValidator.IsValidJson(_jsonNotValid));
        }

        #endregion

        #region Json is Null or Whitespace

        [TestMethod]
        public void ShouldNotPass_IfJsonStringIsNull()
        {
            Assert.IsFalse(JsonValidator.IsValidJson(null));
        }

        [TestMethod]
        public void ShouldNotPass_IfJsonStringIsEmpty()
        {
            Assert.IsFalse(JsonValidator.IsValidJson(""));
        }

        [TestMethod]
        public void ShouldNotPass_IfJsonStringIsWhitespace()
        {
            Assert.IsFalse(JsonValidator.IsValidJson(" "));
        }

        #endregion
    }
}
