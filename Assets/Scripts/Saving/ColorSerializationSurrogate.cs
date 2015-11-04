using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;

sealed class ColorSerializationSurrogate : ISerializationSurrogate
{
	// Method called to serialize a Vector3 object
	public void GetObjectData(System.Object obj, SerializationInfo info, StreamingContext context) 
	{
		Color c = (Color) obj;
		info.AddValue("r", c.r);
		info.AddValue("g", c.g);
		info.AddValue("b", c.b);
	}
	
	// Method called to deserialize a Vector3 object
	public System.Object SetObjectData(System.Object obj,SerializationInfo info, StreamingContext context, ISurrogateSelector selector) 
	{
		Color c = (Color) obj;
		c.r = (float)info.GetValue("r", typeof(float));
		c.g = (float)info.GetValue("g", typeof(float));
		c.b = (float)info.GetValue("b", typeof(float));
		obj = c;
		return obj;   // Formatters ignore this return value //Seems to have been fixed!
	}

}
