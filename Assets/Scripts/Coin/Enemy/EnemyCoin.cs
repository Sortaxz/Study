using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EnemyCoin
{
    public class EnemyCoin : MonoBehaviour
    {
        private Button button;
        [SerializeField] private int amount = 0;

        void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(delegate
            {
                print("çalişiyor");
            });
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetAmount(int amount)
        {
            this.amount = amount;
        }

    }
}
