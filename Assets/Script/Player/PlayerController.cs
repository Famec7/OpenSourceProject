using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerData _playerData = null;
    private Rigidbody2D _rigidbody2D;
    public float jumpForce = 10.0f; // 점프 힘 - 점프 힘과 RigidBody 2D의 Gravity Scale 값을 조정하여 점프 조정 가능
    private int jumpCount = 0;      // 현재 점프 횟수
    private int maxJumpCount = 2;   // 최대 점프 횟수 (더블 점프)

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
            jumpCount = 0; // 땅에 닿으면 점프 카운트 초기화
        }
    }
}