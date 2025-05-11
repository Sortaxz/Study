using System.Collections;
using System.Collections.Generic;
using TowerElection;
using Towers.Position;
using UnityEngine;
using UnityEngine.UI;

namespace TowerElections.Card
{
    public class TowerElectionCard : MonoBehaviour
    {
        [SerializeField] private TowerElectionCardController towerElectionCardController;
        [SerializeField] private TowerPosition towerPosition;
        private Image image;
        private Button button;
        private Vector3 pos;

        void Awake()
        {
            image = GetComponent<Image>();

            

            button = GetComponent<Button>();
            button.onClick.AddListener(()=>
            {
                if(image.sprite.name.Contains("ArcherTower"))
                {
                    GameManager.Instance.CreateArcherTower(pos);
                }
                else if(image.sprite.name.Contains("FireTower"))
                {
                    GameManager.Instance.CreateFireTower(pos);
                }
                else if(image.sprite.name.Contains("IceTower"))
                {
                    GameManager.Instance.CreateIceTower(pos);
                }
                else
                {
                    return;
                }
                towerPosition.AdjustTowerPositionClick(false);
                towerElectionCardController.TowerElectionImageClose();
                
                
            });
        }
      
        public void SetTowerPositionProperty(TowerPosition _towerPosition,TowerElectionCardController _towerElectionCardController)
        {
            towerPosition = _towerPosition;
            towerElectionCardController = _towerElectionCardController;
        }

        //TowerElection kart'ın image'in görünürlüğünü ayarliyor.
        public void SetActiveImage(bool value)
        {
            image.enabled = value;
        }

        //TowerElection kart'ın image'nin sprite'nı atamasini yapiyor.
        public void SetSprite(Sprite sprite,Vector3 _pos)
        {
            pos = _pos;
            image.sprite = sprite;

            

        }


    }

}
