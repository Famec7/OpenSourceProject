using System;
using UnityEngine;

public class Obstacle : MonoBehaviour, IPool
{
    [SerializeField] private string _name;
    
    public string Name => _name;

    private float _leftLimit; // 왼쪽 경계
    
    private void Start()
    {
        // 왼쪽 경계 설정
        var main = Camera.main;
        if (main != null)
        {
            float xScreenHalfSize = main.orthographicSize * main.aspect;

            _leftLimit = -xScreenHalfSize * 2;
        }
    }

    private void Update()
    {
        // 왼쪽 경계에 도달하면 오브젝트 풀로 반환
        if (transform.position.x < _leftLimit)
        {
            ObjectPoolManager.Instance.ReturnObject(this);
        }
    }

    public void GetFromPool()
    {
        ;
    }

    public void ReturnToPool()
    {
        ;
    }
}