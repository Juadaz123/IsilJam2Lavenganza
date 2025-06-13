using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [HideInInspector]
    public int scorePlayer1 = 0;
    [HideInInspector]
    public int scorePlayer2 = 0;

    [SerializeField]
    private string tagPlayer1Goal = "GoalPlayer1";
    [SerializeField]
    private string tagPlayer2Goal = "GoalPlayer2";

    [SerializeField]
    private TMP_Text scoreText1;
    [SerializeField]
    private TMP_Text scoreText2;

    void Start()
    {
        if (scoreText1 == null)
        {
            Debug.LogError("ScoreText1 no está asignado en el Inspector de Unity para ScoreController.");
        }
        if (scoreText2 == null)
        {
            Debug.LogError("ScoreText2 no está asignado en el Inspector de Unity para ScoreController.");
        }

        UpdateScoreUI();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagPlayer1Goal))
        {
            scorePlayer1++;
            Debug.Log("Punto para el Jugador 1! Puntuación: " + scorePlayer1);
            UpdateScoreUI();
        }
        else if (collision.gameObject.CompareTag(tagPlayer2Goal))
        {
            scorePlayer2++;
            Debug.Log("Punto para el Jugador 2! Puntuación: " + scorePlayer2);
            UpdateScoreUI();
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText1 != null)
        {
            scoreText1.text = scorePlayer1.ToString();
        }
        if (scoreText2 != null)
        {
            scoreText2.text = scorePlayer2.ToString();
        }
    }
}