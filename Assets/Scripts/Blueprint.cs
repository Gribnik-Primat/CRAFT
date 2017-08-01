using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blueprint : MonoBehaviour {//изначальный класс блупринта - отличается от класса предмета наличием листа предметов - это наш рецепт
	public string blueprintName;
	public int blueprintID;
	public string blueprintDesc;
	public Sprite blueprintIcon;
	public BlueprintType blueprintType;
	public List<Item> ItemsToConsume; //наш рецепт

	public enum BlueprintType
	{
		Consumable, Structure, Material
	}

	public Blueprint ()
	{

	}
	public Blueprint(string name, int id, string desc,BlueprintType type,int value,List<Item>itemsToConsume)
	{
		blueprintName = name;
		blueprintID = id;
		blueprintDesc = desc;
		blueprintType = type;
		ItemsToConsume = new List<Item>(itemsToConsume);
		for (int i = 0; i < itemsToConsume.Count; i++)
			ItemsToConsume [i] = itemsToConsume [i]; 
		switch(type)
		{
		case BlueprintType.Consumable: 
			blueprintIcon = Resources.Load<Sprite> ("Items/consumables/" + name);
			break;
		case BlueprintType.Structure: 
			blueprintIcon = Resources.Load<Sprite>("Items/structures/" + name);
			break;
		case BlueprintType.Material: 
			blueprintIcon = Resources.Load<Sprite>("Items/materials/" + name);
			break;
		}	
	}
}
