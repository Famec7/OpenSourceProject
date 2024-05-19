using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerData _playerData = null;
    private Rigidbody2D _rigidbody2D;
    public float jumpForce = 10.0f; // ���� �� - ���� ���� RigidBody 2D�� Gravity Scale ���� �����Ͽ� ���� ���� ����
    private int jumpCount = 0;      // ���� ���� Ƚ��
    private int maxJumpCount = 2;   // �ִ� ���� Ƚ�� (���� ����)

    private void Start()
    {
        _playerData = DataManager.Instance.LoadData();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumpCount)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0; // ���� ������ ���� ī��Ʈ �ʱ�ȭ
        }
    }
}