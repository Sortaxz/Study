using System;
using Rewards;
using Rewards.Enums;
using UnityEngine;

public class RewardController 
{
    public EssenceReward EssenceRewardCreate(EssenceNameEnum essenceName)
    {
        GameObject essencePrefab = Resources.Load<GameObject>($"Rewards/EssenceRewards/{essenceName}");
        
        EssenceReward essenceRewardObject = GameObject.Instantiate(essencePrefab)?.GetComponent<EssenceReward>();
        
        essenceRewardObject.EssenceRewardInitialize(essenceName.ToString(),EssenceRewardRarityEnum.Ordinary,EssenceRewardType.Attack,300);
        
        Console.WriteLine(essenceRewardObject.EssenceName + " - " + essenceRewardObject.EssenceRewardRarity + " - " + essenceRewardObject.EssenceRewardType + " - " + essenceRewardObject.EssenceXP);
        
        return essenceRewardObject;
    }

    public ItemReward ItemRewardCreate(ItemNameEnum itemName)
    {

        GameObject itemPrefab = Resources.Load<GameObject>($"Rewards/ItemRewards/{itemName}");

        ItemReward itemRewardObject = GameObject.Instantiate(itemPrefab)?.GetComponent<ItemReward>();
        
        itemRewardObject.ItemRewardInitialize(itemName.ToString(),ItemRewardRarityEnum.Rare,ItemRewardType.Defense);

        Console.WriteLine(itemRewardObject.ItemName + " - " + itemRewardObject.ItemRewardRarityEnum + " - " + itemRewardObject.ItemRewardType );


        return itemRewardObject;

    }

}
