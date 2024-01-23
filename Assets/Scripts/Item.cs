using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
   
    public ItemData itemData;
    public int level;
    public Weapon weapon;

    Image icon;
    Text textLevel;

     void Awake()
    {
        icon = GetComponentInChildren<Image>();
        icon.sprite = itemData.itemIcon;

        Text[] texts = GetComponentsInChildren<Text>();
        textLevel = texts[0];
    }

    void LateUpdate()
    {
        textLevel.text = "Lv." + (level + 1);
    }

    public void OnClick()
    {
        switch(itemData.itemType)
        {
            case ItemData.ItemType.Melee:
                break;
            case ItemData.ItemType.Range:
                break;
            case ItemData.ItemType.Glove: 
                break;
            case ItemData.ItemType.Shoe:
                break;
            case ItemData.ItemType.Heal: 
                break;
        }
        level++;

        if (level == itemData.damages.Length)   //itemData의 레벨 값보다 넘는 경우 방지
        {
            GetComponent<Button>().interactable = false;
        }
    }
}
