using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pipePrefab;
    private List<Pipe> pipes = new List<Pipe>();
    private int pipeCursor;
    private float timer;

    [SerializeField]
    private Text scoreText;
    public static int score;
    public static int bestScore;

    private void Awake()
    {
        score = 0;
        bestScore = PlayerPrefs.GetInt("BestScore");

        for (int i = 0; i < 20; i++)
        {
            MakePipe();
        }
    }

    private void Update()
    {
        if ((timer += Time.deltaTime) >= Random.Range(2f, 5f))
        {
            timer = 0f;

            EnablePipe();
        }

        scoreText.text = string.Format("Score : {0:n0}", score);
    }

    private void MakePipe()
    {
        GameObject pipeObject = Instantiate(pipePrefab, new Vector3(8f, 0f, 0f), Quaternion.identity);
        Pipe pipeComponent = pipeObject.GetComponent<Pipe>();

        pipes.Add(pipeComponent);
    }

    private void EnablePipe()
    {
        if (pipeCursor < pipes.Count)
        {
            pipes[pipeCursor++].gameObject.SetActive(true);

            return;
        }

        pipes[pipeCursor = 0].gameObject.SetActive(true);
    }
}
