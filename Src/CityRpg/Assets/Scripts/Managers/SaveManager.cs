using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Entities;
using UnityEngine;

namespace Managers
{
    class SaveManager : Singleton<SaveManager>
    {
        public void SaveData()
        {
            int saveIndex = PlayerPrefs.GetInt("SaveIndex", 0);
            string savePath = Path.Combine(PathUtil.SavePath, "cityRpgSave" + saveIndex + ".dat");
            BinaryFormatter formatter = new BinaryFormatter();
            using(FileStream stream = new FileStream(savePath, FileMode.Create))
            {
                formatter.Serialize(stream, User.Instance.currentPlayer);
            }
        }

        public Player LoadData(string saveFile)
        {
            string savePath = Path.Combine(PathUtil.SavePath, saveFile);
            if (!File.Exists(savePath))
            {
                return null;
            }

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(savePath, FileMode.Open))
            {
                return (Player)formatter.Deserialize(stream);
            }
        }
    }
}
