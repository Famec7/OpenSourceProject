using UnityEngine;

public abstract class ItemDataBase : ScriptableObject
{
    public new string name;
    public float duration = 0f;
    public ItemType type;
    [SerializeField] private Sprite _sprite;
    
    public Sprite Sprite => _sprite;
}