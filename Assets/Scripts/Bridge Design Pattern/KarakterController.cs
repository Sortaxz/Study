using System.Collections;
using System.Collections.Generic;
using BridgeDesignPatter;
using KarakterEnums;
using UnityEngine;

public class KarakterController : MonoBehaviour
{
    [SerializeField] private KarakterType karakterType;
    [SerializeField] private Karakter karakter;
    void Awake()
    {
        switch (karakterType)
        {
            case KarakterType.Mage:
                karakter = KarakterCreator.CreateKarakter(new MagicAttack());
            break;
            case KarakterType.Warrior:
                karakter = KarakterCreator.CreateKarakter(new MeleeAttack());
            break;
            default:
            break;
        }
        karakter.CharacterAttack();
    }
}
