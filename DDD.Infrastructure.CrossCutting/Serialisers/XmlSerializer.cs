using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using DDD.Infrastructure.CrossCutting.Abstractions;

namespace DDD.Infrastructure.CrossCutting.Serialisers
{
    public class XmlSerialiser : ISerialiser
    {

        public string Serialise<T>(T input)
        {
            try
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add(string.Empty, string.Empty);

                var serializer = new XmlSerializer(typeof (T));
                var settings = new XmlWriterSettings
                {
                    Encoding = new UnicodeEncoding(false, false),
                    Indent = false,
                    OmitXmlDeclaration = true
                };

                using (var textWriter = new StringWriter())
                {
                    using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                    {
                        serializer.Serialize(xmlWriter, input, ns);
                    }
                    return textWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                //_logger.Error(ex, "Error serializing item to xml");
                throw ex;
            }
        }

        public T Deserialise<T>(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return default(T);

            try
            {
                var serializer = new XmlSerializer(typeof (T));

                return (T) serializer.Deserialize(new StringReader(input));
            }
            catch (Exception ex)
            {
                //_logger.Error(ex, "Error deserialising input. {0}", input);
                throw;
            }
        }

    }
}
