using System.Collections;
using System.Collections.Generic;
using Rewards.Enums;
using UnityEngine;

namespace Rewards
{
    public class ItemReward : MonoBehaviour
    {
        private string itemName;
        public string ItemName => itemName;

        private ItemRewardRarityEnum itemRewardRarity;
        public ItemRewardRarityEnum ItemRewardRarityEnum => itemRewardRarity;

        private ItemRewardType itemRewardType;
        public ItemRewardType ItemRewardType => itemRewardType;




        public void ItemRewardInitialize(string itemName,ItemRewardRarityEnum itemRewardRarity,ItemRewardType itemRewardType)
        {
            this.itemName = itemName;
            this.itemRewardRarity = itemRewardRarity;
            this.itemRewardType = itemRewardType;
            SetItemRewardName();
        }

        public void SetItemRewardName(string _itemName = "")
        {
            gameObject.name = _itemName == "" ? itemName : _itemName;
        }

    }

}
