using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;
    private int CurrentScore;

    public void Scoreupdate()
    {
        ScoreText.text = CurrentScore.ToString();
    }

    public void ScoreAdd1()
    {
        CurrentScore++;
        Scoreupdate();
    }

    public void ScoreAdd5()
    {
        CurrentScore += 5;
        Scoreupdate();
    }
}
