using UnityEngine;

public abstract class ItemDataBase : ScriptableObject
{
    public new string name; // 아이템 이름
    public float duration = 0f; // 아이템 지속시간 (0이면 지속시간 없음)
    public ItemType type; // 아이템 타입
    [SerializeField] private Sprite _sprite; // 아이템 이미지
    
    public Sprite Sprite => _sprite;
}