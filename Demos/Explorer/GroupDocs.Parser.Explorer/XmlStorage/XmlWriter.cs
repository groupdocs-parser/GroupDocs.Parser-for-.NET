using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;

namespace GroupDocs.Parser.Explorer.XmlStorage
{
    class XmlWriter
    {
        private readonly XElement _element;

        public XmlWriter(XElement element)
        {
            _element = element;
        }

        public XmlWriter CreateChildWriter(string elementName)
        {
            var childElement = new XElement(elementName);
            _element.Add(childElement);
            return new XmlWriter(childElement);
        }

        public void WriteCollection(string collectionName, string elementName, IEnumerable<int> values)
        {
            var collectionElement = new XElement(collectionName);
            foreach (int value in values)
            {
                var childElement = new XElement(elementName);
                childElement.Value = value.ToString(CultureInfo.InvariantCulture);
                collectionElement.Add(childElement);
            }
            _element.Add(collectionElement);
        }

        public void WriteCollection<TEnum>(string collectionName, string elementName, IEnumerable<TEnum> values)
        {
            var collectionElement = new XElement(collectionName);
            foreach (TEnum value in values)
            {
                var childElement = new XElement(elementName);
                childElement.Value = value.ToString();
                collectionElement.Add(childElement);
            }
            _element.Add(collectionElement);
        }

        public void Write(string elementName, string value)
        {
            var childElement = new XElement(elementName);
            childElement.Value = value == null ? string.Empty : value;
            _element.Add(childElement);
        }

        public void Write(string elementName, double value)
        {
            var childElement = new XElement(elementName);
            childElement.Value = value.ToString(CultureInfo.InvariantCulture);
            _element.Add(childElement);
        }

        public void WriteAttribute(string elementName, double value)
        {
            var childElement = new XAttribute(elementName, value.ToString(CultureInfo.InvariantCulture));
            _element.Add(childElement);
        }

        public void Write(string elementName, int value)
        {
            var childElement = new XElement(elementName);
            childElement.Value = value.ToString(CultureInfo.InvariantCulture);
            _element.Add(childElement);
        }

        public void WriteAttribute(string elementName, int value)
        {
            var childElement = new XAttribute(elementName, value.ToString(CultureInfo.InvariantCulture));
            _element.Add(childElement);
        }

        public void Write(string elementName, long value)
        {
            var childElement = new XElement(elementName);
            childElement.Value = value.ToString(CultureInfo.InvariantCulture);
            _element.Add(childElement);
        }

        public void Write(string elementName, byte[] value)
        {
            var childElement = new XElement(elementName);
            childElement.Value = Convert.ToBase64String(value, Base64FormattingOptions.None);
            _element.Add(childElement);
        }

        public void Write(string elementName, Enum value)
        {
            var childElement = new XElement(elementName);
            childElement.Value = value.ToString();
            _element.Add(childElement);
        }

        public void WriteAttribute(string elementName, Enum value)
        {
            var childElement = new XAttribute(elementName, value.ToString());
            _element.Add(childElement);
        }
    }
}
