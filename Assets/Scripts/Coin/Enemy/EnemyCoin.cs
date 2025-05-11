using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EnemyCoin
{
    public class EnemyCoin : MonoBehaviour
    {
        
        [SerializeField] private int amount = 0;
        [SerializeField] private bool isStop = false;
        void Awake()
        {
           
            
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
           
        }

        void OnMouseDown()
        {
            // Coin sayısını artır
            GameManager.Instance.CoinIncrease(amount);

            // UI hedef pozisyonunu ekran pozisyonuna çevir
            Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(null, UIManager.Instance.EnemyCoinTargetPosition.transform.position);

            // Ekran pozisyonunu world pozisyonuna çevir
            Vector3 worldTargetPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, Camera.main.nearClipPlane + 5f));
            worldTargetPos.z = 0; // z eksenini sabitliyoruz (2D için)

            // Hareket başlat
            StartCoroutine(Movement(worldTargetPos));
        }

        public void SetAmount(int amount)
        {
            this.amount = amount;
        }

        public void EnemyCoinDestroy()
        {
            Destroy(gameObject);
        }

        public void SetEnemyCoinPosition(Transform targetPosition,Vector3 newPos)
        {
            transform.position = newPos;
            
        }

        private IEnumerator Movement(Vector3 targetPos)
        {
            while (Vector2.Distance(transform.position, targetPos) > 0.1f)
            {
                transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 5f);
                yield return null;
            }

            EnemyCoinDestroy();
        }


    }
}
