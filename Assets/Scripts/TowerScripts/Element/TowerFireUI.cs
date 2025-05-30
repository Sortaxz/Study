using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFireUI : MonoBehaviour
{

    public void TowerFireUIActiveFuntion(bool value)
    {
        if(gameObject.activeSelf)
        StartCoroutine(TowerFireUIActiveControl(value));
    }
    
    private IEnumerator TowerFireUIActiveControl(bool value)
    {
        while (!value)
        {
            print(value);
            yield return null;
        }
    }


}
