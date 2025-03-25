using System.IO;
using System.Xml.Linq;

namespace GroupDocs.Parser.Explorer.XmlStorage
{
    class XmlDocumentReader
    {
        private readonly XDocument _document;

        public XmlDocumentReader(string fileName)
        {
            _document = XDocument.Load(fileName);
        }

        public XmlDocumentReader(Stream stream)
        {
            _document = XDocument.Load(stream);
        }

        public XmlReader GetRootReader(string elementName)
        {
            var childElement = _document.Element(elementName);
            return new XmlReader(childElement);
        }
    }
}
