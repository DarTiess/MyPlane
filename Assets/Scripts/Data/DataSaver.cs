using UnityEngine;

namespace Data
{
    public class DataSaver : IDataSaver
    {
        public int Lifes
        {
            get { return PlayerPrefs.GetInt("Lifes"); }
            set { PlayerPrefs.SetInt("Lifes", value); }
        }
        public int CurrentScene
        {
            get { return PlayerPrefs.GetInt("CurrentScene"); }
            set { PlayerPrefs.SetInt("CurrentScene", value); }
        }
    }
}