using System.IO;
using System.Xml.Serialization;

public class SerializerXML
{
    public static void Serialize(object _item, System.String _path)
    {
        // Create a new XMLserializer with the given object
        XmlSerializer serializer = new XmlSerializer(_item.GetType());
        // Create a new stream writer at the given path
        StreamWriter writer = new StreamWriter(_path);
        // Serialize the object on a new file created on this path
        serializer.Serialize(writer.BaseStream, _item);
        // Close the file and the writer
        writer.Close();
    }
}
