using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private ItemScripts prefab;
    [SerializeField] private Text info;
    [SerializeField] private Image selectedItem;
    [SerializeField] private Button sell, upgrade;
    [SerializeField] private Button testValueButton;
    private ItemScripts currentSpawnedItem;

    public static ItemController instance;
    public Action<int> OnSelectItem;
    private void Awake()
    {
        instance = this;

    }
    public void SelectItem(int itemIndex, Image itemSelect)
    {
        if(OnSelectItem != null)
        {
            OnSelectItem(itemIndex);
        }
        selectedItem.sprite = itemSelect.sprite;
        //info.text = string.Format($"{items.ItemList[itemIndex].ItemName}\n{items.ItemList[itemIndex].ItemType}");
        InventoryItemType selectedItemType = items.ItemList[itemIndex].ItemType;
        switch (selectedItemType)
        {
            case InventoryItemType.LifeFlask:
            case InventoryItemType.ManaFlask:
            case InventoryItemType.Food:
                ConsumableItem consumableItem = JsonUtility.FromJson<ConsumableItem>(items.ItemList[itemIndex].ItemData);
                info.text = string.Format($"{items.ItemList[itemIndex].ItemName}\n" +
                    $"Item Tier: {consumableItem.ItemTier}\nQuantity: {consumableItem.Quantity}/{consumableItem.StackQuantity}");

                //upgrade.onClick.AddListener(() => { UpgradeConsumableItem(itemIndex, consumableItem); });
                break;
            case InventoryItemType.Dagger:
            case InventoryItemType.Sword:
                Weapon weapon = JsonUtility.FromJson<Weapon>(items.ItemList[itemIndex].ItemData);
               info.text = string.Format($"{items.ItemList[itemIndex].ItemName}\n" +
                    $"Damage: {weapon.damage}\nLevel: {weapon.level}\nItemRarity: {weapon.rarity}\nDurability: {weapon.durability}");
                //upgrade.onClick.AddListener(() => { UpgradeWeaponItem(itemIndex, weapon); });
                break;
            case InventoryItemType.BodyArmour:
            case InventoryItemType.Gloves:
                ArmourItem armourItem = JsonUtility.FromJson<ArmourItem>(items.ItemList[itemIndex].ItemData);
                info.text = string.Format($"{items.ItemList[itemIndex].ItemName}\n" +
                    $"Armour: {armourItem.armourValue}\nLevel: {armourItem.level}\nItemRarity: {armourItem.rarity}\nDurability: {armourItem.durability}");
                //upgradeButton.onClick.AddListener(() => { UpgradeArmourItem(itemIndex, armourItem); });
                break;
        }
    }
    private void Start()
    {
        RetrieveData();
        for(int i = 0; i < items.ItemList.Count; i ++)
        {
            Debug.Log(items.ItemList[i].ItemType);
            currentSpawnedItem = Instantiate(prefab, content);
            currentSpawnedItem.SetDataToItem(i, items.ItemList[i].ItemName, items.ItemList[i].ItemType, items.ItemList[i].ItemData);
        }
        testValueButton.onClick.AddListener(GetDamageOfWeapon);
    }
    /*#region MODIFY INVENTORY ITEM
    private void SellItem()
    {
        items.ItemList.RemoveAt(currentSelectItemIndex);
        SaveData(JsonUtility.ToJson(items));

        foreach (Transform item in content)
        {
            SimplePool.Despawn(item.gameObject);
        }
        SpawnListItems();
    }

    private void UpgradeConsumableItem(int itemIndex, ConsumableItem consumableItem)
    {
        consumableItem.ItemTier++;

        items.ItemList[itemIndex].ItemData = JsonUtility.ToJson(consumableItem);
        SaveData(JsonUtility.ToJson(items));

        SelectItem(itemIndex, itemIcon.sprite);
    }
    private void UpgradeWeaponItem(int itemIndex, Weapon weapon)
    {
        weapon.Level++;
        items.ItemList[itemIndex].ItemData = JsonUtility.ToJson(weapon);
        SaveData(JsonUtility.ToJson(items));

        SelectItem(itemIndex, itemIcon.sprite);
    }
    private void UpgradeArmourItem(int itemIndex, ArmourItem armourItem)
    {
        armourItem.Level++;
        items.ItemList[itemIndex].ItemData = JsonUtility.ToJson(armourItem);
        SaveData(JsonUtility.ToJson(items));

        SelectItem(itemIndex, itemIcon.sprite);
    }
    #endregion MODIFY INVENTORY ITEM*/
    #region Load Data
    InventoryItemList items = new InventoryItemList();
    private void RetrieveData()
    {
        string dataString = ReadDataFromText("InventoryItemShop");
        if (dataString != "")
        {
            items = JsonUtility.FromJson<InventoryItemList>(dataString);

        }
        else
        {
            items = new InventoryItemList();
        }
    }
    private string ReadDataFromText(string filename)
    {
        string path = $"{Application.persistentDataPath}/{filename}.txt";
        if (File.Exists(path))
        {
            return File.ReadAllText(path);
        }
        else
        {
            return "";
        }
    }
    #endregion Load Data
    #region SCRIPTABLE OBJECT DATA
    [SerializeField] private StartItemConfig statConfigData;

    private void GetDamageOfWeapon()
    {
        //Debug.LogError($"{RarityItem.magic}: {statConfigData.weaponConfigs[RarityItem.magic].DamageValue(15, RarityItem.magic)}");
    }
    #endregion SCRIPTABLE OBJECT DATA

}
