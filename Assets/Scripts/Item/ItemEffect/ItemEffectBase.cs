using System;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class ItemEffectBase : MonoBehaviour
{
    [SerializeField]
    private ItemDataBase _itemData;
    private SpriteRenderer _spriteRenderer;
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _itemData.Sprite;
    }
    
    public ItemDataBase ItemData => _itemData;

    public abstract void Activate(PlayerData playerData);
    public abstract void Deactivate();
}