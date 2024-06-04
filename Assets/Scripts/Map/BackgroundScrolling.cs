using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    [Header("Backgrounds")] public Transform[] backgrounds;

    private float _scrollSpeed; // 배경 스크롤 속도

    private float _leftLimit;
    private float _rightLimit;
    private float _xScreenHalfSize;

    private void Start()
    {
        _scrollSpeed = DataManager.Instance.LoadData().speed;

        var main = Camera.main;
        if (main != null)
        {
            _xScreenHalfSize = main.orthographicSize * main.aspect;

            _leftLimit = -_xScreenHalfSize * 2;
            _rightLimit = _xScreenHalfSize * 2 * backgrounds.Length;
        }
    }

    private void Update()
    {
        _scrollSpeed = DataManager.Instance.LoadData().speed;
        ScrollBackground();
    }
    
    private void ScrollBackground()
    {
        foreach (var background in backgrounds)
        {
            background.position += new Vector3(-_scrollSpeed, 0, 0) * Time.deltaTime;

            if (background.position.x < _leftLimit)
            {
                Vector3 nextPos = background.position;
                nextPos.x += _rightLimit;
                background.position = nextPos;
            }
        }
    }
}