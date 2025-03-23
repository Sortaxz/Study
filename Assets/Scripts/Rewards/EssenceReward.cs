using System.Collections;
using System.Collections.Generic;
using Rewards.Enums;
using UnityEngine;

namespace Rewards
{
    public class EssenceReward : MonoBehaviour
    {
        private string essenceName;
        public string EssenceName => essenceName;

        private EssenceRewardRarityEnum _essenceRewardRarity;
        public EssenceRewardRarityEnum EssenceRewardRarity => _essenceRewardRarity;
        
        private EssenceRewardType essenceRewardType;
        public EssenceRewardType EssenceRewardType => essenceRewardType;

        private int essenceXP;
        public int EssenceXP => essenceXP;

        public void EssenceRewardInitialize(string essenceName,EssenceRewardRarityEnum essenceRewardRarity,EssenceRewardType essenceRewardType,int essenceXP)
        {
            this.essenceName = essenceName;
            _essenceRewardRarity = essenceRewardRarity;
            this.essenceRewardType = essenceRewardType;
            this.essenceXP = essenceXP;

            SetEssenceRewardName();
        }

        public void SetEssenceRewardName(string _essenceName = "")
        {
            gameObject.name = _essenceName == "" ? essenceName : _essenceName;
        }

    }

}

