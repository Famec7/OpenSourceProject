using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    private readonly string _path = Application.dataPath + "/Data/PlayerData.json";
    private PlayerData _playerData = null;
    protected override void Init()
    {
        _playerData = LoadData();
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