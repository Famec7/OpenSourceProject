using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerData _playerData = null;
    private Animator _animator;

    private Rigidbody2D _rigidbody2D;
    public float jumpForce = 10.0f; // ���� �� - ���� ���� RigidBody 2D�� Gravity Scale ���� �����Ͽ� ���� ���� ����
    private int _jumpCount = 0;      // ���� ���� Ƚ��
    private int _maxJumpCount = 2;   // �ִ� ���� Ƚ�� (���� ����)
    private bool _isSliding = false;

    private BoxCollider2D _collider;
    private Vector2 _standingColliderSize;
    private Vector2 _standingColliderOffset;
    public Vector2 slidingColliderSize;
    public Vector2 slidingColliderOffset;

    private bool _isJump = false;

    private void Start()
    {
        _playerData = DataManager.Instance.LoadData();
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _collider = GetComponent<BoxCollider2D>();
        _standingColliderSize = _collider.size; // ���� �ݶ��̴� ũ�� ����
        _standingColliderOffset = _collider.offset; // ���� �ݶ��̴� ������ ����

        // �����̵� �ݶ��̴� ���� (���� ũ���� ����)
        slidingColliderSize = new Vector2(_collider.size.x, _collider.size.y / 2);
        slidingColliderOffset = new Vector2(_collider.offset.x, _collider.offset.y - _collider.size.y / 4);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && _jumpCount < _maxJumpCount)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            _jumpCount++;
            _isJump = true;
            _animator.SetBool("Jump", true);
        }

        if (Input.GetKey(KeyCode.LeftShift) && !_isSliding &&!_isJump)
        {
            StartSlide();
            _animator.SetBool("Slide", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && _isSliding)
        {
            _animator.SetBool("Slide", false);
            StopSlide();
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
            _animator.SetBool("Jump", false);
            _jumpCount = 0; // ���� ������ ���� ī��Ʈ �ʱ�ȭ
            _isJump = false;
        }
    }
}