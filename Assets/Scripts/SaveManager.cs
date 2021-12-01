using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager {
    private static readonly string _path = Application.persistentDataPath + "/GameData.dot";

    public static void SaveData(GameData data) {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(_path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadData() {
        if (File.Exists(_path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(_path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;
        } else {
            return null;
        }
    }
}