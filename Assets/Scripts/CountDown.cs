using System.Collections;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CountDownText;
    [SerializeField] private GameObject TimeoutDisplay;
    [SerializeField] private int LevelCountDown;

    void Start()
    {
        StartCoroutine(Timer1());
    }

    public void StartTimer()
    {
        StartCoroutine(Timer1());
    }

    public void StopTimer()
    {
        StopCoroutine(Timer1());
    }

    public void AddTime(int Time)
    {
        LevelCountDown = LevelCountDown + Time;
    }

    IEnumerator Timer1(float countTime = 1f)
    {
        while (LevelCountDown >= 1)
        {
            yield return new WaitForSeconds(countTime);
            LevelCountDown--;
            CountDownText.text = LevelCountDown.ToString();
            //CountDownText.text = "TIME: " + LevelCountDown.ToString();
        }

        TimeoutDisplay.SetActive(true);
        yield return new WaitForSeconds(3f);
    }
}
