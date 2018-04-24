/* ***********************************************
 * Author : Kevin
 * Function : 
 * Created : 2017/11/18 19:28:02
 * ***********************************************/
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace System
{
    /// <summary>
    /// 
    /// </summary>
    public static class SerializationExtensions
    {
        /// <summary>
        /// Serializes the specified instance to XML using the
        /// <see cref="XmlSerializer"/>
        /// </summary>
        /// <typeparam name="T">Type to be serialized</typeparam>
        /// <param name="instance">Instance to be serialized</param>
        /// <returns>XML string</returns>
        public static string Serialize<T>(this T instance)
        {
            if (instance == null)
                throw new ArgumentNullException("instance");

            StringBuilder builder = new StringBuilder();

            using (var xmlWriter = XmlWriter.Create(builder))
            using (var writer = XmlDictionaryWriter.CreateDictionaryWriter(xmlWriter))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, instance);
            }

            return builder.ToString();
        }

        /// <summary>
        /// Serializes the specified instance to Stream using the <see cref="XmlSerializer"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="stream"></param>
        public static void FromObjectToStream<T>(this T instance, Stream stream)
        {
            if (!instance.IsXmlSerializable()) throw new Exception("instance unserialized");
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(stream, instance);
        }

        /// <summary>
        /// Deserializes the specified XML string to the specified type
        /// </summary>
        /// <typeparam name="T">Type to deserialize to</typeparam>
        /// <param name="xml">XML</param>
        /// <returns>Instance of the specified type</returns>
        public static T Deserialize<T>(this string xml)
        {
            if (string.IsNullOrEmpty(xml))
                throw new ArgumentNullException("xml");

            T instance;

            using (XmlReader xmlReader = XmlReader.Create(new StringReader(xml)))
            using (XmlDictionaryReader reader = XmlDictionaryReader.CreateDictionaryReader(xmlReader))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                instance = (T)serializer.Deserialize(reader);
            }

            return instance;
        }

        /// <summary>
        /// Deserializes the specified Stream to the specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static T FromStreamToObject<T>(this Stream stream)
        {
            if (!typeof(T).IsSerializable) throw new Exception("instance unserialized");
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(stream);
        }

        /// <summary>
        /// Determines if the instance is XML serializable
        /// </summary>
        /// <param name="check">Object to be checked</param>
        /// <returns>True if the object type supports XML serialization</returns>
        public static bool IsXmlSerializable(this object check)
        {
            if (check == null)
                throw new ArgumentNullException("check");

            Type checkType = check.GetType();

            return checkType.IsSerializable;
        }

        /// <summary>
        /// Serializes and deserializes an instance using Xml
        /// serialization to test instance serialization. Useful
        /// for ensuring classes are correctly marked up to be
        /// serialized
        /// </summary>
        /// <typeparam name="T">Instance type</typeparam>
        /// <param name="instance">Instance</param>
        /// <returns>New instance after serialization / deserialization</returns>
        public static T XmlRoundtripSerialize<T>(T instance) where T : class, new()
        {
            if (instance == null)
                throw new ArgumentNullException("instance");

            string xml = Serialize<T>(instance);

            T readbackInstance = Deserialize<T>(xml);

            return readbackInstance;
        }

    }
}
