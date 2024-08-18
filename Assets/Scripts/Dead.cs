using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dead : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text bestScoreText;

    private void Awake()
    {
        scoreText.text = $"Score : {GameManager.score:n0}";
        bestScoreText.text = $"Best Score : {GameManager.bestScore:n0}";
    }

    public void ClickRetryButton() => SceneManager.LoadScene(0);
}
