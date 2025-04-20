using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy.UIController
{
    public class EnemyUIController : MonoBehaviour
    {
        [SerializeField] Image healtBar;

        public void SetHealtBarValue(float enemyHealt)
        {
            float a = enemyHealt / 100f;
            healtBar.fillAmount = a;
        }

        public void HealtBarValueIncrease(float enemyHealt)
        {
            SetHealtBarValue(enemyHealt);
        }

        public void HealtBarValueReduction(float enemyHealt)
        {
            SetHealtBarValue(enemyHealt);
        }

    }

}
