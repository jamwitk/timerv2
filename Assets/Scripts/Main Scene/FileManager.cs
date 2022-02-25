using UnityEngine;

namespace Main_Scene
{
    public class FileManager : Singleton<FileManager>
    {
        public void SaveData(string key,int value)
        {
            PlayerPrefs.SetInt(key,value);
        }

        public void SaveData(string key, string value)
        {
            PlayerPrefs.SetString(key,value);
        }

        public int GetIntData(string key)
        {
            return PlayerPrefs.GetInt(key);
        }

        public string GetStringData(string key)
        {
            return PlayerPrefs.GetString(key);
        }
    }
}