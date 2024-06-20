using UnityEngine;
using TMPro;
public class TimeCounter : MonoBehaviour
{
    private float elapsedTimeSeconds;
    private int elapsedMinutes;
    public TMP_Text TimerTxt;
    bool startcounting = false;
    void Update()
    {
        if (GameManager.Instance.StartGame)
        {

          
                // Update the elapsed time
                elapsedTimeSeconds += Time.deltaTime;

                // Check if a minute has passed
                if (elapsedTimeSeconds >= 60f)
                {
                    elapsedTimeSeconds -= 60f;
                    elapsedMinutes++;
                }

                // Display the time in the Unity console
                TimerTxt.text = elapsedTimeSeconds.ToString("00") + "s";

           
        }
    }

    public void StartGame()
    {
        startcounting = true;
    }
}
