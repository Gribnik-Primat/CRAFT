using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDB : MonoBehaviour { //класс в котором хранится база данных по предметам которые имеются в игре

	public List<Item> items = new List<Item> ();

	// Use this for initialization
	void Start () {
		items.Add (new Item ("wood", 1, "wood", Item.ItemType.Material,1));
		items.Add (new Item ("cloth", 2, "cloth", Item.ItemType.Material,1));
		items.Add (new Item ("metal_ingot", 3, "metal ignot", Item.ItemType.Material,1));
		items.Add (new Item ("metal_ore", 4, "metal ore", Item.ItemType.Material,1));
		items.Add (new Item ("stone", 5, "stone", Item.ItemType.Material,1));
		items.Add (new Item ("cane", 6, "cane", Item.ItemType.Material,1));

		items.Add (new Item ("bandage", 7, "bandage", Item.ItemType.Consumable,1));
		items.Add (new Item ("bottle", 8, "bottle of watter", Item.ItemType.Consumable,1));
		items.Add (new Item ("canned", 9, "can of food", Item.ItemType.Consumable,1));
		items.Add (new Item ("fish_01", 10, "fish 1", Item.ItemType.Consumable,1));
		items.Add (new Item ("fish_02", 11, "fish 2", Item.ItemType.Consumable,1));
		items.Add (new Item ("flask", 12, "flask", Item.ItemType.Consumable,1));

		items.Add (new Item ("bonfire", 13, "bonfire", Item.ItemType.Structure,1));
		items.Add (new Item ("furnace", 14, "furnance", Item.ItemType.Structure,1));
		items.Add (new Item ("straw_base", 15, "straw platform", Item.ItemType.Structure,1));
		items.Add (new Item ("straw_wall", 16, "straw wall", Item.ItemType.Structure,1));
		items.Add (new Item ("wooden_base", 17, "wooden platform", Item.ItemType.Structure,1));
		items.Add (new Item ("wooden_door", 18, "wooden door", Item.ItemType.Structure,1));
		items.Add (new Item ("wooden_fence", 19, "wooden fence", Item.ItemType.Structure,1));
		items.Add (new Item ("wooden_wall", 21, "wooden wall", Item.ItemType.Structure,1));
		items.Add (new Item ("workbench", 22, "workbench", Item.ItemType.Structure,1));
	}

	public int FindIdOfItemThroughBlueprint(string name)// специальная функция для поиска предмета который нужно вставить в инветарь при создании предмета
	{
		for (int i = 0;i< items.Count;i++) 
		{
			if (items[i].itemName == name)
				return items[i].itemID;
		}
		return -1;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
