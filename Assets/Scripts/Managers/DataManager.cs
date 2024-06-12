using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    private readonly string _path = Application.dataPath + "/Data/PlayerData.json";
    private PlayerData _playerData = null;

    public override void Init()
    {
        if(System.IO.File.Exists(_path))
            _playerData = LoadData();
        else
        {
            _playerData = new PlayerData
            {
                initialSpeed = 5,
                speed = 5,
                maxHp = 30,
                CurrentHp = 30,
            };
            SaveData(_playerData);
        }
    }
    
    public void SaveData(PlayerData data)
    {
        string json = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText(_path, json);
    }
    
    public PlayerData LoadData()
    {
        if(_playerData != null)
            return _playerData;
        
        string json = System.IO.File.ReadAllText(_path);
        return JsonUtility.FromJson<PlayerData>(json);
    }
}