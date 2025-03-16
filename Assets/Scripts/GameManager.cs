using UnityEngine;
using UnityEngine.SceneManagement; // シーンリセット用
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject restartButton;  // リスタートボタンの参照

    void Start()
    {
        restartButton.SetActive(false);  // 最初はボタン非表示
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        restartButton.SetActive(true);  // ゲームオーバー時にボタンを表示
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // シーンの再読み込み
    }

    void Update()
    {
        // スペースキーでリスタート
        if (restartButton.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
             RestartGame();
        }
     }

}