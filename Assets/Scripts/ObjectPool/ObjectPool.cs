using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private List<Pool<Component>> _pools; // 오브젝트 풀 리스트

    private void InitPool()
    {
        foreach (var pool in _pools)
        {
            for (int i = 0; i < pool.count; i++)
            {
                ObjectPoolManager.Instance.CreateObjectPool(pool.prefab, pool.count, pool.parent);
            }
        }
    
    }

    private void Start()
    {
        InitPool();
    }
}