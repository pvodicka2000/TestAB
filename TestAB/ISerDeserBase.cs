using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace TestAB
{

    [Serializable()]
    public abstract class ISerDeserBase<T>
    {

        public T Clone()
        {
            return (T)this.MemberwiseClone(); // Shallow copy
        }

        public T DeepCopy()
        {
            // Deep Copy
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Seek(0, SeekOrigin.Begin);
            T copy = (T)formatter.Deserialize(stream);
            stream.Close();
            return copy;
        }

        #region Serialize/Deserialize This - Binary
        public void SerializeThis(string fileName)
        {
            // Save object to a file named CarData.dat in binary.
            BinaryFormatter binFormat = new BinaryFormatter();
            using (FileStream fStream = new FileStream(fileName,
                                                   FileMode.Create,
                                                   FileAccess.Write,
                                                   FileShare.None))
            {
                binFormat.Serialize(fStream, this);
            }
        }

        public static ISerDeserBase<T> DeserializeThis(string fileName)
        {
            ISerDeserBase<T> result = null;
            BinaryFormatter binFormat = new BinaryFormatter();
            // Read the JamesBondCar from the binary file.
            using (Stream fStream = File.OpenRead(fileName))
            {
                result = (ISerDeserBase<T>)binFormat.Deserialize(fStream);
            }

            return result;
        }
        #endregion

        #region Serialize/Deserialize This - SOAP
        public void SerializeThisSoap(string fileName)
        {
            // Save object to a file named CarData.dat in binary.
            SoapFormatter soapFormat = new SoapFormatter();
            using (Stream fStream = new FileStream(fileName,
                                                   FileMode.Create,
                                                   FileAccess.Write,
                                                   FileShare.None))
            {
                soapFormat.Serialize(fStream, this);
            }
        }

        public static ISerDeserBase<T> DeserializeThisSoap(string fileName)
        {
            ISerDeserBase<T> result = null;
            SoapFormatter soapFormat = new SoapFormatter();
            // Read the JamesBondCar from the binary file.
            using (Stream fStream = File.OpenRead(fileName))
            {
                result = (ISerDeserBase<T>)soapFormat.Deserialize(fStream);
            }

            return result;
        }
        #endregion

        #region Serialize/Deserialize Object - Binary
        public static void SerializeObjectBin(object objGraph, string fileName)
        {
            // Save object to a file named CarData.dat in binary.
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, objGraph);
            }
        }

        public static object DeserializeObjectBin(string fileName)
        {
            object result = null;
            BinaryFormatter binFormat = new BinaryFormatter();
            // Read the JamesBondCar from the binary file.
            using (Stream fStream = File.OpenRead(fileName))
            {
                result = binFormat.Deserialize(fStream);
            }

            return result;
        }
        #endregion

        #region Serialize/Deserialize Object - SOAP
        public static void SerializeObjectSoap(object objGraph, string fileName)
        {
            // Save object to a file named CarData.dat in binary.
            SoapFormatter binFormat = new SoapFormatter();
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, objGraph);
            }
        }

        public static object DeserializeObjectSoap(string fileName)
        {
            object result = null;
            SoapFormatter binFormat = new SoapFormatter();
            // Read the JamesBondCar from the binary file.
            using (Stream fStream = File.OpenRead(fileName))
            {
                result = binFormat.Deserialize(fStream);
            }

            return result;
        }
        #endregion

    }

}
