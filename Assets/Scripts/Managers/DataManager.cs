using System.Collections;
using System.Collections.Generic;
using System.IO;
using Defines;
using Newtonsoft.Json;
using UnityEngine;

namespace Managers
{
    public class DataManager : Singleton<DataManager>
    {
        public string DataPath;
        public Dictionary<int, ItemDefine> items = null;

        public DataManager()
        {
            DataPath = "Data/";
        }

        public void Load()
        {
            string json = File.ReadAllText(this.DataPath + "ItemDefine.txt");
            items = JsonConvert.DeserializeObject<Dictionary<int, ItemDefine>>(json);


        }

        public IEnumerator LoadData()
        {
            string json = File.ReadAllText(this.DataPath + "ItemDefine.txt");
            items = JsonConvert.DeserializeObject<Dictionary<int, ItemDefine>>(json);
            yield return null;
        }
    }
}
