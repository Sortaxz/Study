using System.Collections;
using System.Collections.Generic;
using Towers;
using UnityEngine;
using UnityEngine.UI;

namespace Towers.Position
{

    public class TowerPosition : MonoBehaviour
    {
        [SerializeField]private SpriteRenderer towerPositionImage;
        [SerializeField] private bool isFull = false;
        public bool IsFull {get {return isFull;} set=> isFull = value;}
        [SerializeField] private int level;
        public int Level => level;

        void Awake()
        {
            towerPositionImage = GetComponent<SpriteRenderer>();
            //towerPositionButton.onClick.AddListener(SetTowerSelectionUIActive);
        }


        //TowerPosition objesinin dolu olarak gözükmesini sağliyor        
        public void SetTowerPositionFull(bool value)
        {
            isFull = value;
        }

        public void SetTowerSelectionUIActive(bool value)
        {
            UIManager.Instance.TowerElectionCardController.SetActiveTowerElectionsObject(gameObject,value, level);
            if (value)
            {
                GameUIManager.Instance.AdjustTowerPositionActive(gameObject);
            }
            else
            {
                GameUIManager.Instance.SetActiveAllTowerPositionInteractable();
            }
        }

        private bool isClick = false;
        public bool IsClick {get {return isClick;}  set {isClick = value;} }
        [SerializeField] private bool isInteractable = true;

        //Tikladiktan sonra işlem yapmamizi sağliyor
        void OnMouseDown()
        {
            if (isInteractable && !isFull)
            {
                isClick = !isClick;
                SetTowerSelectionUIActive(isClick);
            }
        }

        //tiklanilabilir olmasini sağliyor.
        public void SetTowerPositionInteractable(bool value)
        {
            isInteractable = value;
        }

        public void AdjustTowerPositionImageActve(bool value)
        {
            towerPositionImage.enabled = value;
        }

        public void AdjustTowerPositionClick(bool click)
        {
            isClick = click;
            if(!isClick)
            {
                AdjustTowerPositionImageActve(false);
                isFull = true;
                GameUIManager.Instance.SetActiveAllTowerPositionInteractable();   
            }
        }

    }
}
