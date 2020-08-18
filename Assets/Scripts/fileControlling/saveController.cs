using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class saveController
{
    public static void saveStatus(currentStatus cs)
    {
        BinaryFormatter formatter=new BinaryFormatter();
		string path=Application.persistentDataPath+"/save.pong";
		FileStream stream=new FileStream(path,FileMode.Create);

		formatter.Serialize(stream,cs);
		stream.Close();
    }
    public static currentStatus loadStatus()
    {
        
		BinaryFormatter formatter=new BinaryFormatter();
		string path=Application.persistentDataPath+"/save.pong";
		FileStream stream=new FileStream(path,FileMode.Open);
		
		currentStatus cs= formatter.Deserialize(stream) as currentStatus;
		stream.Close();
		
        return cs;
    }
	 public static void saveHelpStatus(HelpStatus hs)
    {
        BinaryFormatter formatter=new BinaryFormatter();
		string path=Application.persistentDataPath+"/help.pong";
		FileStream stream=new FileStream(path,FileMode.Create);

		

		formatter.Serialize(stream,hs);
		stream.Close();
    }
	public static bool helpExists()
	{
		string path=Application.persistentDataPath+"/help.pong";
        bool firstTime=File.Exists(path);
		Debug.Log(path);
		return firstTime;

	}
	public static bool currentStatusExists()
	{
		string path=Application.persistentDataPath+"/save.pong";
        bool firstTime=File.Exists(path);
		Debug.Log(path);
		return firstTime;

	}
	public static bool settingStatusExists()
	{
		string path=Application.persistentDataPath+"/setting.pong";
        bool firstTime=File.Exists(path);
		Debug.Log(path);
		return firstTime;
	}

	public static void saveSetting(settingStatus ss)
    {
        BinaryFormatter formatter=new BinaryFormatter();
		string path=Application.persistentDataPath+"/setting.pong";
		FileStream stream=new FileStream(path,FileMode.Create);

		formatter.Serialize(stream,ss);
		stream.Close();
    }
    public static settingStatus loadSetting()
    {
		BinaryFormatter formatter=new BinaryFormatter();
		string path=Application.persistentDataPath+"/setting.pong";
		FileStream stream=new FileStream(path,FileMode.Open);
		
		settingStatus ss= formatter.Deserialize(stream) as settingStatus;
		stream.Close();
		
        return ss;
    }
}
