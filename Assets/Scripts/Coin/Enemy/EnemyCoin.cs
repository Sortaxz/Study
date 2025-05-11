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
            UIManager.Instance.BalanceOperationsUIControl.SetCoinText(amount);
            StartCoroutine(Movement(new Vector3(10.44f,5.04f)));
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
            float distance = 0;
            while(!isStop)
            {
                distance = Vector2.Distance(transform.position,targetPos);
                if(distance <.5f)
                {
                    break;
                }
                transform.position = Vector3.Lerp(transform.position,targetPos,Time.deltaTime * 1f);
                yield return null;
            }
            EnemyCoinDestroy();
        }
        

    }
}
