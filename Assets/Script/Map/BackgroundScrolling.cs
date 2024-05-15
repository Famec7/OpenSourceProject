using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    private float _scrollSpeed;
    
    private void Start()
    {
        _scrollSpeed = DataManager.Instance.LoadData().speed;
    }

    private void Update()
    {
        transform.Translate(-_scrollSpeed * Time.deltaTime, 0, 0);
    }
}