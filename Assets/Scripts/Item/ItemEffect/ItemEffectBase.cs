using System;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class ItemEffectBase : MonoBehaviour, IPool
{
    [SerializeField]
    private ItemDataBase _itemData; // 아이템 데이터
    private SpriteRenderer _spriteRenderer;
    
    [SerializeField] private string _name;
    
    private float _leftLimit; // 왼쪽 경계
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _itemData.Sprite;
    }

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

    public ItemDataBase ItemData => _itemData;

    /// <summary>
    /// 아이템 효과 활성화
    /// </summary>
    /// <param name="playerData"></param>
    public abstract void Activate(PlayerData playerData);
    
    /// <summary>
    /// 아이템 효과 비활성화
    /// </summary>
    public abstract void Deactivate(PlayerData playerData);
    
    /// <summary>
    /// 지속시간 동안 호출하는 업데이트 함수
    /// </summary>
    public abstract void UpdateEffect(PlayerData playerData);

    public string Name => _name;
    public void GetFromPool()
    {
        ;
    }

    public void ReturnToPool()
    {
        ;
    }
}