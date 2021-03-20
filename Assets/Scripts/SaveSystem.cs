using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveData(int _number, int _time, int _highe, int _highm, int _highd, int _higher,
        int _highmr, int _highdr, int _highel, int _highml, int _highdl,
        int _number2, int _time2, int _highe2, int _highm2, int _highd2, int _higher2,
        int _highmr2, int _highdr2, int _highel2, int _highml2, int _highdl2)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        GameData data = new GameData(_number,_time,_highe,_highm,_highd,_higher,_highmr,_highdr,_highel,_highml,_highdl,
        _number2,_time2,_highe2,_highm2,_highd2,_higher2,_highmr2,_highdr2,_highel2,_highml2,_highdl2);
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
            GameData newdata = new GameData(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
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
