using UnityEngine;

[System.Serializable]
public class Pool
{
    public Component prefab; // 오브젝트 풀링할 프리팹
    public int count; // 오브젝트 풀 크기
    public Transform parent = null; // 오브젝트 풀 부모
}