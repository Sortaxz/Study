using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get 
        {
            if(instance == null)    
            {
                instance = FindObjectOfType<UIManager>();
            }
            return instance;
        }
    }
    //adet sayısını ScriptableObject ile yapılmalı.
    [SerializeField] private GameObject finalPanel;
    [SerializeField] GameObject win_Text;
    [SerializeField] GameObject lose_Text;

    void Awake()
    {
        
        win_Text = finalPanel.transform.Find("Win_Text").gameObject;
        lose_Text = finalPanel.transform.Find("Lose_Text").gameObject;
        
    }

    

    private void OpenFinalPanelActive()
    {
        finalPanel.SetActive(true);

    }

    private void CloseFinalPanelActive()
    {
        finalPanel.SetActive(false);

    }

    public void OpenWinFinalPanel()
    {
        if(QueryFinalPanel())
        {
            OpenFinalPanelActive();
            win_Text.gameObject.SetActive(true);
        }
    }

    public void CloseWinFinalPanel()
    {
        if(QueryFinalPanel())
        {
            OpenFinalPanelActive();
            win_Text.gameObject.SetActive(false);

        }
    }

    public void OpenLoseFinalPanel()
    {
        if(QueryFinalPanel())
        {
            OpenFinalPanelActive();
            lose_Text.gameObject.SetActive(true);
        }
    }

    public void CloseLoseFinalPanel()
    {
        if(QueryFinalPanel())
        {
            OpenFinalPanelActive();
            lose_Text.gameObject.SetActive(false);

        }

    }

    private bool QueryFinalPanel()
    {
        return finalPanel != null && win_Text != null && lose_Text != null;
    }
}
