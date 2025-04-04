using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPosition : MonoBehaviour
{
    private Button towerPositionButton;

    private bool isFull = false;
    public bool IsFull => isFull;

    void Awake()
    {
        towerPositionButton = GetComponent<Button>();
        towerPositionButton.onClick.AddListener(SetTowerSelectionUIActive);
    }


    public void SetTowerPositionFull(bool value)
    {
        isFull = value;
    }

    public void SetTowerSelectionUIActive()
    {
        print(transform.name);
    }

}
