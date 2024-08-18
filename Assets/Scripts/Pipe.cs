using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private void OnEnable()
    {
        float x = transform.position.x;
        float y = Random.Range(-2f, 4.5f);

        transform.position = new Vector3(x, y, 0f);

        Invoke(nameof(DisableObject), 8f);
    }

    private void OnDisable() => transform.position = Vector3.right * 8f;

    private void Update() => transform.position += Vector3.left * moveSpeed * Time.deltaTime;

    private void DisableObject() => gameObject.SetActive(false);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bird"))
        {
            GameManager.score++;
        }
    }
}
