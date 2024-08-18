using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    [SerializeField]
    private float jumpForce;

    private Rigidbody2D rigid;

    private void Awake() => rigid = GetComponent<Rigidbody2D>();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigid.velocity = Vector2.up * jumpForce;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Dead"))
        {
            return;
        }

        if (GameManager.score > GameManager.bestScore)
        {
            PlayerPrefs.SetInt("BestScore", GameManager.bestScore = GameManager.score);
        }

        SceneManager.LoadScene(1);
    }
}
