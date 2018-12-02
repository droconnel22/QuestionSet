namespace AP_QuestionSet_CSharp.Core.QuestionThree
{
    using Newtonsoft.Json;    
    using System;
    using System.Collections.Generic;    
    using System.Linq;

    public class JsonMapper
    {
        public static string Map(string schema, string Json)
        {
            if (string.IsNullOrEmpty(schema) || string.IsNullOrEmpty(Json))
                throw new ArgumentNullException(nameof(schema));

            dynamic jsonValuesObj = JsonConvert.DeserializeObject<dynamic>(Json);
            Dictionary<string, string> jsonScheamDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(schema);
            Dictionary<string, object> jsonResultDict = new Dictionary<string, object>();                   

            foreach (var property in jsonScheamDict)
            {
                // light recursive depth first search approach
                Queue<string> path = new Queue<string>(property.Value.Split('.').ToList());                
                var currentElem = jsonValuesObj[path.Dequeue()];
                while(currentElem != null && path.Any())
                {
                    try
                    {
                        currentElem = currentElem[path.Dequeue()];
                    }
                    catch (Exception exception)
                    {
                        // if path is not specified this will fail.
                        //Could raise exception. I.e. -> throw new ArgumentOutOfRangeException(exception.Message +  " CurrentItem does not exist in path specified");
                        currentElem = null;
                    }                   
                }

                jsonResultDict[property.Key] = currentElem?.Value;
            }

            return JsonConvert.SerializeObject(jsonResultDict).Replace("\r\n", string.Empty).Replace(" ", string.Empty);
        }
    }
}