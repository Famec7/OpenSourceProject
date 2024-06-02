using UnityEngine;

public class Obstacle : MonoBehaviour, IPool
{
    [SerializeField] private string _name;
    
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