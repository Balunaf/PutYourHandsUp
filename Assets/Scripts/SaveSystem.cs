using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveData(int _number, int _time, int _highe, int _highm, int _highd, int _higher, int _highmr, int _highdr, int _highel, int _highml, int _highdl)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        GameData data = new GameData(_number,_time,_highe,_highm,_highd,_higher,_highmr,_highdr,_highel,_highml,_highdl);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadData()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if (!File.Exists(path))
        {
            BinaryFormatter newformatter = new BinaryFormatter();
            FileStream newstream = new FileStream(path, FileMode.Create);
            GameData newdata = new GameData(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            newformatter.Serialize(newstream, newdata);
            newstream.Close();
        }
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);
        GameData data = formatter.Deserialize(stream) as GameData;
        stream.Close();
        return data;
    }
}
