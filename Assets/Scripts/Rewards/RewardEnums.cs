
using System;

namespace Rewards.Enums
{
    #region  Item Reward

    [Serializable]
    public enum ItemNameEnum
    {
        ItemReward_1,ItemReward_2,ItemReward_3,ItemReward_4,ItemReward_5,ItemReward_6,ItemReward_7
    }

    [Serializable]
    public enum ItemRewardRarityEnum
    {
        Ordinary,Rare,Epic,Legendary
    }

    [Serializable]
    public enum ItemRewardType
    {
        Attack,Mage,Defense,Kritik_Attack
    }


    #endregion


    #region  Essence Reward

    [Serializable]
    public enum EssenceNameEnum
    {
        EssenceReward_1,EssenceReward_2,EssenceReward_3,EssenceReward_4,EssenceReward_5,EssenceReward_6,EssenceReward_7
    }


    [Serializable]
    public enum EssenceRewardRarityEnum
    {
        Ordinary,Rare,Epic,Legendary
    }
    

    [Serializable]
    public enum EssenceRewardType
    {
        Attack,Fire,Ice
    }

    #endregion


}
