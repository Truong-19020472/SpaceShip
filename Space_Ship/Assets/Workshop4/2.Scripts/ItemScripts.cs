using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScripts : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Button itemButton;
    [SerializeField] private GameObject selectLight;
    private string itemName;
    private InventoryItemType itemType;
    private string itemData;

    private int itemIndex;

    private void Start()
    {
        itemButton.onClick.AddListener(SelectItem);
        selectLight.SetActive(false);
        ItemController.instance.OnSelectItem += OnSelect;
    }
    public void SetDataToItem(int index, string name, InventoryItemType type, string data)
    {
        itemIndex = index;
        itemName = name;
        itemType = type;
        itemData = data;
        switch (itemType)
        {
            case InventoryItemType.LifeFlask:
                icon.sprite = Resources.Load<Sprite>("Shop/Life");
                break;
            case InventoryItemType.ManaFlask:
                icon.sprite = Resources.Load<Sprite>("Shop/PowerGreen");
                break;
            case InventoryItemType.Food:
                icon.sprite = Resources.Load<Sprite>("Shop/Food");
                break;
            case InventoryItemType.Dagger:
            case InventoryItemType.Sword:
                icon.sprite = Resources.Load<Sprite>("Shop/Weapon");
                break;
            case InventoryItemType.BodyArmour:
            case InventoryItemType.Gloves:
                icon.sprite = Resources.Load<Sprite>("Shop/BodyArmour");
                break;
        }
        if (itemIndex == 0)
        {
            StartCoroutine(AutoSelectItem());
        }
    }
    private IEnumerator AutoSelectItem()
    {
        yield return null;
        SelectItem();
    }
    private void SelectItem()
    {
        ItemController.instance.SelectItem(itemIndex, icon);
        selectLight.SetActive(true);
    }
    private void OnSelect(int selectedIndex)
    {
        if(itemIndex != selectedIndex)
        {
            selectLight.SetActive(false);
        }
    }
}
