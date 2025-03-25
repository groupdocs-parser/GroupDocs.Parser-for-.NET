using System.IO;
using System.Xml.Linq;

namespace GroupDocs.Parser.Explorer.XmlStorage
{
    class XmlDocumentWriter
    {
        private readonly XDocument _document;

        public XmlDocumentWriter()
        {
            _document = new XDocument();
        }

        public XmlWriter CreateRootWriter(string elementName)
        {
            var childElement = new XElement(elementName);
            _document.Add(childElement);
            return new XmlWriter(childElement);
        }

        public void Save(string fileName)
        {
            _document.Save(fileName);
        }

        public void Save(Stream stream)
        {
            _document.Save(stream);
        }
    }
}
