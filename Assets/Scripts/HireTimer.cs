using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HireTimer : MonoBehaviour
{
    bool isStarted = false;
    public GameManager gameManager;
    [SerializeField]
    Button hiringButton;
    int timerTime;
    float currentTimerTime;
    Image timerImage;
    [SerializeField]
    AudioSource clickSound;
    
    public bool tick=false;

    void Start()
    {        
        timerImage = GetComponent<Image>();        
        hiringButton.interactable = true;
        timerImage.fillAmount = 1;


    }

    void Update()
    {
        tick = false;

        if (isStarted)
        {
            timerImage.fillAmount = currentTimerTime / timerTime;
            hiringButton.interactable = false;
            currentTimerTime -= Time.deltaTime;

            if (currentTimerTime <= 0)
            {
                tick = true;                
                isStarted = false;
                currentTimerTime = timerTime;
                timerImage.fillAmount = 1;
                hiringButton.interactable = true;
            }
        }
    }
    public void SetTimerTime(int time)
    {
        timerTime = time;
    }
    public void StartTimer()
    {
        clickSound.Play();
        currentTimerTime = timerTime;
        isStarted = true;
    }
}
