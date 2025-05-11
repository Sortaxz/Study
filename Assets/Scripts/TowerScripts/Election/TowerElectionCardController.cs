using System.Collections;
using System.Collections.Generic;
using TowerElections.Card;
using TowerElection.Scriptable;
using UnityEngine;
using Towers.Position;
using UnityEngine.UI;

namespace TowerElection
{
    public class TowerElectionCardController
    {
        private Transform towerElectionsParentObject;
        private TowerElectionCard[] towerElectionCards;
        public TowerElectionCard[] TowerElectionCards => towerElectionCards;
        public TowerPosition towerPosition;
        TowerElectionCardScritableObject towerElectionCardScritableObject;

        public TowerElectionCardController()
        {
            //towerElectionsParentObject sini sahne üzerinde bulmamizi sağliyor
            towerElectionsParentObject = GameObject.FindWithTag("TowerElectionParent").transform;
            
            towerElectionCards = new TowerElectionCard[towerElectionsParentObject.childCount];

            for (int i = 0; i < towerElectionsParentObject.childCount; i++)
            {
                towerElectionCards[i] = towerElectionsParentObject.GetChild(i).GetComponent<TowerElectionCard>();
            }
            
            towerElectionCardScritableObject = Resources.Load<TowerElectionCardScritableObject>("ScriptableObjects/TowerElectionSprite");
            
            if (towerElectionCardScritableObject == null) Debug.Log("boş");
        }

        //TowerElection objelerinin sprite leveline göre sprite atamsini yapmamizi sağliyor.
        public void SetActiveTowerElectionsObject(GameObject _towerPosition,bool value, int level)
        {
            towerPosition = _towerPosition.GetComponent<TowerPosition>();
            for (int i = 0; i < towerElectionCards.Length; i++)
            {
                towerElectionCards[i].SetTowerPositionProperty(towerPosition,this);
                towerElectionCards[i].SetActiveImage(value);


                towerElectionCards[i].SetSprite(towerElectionCardScritableObject.towerElectionSprites[level].towerElectionSprite[i],towerPosition.transform.position);
            }
            towerPosition = null;
        }

        public void TowerElectionImageClose()
        {
            for (int i = 0; i < towerElectionCards.Length; i++)
            {
                towerElectionCards[i].SetActiveImage(false);
            }
        }
        
    }

}
