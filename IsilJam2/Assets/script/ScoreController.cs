using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [HideInInspector]
    public int scorePlayer1 = 0;
    [HideInInspector]
    public int scorePlayer2 = 0;

    [SerializeField]
    public string tagPlayer1Goal = "GoalPlayer1";
    [SerializeField]
    public string tagPlayer2Goal = "GoalPlayer2";

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
    public void ActulizarPuntaje1(){
        scorePlayer1++;
        Debug.Log("Punto para el Jugador 1! Puntuación: " + scorePlayer1);
        UpdateScoreUI();
    }

    public void ActulizarPuntaje2()
    {
        scorePlayer2++;
        Debug.Log("Punto para el Jugador 2! Puntuación: " + scorePlayer2);
        UpdateScoreUI();
    }
}