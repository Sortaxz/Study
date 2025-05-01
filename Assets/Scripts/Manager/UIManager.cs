using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    
    #region  Finish 
    
    [SerializeField] private GameObject finalPanel;
    [SerializeField] GameObject win_Text;
    [SerializeField] GameObject lose_Text;

    #endregion

    #region  Tower Position
    [SerializeField] private GameObject towerPositionParent;
    
    [SerializeField] private TowerPosition[] towerPositions;
    public TowerPosition[] TowerPositions => towerPositions;

    #endregion

    #region  Balance
    BalanceOperationsUIControl balanceOperationsUIControl;
    [SerializeField] private TextMeshProUGUI balanceTextMeshProGUI;
    

    #endregion

    void Awake()
    {
        
        win_Text = finalPanel.transform.Find("Win_Text").gameObject;
        lose_Text = finalPanel.transform.Find("Lose_Text").gameObject;

        towerPositions = new TowerPosition[towerPositionParent.transform.childCount];

        for (int i = 0; i < towerPositions.Length; i++)
        {
            towerPositions[i] = towerPositionParent.transform.GetChild(i).GetComponent<TowerPosition>();
        }
        
        balanceOperationsUIControl = new BalanceOperationsUIControl(GameManager.Instance.BalanceOperations,balanceTextMeshProGUI);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            balanceOperationsUIControl.SetCoinText(20);
        }
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
