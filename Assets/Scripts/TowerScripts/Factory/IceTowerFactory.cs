using System.Collections;
using System.Collections.Generic;
using TowerDatas.Ice;
using Towers.DataScriptableObject;
using UnityEngine;
using UnityEngine.UI;

namespace Towers
{
    public class IceTowerFactory : IIceTowerFactory
    {
        private TowerDateScriptableObject towerDateScriptableObject;

        public void SetTowerDateScriptableObject(TowerDateScriptableObject _towerDateScriptableObject)  
        {
            towerDateScriptableObject = _towerDateScriptableObject;
        }
        
        
        public Tower Create(TowerName towerName,Vector3 towerPosition,int index)
        {
            GameObject prefab = Resources.Load<GameObject>($"Tower/IceTowerPrefabs/{towerName}");
            GameObject iceTowerGameObject = null;
            if(prefab != null)
            {
                iceTowerGameObject = GameObject.Instantiate(prefab);
                iceTowerGameObject.name = iceTowerGameObject.name.Replace("_1(Clone)",$"_ {index}");
                IceTower iceTower=   iceTowerGameObject.GetComponent<IceTower>();
                A(iceTower,iceTower.GetComponent<SpriteRenderer>().sprite,towerPosition);
            }

            return iceTowerGameObject.GetComponent<Tower>();
        }

        public void A(IceTower iceTower,Sprite sprite,Vector3 pos)
        {
            int index = 0;
            for (int i = 0; i < towerDateScriptableObject.IceTowerDatas.Length; i++)
            {
                if(towerDateScriptableObject.IceTowerDatas[i].towerName == sprite.name) 
                {
                    index = i;
                    break;
                }
            }
            IceTowerData iceTowerData = towerDateScriptableObject.IceTowerDatas[index];
            iceTower.SetTowerProperty(pos,TowerAttackType.Single,iceTowerData);

        }
    }


}
