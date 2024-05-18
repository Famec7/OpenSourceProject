using System;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class ItemEffectBase : MonoBehaviour
{
    [SerializeField]
    private ItemDataBase _itemData; // 아이템 데이터
    private SpriteRenderer _spriteRenderer;
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _itemData.Sprite;
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
    public abstract void Deactivate();
}