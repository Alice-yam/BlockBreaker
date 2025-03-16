using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab;  // ブロックのPrefab
    public int rows = 10;            // ブロックの行数
    public int columns = 15;         // ブロックの列数
    public float blockSpacing = 0.05f; // ブロック間の隙間
    public float padding = 0.2f;     // 余白

    void Start()
    {
        // カメラサイズを取得
        float screenWidth = Camera.main.orthographicSize * 2f * Camera.main.aspect;
        float screenHeight = Camera.main.orthographicSize * 2f;

        // ブロックのサイズを取得
        Vector2 blockSize = blockPrefab.GetComponent<SpriteRenderer>().bounds.size;

        // 列数と行数を計算
        columns = Mathf.FloorToInt((screenWidth - padding * 2f) / (blockSize.x + blockSpacing));
        rows = Mathf.FloorToInt((screenHeight / 2f - padding * 2f) / (blockSize.y + blockSpacing));

        // 左端＆上端の開始位置を計算
        float startX = -(columns / 2f) * (blockSize.x + blockSpacing) + blockSize.x / 2f;

        // **上端ギリギリにする修正**
        float startY = Camera.main.orthographicSize - blockSize.y / 2f - padding;

        Debug.Log("StartX: " + startX + ", StartY: " + startY);

        // ブロックを並べる
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Vector2 position = new Vector2(
                    startX + col * (blockSize.x + blockSpacing),
                    startY - row * (blockSize.y + blockSpacing)
                );
                Instantiate(blockPrefab, position, Quaternion.identity);
            }
        }
    }
}