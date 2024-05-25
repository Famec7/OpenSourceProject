using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerData _playerData = null;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _collider;

    // ���� ���� ����
    public float jumpForce = 10.0f;  // ���� �� ����� �� - ���� ���� RigidBody 2D�� Gravity Scale ���� �����Ͽ� ���� ���� ����   
    private int _jumpCount = 0;      // ���� ���� Ƚ��
    private int _maxJumpCount = 2;   // �ִ� ���� Ƚ�� (���� ����)

    // 무적 관련 변수
    public float invincibleTime = 2f; // 무적 시간 (s)
    private bool _isInvincible = false;

    // �ݶ��̴� ũ�� �� ������
    private Vector2 _standingColliderSize;
    private Vector2 _standingColliderOffset;
    public Vector2 slidingColliderSize;     // �����̵� �� �ݶ��̴� ũ��
    public Vector2 slidingColliderOffset;   // �����̵� �� �ݶ��̴� ������

    // �÷��̾� ���¸� ��Ÿ���� ������
    enum PlayerState 
    {
        Running,
        Jumping,
        Sliding
    }

    private PlayerState _currentState = PlayerState.Running; // �ʱ� ���´� Running

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
        // ���� �ݶ��̴� ũ�� �� ������ ����
        _standingColliderSize = _collider.size; 
        _standingColliderOffset = _collider.offset; 

        // �����̵� �� ����� �ݶ��̴� �� ������ ���� (���� ũ���� ����)
        slidingColliderSize = new Vector2(_collider.size.x, _collider.size.y / 2);
        slidingColliderOffset = new Vector2(_collider.offset.x, _collider.offset.y - _collider.size.y / 4);
    }

    private void Update()
    {
        // ���� �Է� ó��
        if (Input.GetButtonDown("Jump") && _jumpCount < _maxJumpCount)
        {
            Jump();
        }

        // �����̵� �Է� ó��
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
        // �����̵� �߿� ���� �� �����̵��� ����
        if (_currentState == PlayerState.Sliding)
        {
            StopSlide();
        }

        // ���� ���� ����
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
        _jumpCount++;
        _currentState = PlayerState.Jumping;
        _animator.SetBool("Jump", true); // ���� �ִϸ��̼� Ȱ��ȭ
    }


    // �����̵� ���·� ��ȯ
    private void StartSlide()
    {
        _currentState = PlayerState.Sliding;
        _collider.size = slidingColliderSize;
        _collider.offset = slidingColliderOffset;
        _animator.SetBool("Slide", true); // �����̵� �ִϸ��̼� Ȱ��ȭ
    }

    // �����̵� ���� ����
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
            _jumpCount = 0; // ���� ������ ���� ī��Ʈ �ʱ�ȭ
            _currentState = PlayerState.Running; // ���� ������ ���¸� Running���� ��ȯ
        }
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        // 장애물과 충돌 시
        if (Other.gameObject.CompareTag("Obstacle"))
        {
            if (_isInvincible == false) // 플레이어가 현재 무적 상태가 아니라면
            {
                _playerData.hp -= 1; // player의 hp 감소
                Debug.Log(_playerData.hp);
                OnDamaged(); // 플레이어 무적 상태 진입 함수 호출
            }
        }
    }
}