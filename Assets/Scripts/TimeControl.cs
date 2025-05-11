using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    static TimeControl timeControl;
    private TimeController timeController;

    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private bool isStop = false;
    [SerializeField] private bool isPause = false;
    private float time = 0;
    [SerializeField] private float finishTime = 0;
    void OnEnable()
    {
        StartCoroutine(Timer());
    }


    void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        if(timeControl == null)
        {
            timeControl =this;
        }        
        if(timeController == null)
        {
            timeController = new TimeController();
        }
        
    }

    void Start()
    {
        
    }
    private float seconds = 0f;

    private IEnumerator Timer()
    {
        while (!isStop)
        {
            if (!isPause)
            {
                if(time < finishTime)
                {
                    seconds+= Time.deltaTime;
                    if(seconds >= 59)
                    {
                        seconds = 0f;
                        time++;
                    }
                    string formattedTime = string.Format("{0:00}:{1:00}", time, (int)seconds);
                    textMeshProUGUI.text = formattedTime;
                }
                else
                {
                    
                    GameManager.GameWon();
                    
                    
                }
            }

            yield return null; // Daha az CPU tüketimi
        }
    }

    private void Vol_1()
    {
        time += Time.deltaTime;

        int hours = Mathf.FloorToInt(time / 3600);
        int minutes = Mathf.FloorToInt((time % 3600) / 60);
        int seconds = Mathf.FloorToInt(time % 60);


        string formattedTime = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        textMeshProUGUI.text = formattedTime;
    }

}
