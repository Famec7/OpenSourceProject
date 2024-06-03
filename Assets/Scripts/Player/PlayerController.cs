using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerData _playerData = null;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _collider;

    // 점프 관련 변수
    public float jumpForce = 10.0f;  // 점프 힘 - 점프 힘과 RigidBody 2D의 Gravity Scale 값을 조정하여 점프 조정 가능   
    private int _jumpCount = 0;      // 현재 점프 횟수
    private int _maxJumpCount = 2;   // 최대 점프 횟수 (더블 점프)

    // 무적 관련 변수
    public float invincibleTime = 2f; // 무적 시간 (s)
    private bool _isInvincible = false;

    // 콜라이더 크기 및 오프셋
    private Vector2 _standingColliderSize;
    private Vector2 _standingColliderOffset;
    public Vector2 slidingColliderSize;     // 슬라이딩 시 콜라이더 크기
    public Vector2 slidingColliderOffset;   // 슬라이딩 시 콜라이더 오프셋

    // 플레이어 상태를 나타내는 열거형
    enum PlayerState 
    {
        Running,
        Jumping,
        Sliding
    }

    private PlayerState _currentState = PlayerState.Running; // 초기 상태는 Running

    private void Awake()
    {
        _playerData = DataManager.Instance.LoadData();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        // 기존 콜라이더 크기 및 오프셋 저장
        _standingColliderSize = _collider.size; 
        _standingColliderOffset = _collider.offset;

        // 슬라이딩 시 적용될 콜라이더 및 오프셋 설정 (기존 크기의 절반)
        slidingColliderSize = new Vector2(_collider.size.x, _collider.size.y / 2);
        slidingColliderOffset = new Vector2(_collider.offset.x, _collider.offset.y - _collider.size.y / 4);
    }

    private void Update()
    {
        // 점프 입력 처리
        if (Input.GetButtonDown("Jump") && _jumpCount < _maxJumpCount)
        {
            Jump();
        }

        // 슬라이딩 입력 처리
        if (Input.GetKey(KeyCode.LeftShift) && _currentState == PlayerState.Running)
        {
            StartSlide();
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            StopSlide();
        }
    }

    private void Jump()
    {
        // 슬라이딩 중에 점프 시 슬라이딩 중지
        if (_currentState == PlayerState.Sliding)
        {
            StopSlide();
        }

        // 점프 로직 수행
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
        _jumpCount++;
        _currentState = PlayerState.Jumping;
        _animator.SetBool("Jump", true); // 점프 애니메이션 활성화
    }


    // 슬라이딩 상태로 전환
    private void StartSlide()
    {
        _currentState = PlayerState.Sliding;
        _collider.size = slidingColliderSize;
        _collider.offset = slidingColliderOffset;
        _animator.SetBool("Slide", true); // 슬라이딩 애니메이션 활성화
    }

    // 슬라이딩 상태 해제
    private void StopSlide()
    {
        _animator.SetBool("Slide", false);
        _currentState = PlayerState.Running;
        _collider.size = _standingColliderSize;
        _collider.offset = _standingColliderOffset;
    }

    // 장애물 충돌 시 플레이어를 무적 상태로 만드는 함수
    private void OnDamaged()
    {
        // 플레이어 무적 활성화
        _isInvincible = true;

        // 플레이어 Sprite 반투명화
        _spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        // 무적 시간이 끝나면 무적 상태 종료 함수 호출
        Invoke("OffDamaged", invincibleTime);
    }

    // 플레이어를 무적 상태에서 벗어나게 만드는 함수
    private void OffDamaged()
    {
        // 플레이어 무적 비활성화
        _isInvincible = false;

        // 플레이어 Sprite 불투명화
        _spriteRenderer.color = new Color(1, 1, 1, 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _animator.SetBool("Jump", false);
            _jumpCount = 0; // 땅에 닿으면 점프 카운트 초기화
            _currentState = PlayerState.Running; // 땅에 닿을 경우 상태를 Running으로 전환
        }
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        // 장애물과 충돌 시
        if (Other.gameObject.CompareTag("Obstacle"))
        {
            if (_isInvincible == false) // 플레이어가 현재 무적 상태가 아니라면
            {
                _playerData.Hp -= 1; // player의 hp 감소
                OnDamaged(); // 플레이어 무적 상태 진입 함수 호출
            }
        }
    }
}