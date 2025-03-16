using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 10f; // ボールの速度
    private Rigidbody2D rb;
    private GameManager gameManager; // GameManager用

    void Start()
    {
        // Rigidbody2Dを取得
        rb = GetComponent<Rigidbody2D>();

        // GameManagerを探して取得
        gameManager = FindObjectOfType<GameManager>();

        // 最初にランダムな方向にボールを飛ばす
        rb.linearVelocity = new Vector2(Random.Range(-1f, 1f), 1f).normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ブロックに当たったらブロックを消す
        if (collision.gameObject.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
        }

        // パドルに当たったときにちょっと角度を変える
        if (collision.gameObject.CompareTag("Paddle"))
        {
            float hitPoint = collision.contacts[0].point.x - collision.transform.position.x;
            rb.linearVelocity = new Vector2(hitPoint * 5f, rb.linearVelocity.y).normalized * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // デッドゾーンに触れたらゲームオーバー
        if (collision.CompareTag("ResetZone"))
        {
            gameManager.GameOver();
        }
    }
}