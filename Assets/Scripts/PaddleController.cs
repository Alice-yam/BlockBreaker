using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f;
    private float minX;
    private float maxX;

    void Start()
    {
        // 画面の端を計算
        float halfPaddleWidth = transform.localScale.x / 2f;
        minX = Camera.main.ScreenToWorldPoint(Vector3.zero).x + halfPaddleWidth;
        maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - halfPaddleWidth;
    }

    void Update()
    {
        // 横方向の入力を取得
        float horizontal = Input.GetAxis("Horizontal");

        // パドルを動かす
        Vector3 newPosition = transform.position + new Vector3(horizontal * speed * Time.deltaTime, 0, 0);

        // パドルの位置を画面内に制限
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        transform.position = newPosition;
    }
}