using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public static class SaveLoad 
{

	public static void Save(SaveGame save)
	{
		BinaryFormatter bf = new BinaryFormatter();
		//surrogate serializer setup.
		SurrogateSelector ss = new SurrogateSelector();
		ColorSerializationSurrogate css = new ColorSerializationSurrogate();
		ss.AddSurrogate(typeof(Color),new StreamingContext(StreamingContextStates.All),css);
		//use surrogate selector.
		bf.SurrogateSelector = ss;

		FileStream file = File.Create(Application.persistentDataPath+"/saveGame.serious");
		bf.Serialize(file, save);

		file.Close ();
		Debug.Log(Application.persistentDataPath+"/saveGame.serious");
	}

	public static SaveGame Load()
	{
		BinaryFormatter bf = new BinaryFormatter();
		//surrogate serializer setup.
		SurrogateSelector ss = new SurrogateSelector();
		ColorSerializationSurrogate css = new ColorSerializationSurrogate();
		ss.AddSurrogate(typeof(Color),new StreamingContext(StreamingContextStates.All),css);
		//use surrogate selector.
		bf.SurrogateSelector = ss;
		FileStream file = File.Open(Application.persistentDataPath+"/saveGame.serious",FileMode.Open);
		SaveGame loadedGame = (SaveGame)bf.Deserialize(file);
		file.Close();
		return loadedGame;
	}
}
