using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateInventory : MonoBehaviour
{
    [SerializeField] private Button insertItem;
    [SerializeField] private Button genJson;
    [SerializeField] private Button retrieveData;
    [SerializeField] private Text text2, text3, text4, text5;
    [SerializeField] private TMP_Dropdown itemType;
    [SerializeField] private TMP_Dropdown rarityItem;
    [SerializeField] private TMP_InputField input1, input2, input3, input_Name;

    InventoryItemList items = new InventoryItemList();
    InventoryItem currentItem;
    InventoryItemType currentItemType = InventoryItemType.LifeFlask;

    private void Start()
    {
        insertItem.onClick.AddListener(InsertItem);
        genJson.onClick.AddListener(GenJson);
        retrieveData.onClick.AddListener(RetrieveData);
        itemType.onValueChanged.AddListener(OnItemTypeChange);
    }
    private void OnItemTypeChange(int value)
    {
        switch (value)
        {
            //0, 1, 2 là food, mana, hp => consumableItem
            case 0:
            case 1:
            case 2:
                text2.text = "Item Tier";
                text3.text = "Stack Quantity";
                text4.text = "Quantity";
                text5.gameObject.SetActive(false);
                rarityItem.gameObject.SetActive(false);
                break;
            case 3:
            case 4:
                //3,4 là Weapon như sword: dam, level, độ bền, độ hiếm
                text2.text = "Damage";
                text3.text = "Level";
                text4.text = "Durability";
                text5.gameObject.SetActive(false);
                rarityItem.gameObject.SetActive(true);
                break;

            case 5:
            case 6:
                //giáp
                text2.text = "AmourValue";
                text3.text = "Level";
                text4.text = "Durability";
                text5.gameObject.SetActive(false);
                rarityItem.gameObject.SetActive(true);
                break;
            default:
                break;
        }
        currentItemType = (InventoryItemType)value + 1;//vì value của onchange bắt đầu từ không nhưng enum nhỏ nhất là lifeFlask lại là 1
    }
    private void InsertItem()
    {
        currentItem = new InventoryItem();

        currentItem.ItemName = input_Name.text;
        currentItem.ItemType = currentItemType;

        switch (currentItemType)
        {
            case InventoryItemType.LifeFlask:
                LifeFlask tempLifeFlask = new LifeFlask();
                tempLifeFlask.ItemTier = int.Parse(input1.text);
                tempLifeFlask.StackQuantity = int.Parse(input2.text);
                tempLifeFlask.Quantity = int.Parse(input3.text);

                currentItem.ItemData = JsonUtility.ToJson(tempLifeFlask);
                break;
            case InventoryItemType.ManaFlask:
                ManaFlask tempManaFlask = new ManaFlask();
                tempManaFlask.ItemTier = int.Parse(input1.text);
                tempManaFlask.StackQuantity = int.Parse(input2.text);
                tempManaFlask.Quantity = int.Parse(input3.text);

                currentItem.ItemData = JsonUtility.ToJson(tempManaFlask);
                break;
            case InventoryItemType.Food:
                Food tempFood = new Food();
                tempFood.ItemTier = int.Parse(input1.text);
                tempFood.StackQuantity = int.Parse(input2.text);
                tempFood.Quantity = int.Parse(input3.text);

                currentItem.ItemData = JsonUtility.ToJson(tempFood);
                break;
            case InventoryItemType.Sword:
            case InventoryItemType.Dagger:
                Weapon tempWeapon = new Weapon();
                tempWeapon.damage = int.Parse(input1.text);
                tempWeapon.level = int.Parse(input2.text);
                tempWeapon.durability = int.Parse(input3.text);
                tempWeapon.rarity = (RarityItem)rarityItem.value;
                currentItem.ItemData = JsonUtility.ToJson(tempWeapon);
                break;
            case InventoryItemType.BodyArmour:
            case InventoryItemType.Gloves:
                ArmourItem tempArmour = new ArmourItem();
                tempArmour.armourValue = int.Parse(input1.text);
                tempArmour.level = int.Parse(input2.text);
                tempArmour.durability = int.Parse(input3.text);
                tempArmour.rarity = (RarityItem)rarityItem.value;
                currentItem.ItemData = JsonUtility.ToJson(tempArmour);
                break;
            default:
                break;
        }
        items.ItemList.Add(currentItem);
        //Debug.LogError(currentItem.ItemData);
    }
    private void GenJson()
    {
        Debug.LogError(JsonUtility.ToJson(items));
        SaveDataToPersistent("InventoryItemShop", JsonUtility.ToJson(items));
        
    }
    private void SaveDataToPersistent(string filename, string dataString)
    {
        string dataPath = $"{Application.persistentDataPath}/{filename}.txt";
        new System.Threading.Thread(() =>
        {
            File.WriteAllText(dataPath, dataString);
        }
        ).Start();
    }
    private void RetrieveData()
    {
        string dataString = ReadDataFromText("InventoryItemShop");
        if(dataString !="")
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
}

