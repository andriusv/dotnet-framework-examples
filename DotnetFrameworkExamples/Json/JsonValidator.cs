using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Json
{
    public static class JsonValidator
    {
        public static bool IsValidJson(string s)
        {
            s = s.Trim();
            
            try
            {
                var obj = JToken.Parse(s);
                return true;
            }
            catch (JsonReaderException jrex)
            {
                Console.WriteLine(jrex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }            
            return false;            
        }
    }
}
