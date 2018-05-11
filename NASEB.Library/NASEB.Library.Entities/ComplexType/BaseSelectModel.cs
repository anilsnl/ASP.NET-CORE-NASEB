using System;

namespace NASEB.Library.Entities.ComplexType
{
    public class BaseSelectModel
    {
        public String Key { get; set; }
        public string Value { get; set; }

        public BaseSelectModel()
        {
            
        }

        public BaseSelectModel(string key,string value)
        {
            Key = key;
            Value = value;
        }

    }
}
