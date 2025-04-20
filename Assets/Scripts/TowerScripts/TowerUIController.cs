using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUIController : MonoBehaviour
{
    [SerializeField] Image healtBar;

    public void SetHealtBarValue(float towerHealt)
    {
        float a = towerHealt / 100f;
        healtBar.fillAmount = a;
    }

    public void HealtBarValueIncrease(float towerHealt)
    {
        SetHealtBarValue(towerHealt);
    }

    public void HealtBarValueReduction(float towerHealt)
    {
        SetHealtBarValue(towerHealt);
    }

}
