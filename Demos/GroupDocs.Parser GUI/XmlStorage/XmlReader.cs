using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace GroupDocs.Parser.Gui.XmlStorage
{
    class XmlReader
    {
        private readonly XElement _element;

        public XmlReader(XElement element)
        {
            _element = element;
        }

        public string Name => _element.Name.LocalName;

        public string Value => _element.Value;

        public IEnumerable<XmlReader> GetChildReaders()
        {
            var childReaders = _element.Elements().Select(childElement => new XmlReader(childElement));
            return childReaders;
        }

        public IEnumerable<XmlReader> GetChildReaders(string name)
        {
            var childReaders = _element.Elements(name).Select(childElement => new XmlReader(childElement));
            return childReaders;
        }

        public XmlReader GetChildReader(string elementName)
        {
            var childElement = _element.Element(elementName);
            if (childElement == null)
            {
                return null;
            }
            return new XmlReader(childElement);
        }

        public IEnumerable<string> ReadCollection(string collectionName, string elementName, string defaultValue)
        {
            var collection = _element
                .Element(collectionName);
            if (collection == null) throw new ArgumentException("Collection is not found", nameof(collectionName));
            return collection
                .Elements(elementName)
                .Select(childElement => childElement.Value);
        }

        public IEnumerable<int> ReadCollection(string collectionName, string elementName, int defaultValue)
        {
            var collection = _element
                .Element(collectionName);
            if (collection == null) throw new ArgumentException("Collection is not found", nameof(collectionName));
            return collection
                .Elements(elementName)
                .Select(childElement =>
                {
                    if (int.TryParse(childElement.Value, out int result))
                    {
                        return result;
                    }
                    else
                    {
                        return defaultValue;
                    }
                });
        }

        public IEnumerable<TEnum> ReadEnumCollection<TEnum>(string collectionName, string elementName, TEnum defaultValue)
            where TEnum : struct
        {
            var collection = _element
                .Element(collectionName);
            if (collection == null) throw new ArgumentException("Collection is not found", nameof(collectionName));
            return collection
                .Elements(elementName)
                .Select(childElement =>
                {
                    if (Enum.TryParse(childElement.Value, out TEnum result))
                    {
                        return result;
                    }
                    else
                    {
                        return defaultValue;
                    }
                });
        }

        public string Read(string elementName, string defaultValue)
        {
            var childElement = _element.Element(elementName);
            if (childElement != null)
            {
                return childElement.Value;
            }

            return defaultValue;
        }

        public double Read(string elementName, double defaultValue)
        {
            var childElement = _element.Element(elementName);
            if (childElement != null &&
                double.TryParse(childElement.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
            {
                return value;
            }

            return defaultValue;
        }

        public double ReadAttribute(string elementName, double defaultValue)
        {
            var childElement = _element.Attribute(elementName);
            if (childElement != null &&
                double.TryParse(childElement.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
            {
                return value;
            }

            return defaultValue;
        }

        public int Read(string elementName, int defaultValue)
        {
            var childElement = _element.Element(elementName);
            if (childElement != null &&
                int.TryParse(childElement.Value, NumberStyles.Integer, CultureInfo.InvariantCulture, out int value))
            {
                return value;
            }

            return defaultValue;
        }

        public int ReadAttribute(string elementName, int defaultValue)
        {
            var childElement = _element.Attribute(elementName);
            if (childElement != null &&
                int.TryParse(childElement.Value, NumberStyles.Integer, CultureInfo.InvariantCulture, out int value))
            {
                return value;
            }

            return defaultValue;
        }

        public long Read(string elementName, long defaultValue)
        {
            var childElement = _element.Element(elementName);
            if (childElement != null &&
                long.TryParse(childElement.Value, NumberStyles.Integer, CultureInfo.InvariantCulture, out long value))
            {
                return value;
            }

            return defaultValue;
        }

        public byte[] Read(string elementName, byte[] defaultValue)
        {
            var childElement = _element.Element(elementName);
            if (childElement != null)
            {
                var value = Convert.FromBase64String(childElement.Value);
                return value;
            }

            return defaultValue;
        }

        public TEnum ReadEnum<TEnum>(string elementName, TEnum defaultValue) where TEnum : struct
        {
            var childElement = _element.Element(elementName);
            if (childElement != null &&
                Enum.TryParse(childElement.Value, out TEnum value))
            {
                return value;
            }

            return defaultValue;
        }

        public TEnum ReadEnumAttribute<TEnum>(string elementName, TEnum defaultValue) where TEnum : struct
        {
            var childElement = _element.Attribute(elementName);
            if (childElement != null &&
                Enum.TryParse(childElement.Value, out TEnum value))
            {
                return value;
            }

            return defaultValue;
        }
    }
}
