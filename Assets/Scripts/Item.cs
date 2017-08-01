using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour { // наш базовый класс для любого предмета. содержит все необходимые предмету свойства

	public string itemName;
	public int itemID;
	public string itemDesc;
	public Sprite itemIcon;
	public ItemType itemType;
	public int itemValue;

	public enum ItemType
	{
		Consumable, Structure, Material
	}

	public Item ()
	{
		
	}
	public Item(string name, int id, string desc,ItemType type,int value)// конструктор
	{
		itemName = name;
		itemID = id;
		itemDesc = desc;
		itemType = type;
		itemValue = value;
		switch(type)
		{
		case ItemType.Consumable: 
			itemIcon = Resources.Load<Sprite> ("Items/consumables/" + name);
			break;
		case ItemType.Structure: 
			itemIcon = Resources.Load<Sprite> ("Items/structures/" + name);
			break;
		case ItemType.Material: 
			itemIcon = Resources.Load<Sprite> ("Items/materials/" + name);
			break;
		}	
	}
}
