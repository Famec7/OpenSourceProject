using System;
using UnityEngine;

public class ObjectScrolling : MonoBehaviour
{
    private float _scrollSpeed;

    private void Start()
    {
        _scrollSpeed = DataManager.Instance.LoadData().speed;
    }
    
    private void Update()
    {
        _scrollSpeed = DataManager.Instance.LoadData().speed;
        ScrollObstacle();
    }
    
    private void ScrollObstacle()
    {
        transform.position += new Vector3(-_scrollSpeed, 0, 0) * Time.deltaTime;
    }
}