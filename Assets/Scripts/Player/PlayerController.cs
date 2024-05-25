using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerData _playerData = null;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _collider;

    // ���� ���� ����
    public float jumpForce = 10.0f;  // ���� �� ����� �� - ���� ���� RigidBody 2D�� Gravity Scale ���� �����Ͽ� ���� ���� ����   
    private int _jumpCount = 0;      // ���� ���� Ƚ��
    private int _maxJumpCount = 2;   // �ִ� ���� Ƚ�� (���� ����)

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _animator.SetBool("Jump", false);
            _jumpCount = 0; // ���� ������ ���� ī��Ʈ �ʱ�ȭ
            _currentState = PlayerState.Running; // ���� ������ ���¸� Running���� ��ȯ
        }

        // 장애물과 충돌 시
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            _playerData.hp -= 1; // player의 hp 감소
        }
    }
}