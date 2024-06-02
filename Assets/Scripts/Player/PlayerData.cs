[System.Serializable]
public class PlayerData
{
    public float speed;

    private int _hp;
    public int Hp
    {
        get => _hp;
        set
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > MaxHp)
            {
                value = MaxHp;
            }
        }
    }
    public int MaxHp { get; set; }
}
