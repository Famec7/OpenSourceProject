using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerData _playerData = null;

    private Rigidbody2D _rigidbody2D;
    public float jumpForce = 10.0f; // 점프 힘 - 점프 힘과 RigidBody 2D의 Gravity Scale 값을 조정하여 점프 조정 가능
    private int _jumpCount = 0;      // 현재 점프 횟수
    private int _maxJumpCount = 2;   // 최대 점프 횟수 (더블 점프)
    private bool _isSliding = false;

    private BoxCollider2D _collider;
    private Vector2 _standingColliderSize;
    private Vector2 _standingColliderOffset;
    public Vector2 slidingColliderSize;
    public Vector2 slidingColliderOffset;

    private void Start()
    {
        _playerData = DataManager.Instance.LoadData();
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _collider = GetComponent<BoxCollider2D>();
        _standingColliderSize = _collider.size; // 기존 콜라이더 크기 저장
        _standingColliderOffset = _collider.offset; // 기존 콜라이더 오프셋 저장

        // 슬라이딩 콜라이더 설정 (기존 크기의 절반)
        slidingColliderSize = new Vector2(_collider.size.x, _collider.size.y / 2);
        slidingColliderOffset = new Vector2(_collider.offset.x, _collider.offset.y - _collider.size.y / 4);
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift) && !_isSliding)
        {
            StartSlide();
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && _isSliding)
        {
            StopSlide();
        }

        if (Input.GetButtonDown("Jump") && _jumpCount < _maxJumpCount)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            _jumpCount++;
        }
    }

    private void StartSlide()
    {
        _isSliding = true;
        _collider.size = slidingColliderSize;
        _collider.offset = slidingColliderOffset;
    }

    private void StopSlide()
    {
        _isSliding = false; 
        _collider.size = _standingColliderSize;
        _collider.offset = _standingColliderOffset;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _jumpCount = 0; // 땅에 닿으면 점프 카운트 초기화
        }
    }
}