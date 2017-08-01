using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintDB : MonoBehaviour { //база данных чертежей - к предметам добавляем ингридиенты

	public List<Blueprint> Blueprints = new List<Blueprint> ();
	List <Item> Items_to_consume = new List<Item>();

	ItemsDB itemdb; 
	// Use this for initialization

	void Start () {
		itemdb= GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent<ItemsDB>();
		Items_to_consume = new List<Item>();
		Items_to_consume.Add(itemdb.items[0]);
		Items_to_consume.Add(itemdb.items[0]);
		Items_to_consume.Add(itemdb.items[0]);
		Items_to_consume.Add(itemdb.items[1]);
		Items_to_consume.Add(itemdb.items[4]);
		Blueprints.Add (new Blueprint ("bonfire", 0, "bonfire", Blueprint.BlueprintType.Structure,1,Items_to_consume));

		Items_to_consume = new List<Item>();
		Items_to_consume.Add(itemdb.items[0]);
		Items_to_consume.Add(itemdb.items[0]);
		Items_to_consume.Add(itemdb.items[0]);
		Items_to_consume.Add(itemdb.items[0]);
		Items_to_consume.Add(itemdb.items[4]);
		Blueprints.Add (new Blueprint ("furnace", 1, "furance", Blueprint.BlueprintType.Structure,1,Items_to_consume));

		Items_to_consume = new List<Item>();
		Items_to_consume.Add(itemdb.items[5]);
		Items_to_consume.Add(itemdb.items[5]);
		Items_to_consume.Add(itemdb.items[5]);
		Items_to_consume.Add(itemdb.items[5]);
		Items_to_consume.Add(itemdb.items[5]);
		Blueprints.Add (new Blueprint ("straw_base", 2, "straw platform", Blueprint.BlueprintType.Structure,1,Items_to_consume));

		Items_to_consume = new List<Item>();
		Items_to_consume.Add(itemdb.items[5]);
		Items_to_consume.Add(itemdb.items[5]);
		Items_to_consume.Add(itemdb.items[5]);
		Blueprints.Add (new Blueprint ("straw_wall", 3, "straw wall", Blueprint.BlueprintType.Structure,1,Items_to_consume));

		Items_to_consume = new List<Item>();
		Items_to_consume.Add(itemdb.items[0]);
		Items_to_consume.Add(itemdb.items[0]);
		Blueprints.Add (new Blueprint ("wooden_door", 4, "wooden door", Blueprint.BlueprintType.Structure,1,Items_to_consume));

		Items_to_consume = new List<Item> ();
		Items_to_consume.Add(itemdb.items[0]);
		Items_to_consume.Add(itemdb.items[0]);
		Items_to_consume.Add(itemdb.items[0]);
		Blueprints.Add (new Blueprint ("wooden_wall", 5, "wooden wall", Blueprint.BlueprintType.Structure,1,Items_to_consume));
	
		Items_to_consume = new List<Item>();
		Items_to_consume.Add(itemdb.items[0]);
		Items_to_consume.Add(itemdb.items[0]);
		Items_to_consume.Add(itemdb.items[0]);
		Items_to_consume.Add(itemdb.items[0]);
		Blueprints.Add (new Blueprint ("wooden_base", 6, "wooden platform", Blueprint.BlueprintType.Structure,1,Items_to_consume));

		Items_to_consume = new List<Item>();
		Items_to_consume.Add(itemdb.items[0]);
		Items_to_consume.Add(itemdb.items[0]);
		Blueprints.Add (new Blueprint ("wooden_fence", 7, "wooden fence", Blueprint.BlueprintType.Structure,1,Items_to_consume));


		Items_to_consume = new List<Item>();
		Items_to_consume.Add(itemdb.items[2]);
		Items_to_consume.Add(itemdb.items[3]);
		Items_to_consume.Add(itemdb.items[4]);
		Items_to_consume.Add(itemdb.items[4]);
		Items_to_consume.Add(itemdb.items[4]);
		Blueprints.Add (new Blueprint ("workbench", 8, "workbench", Blueprint.BlueprintType.Structure,1,Items_to_consume));

		Items_to_consume = new List<Item>();
		Items_to_consume.Add(itemdb.items[3]);
		Blueprints.Add (new Blueprint ("metal_ingot", 9, "metal ignot", Blueprint.BlueprintType.Material,1,Items_to_consume));

		Items_to_consume = new List<Item>();
		Items_to_consume.Add(itemdb.items[7]);
		Blueprints.Add (new Blueprint ("flask", 10, "flask", Blueprint.BlueprintType.Consumable,1,Items_to_consume));

		Items_to_consume = new List<Item>();
		Items_to_consume.Add(itemdb.items[11]);
		Blueprints.Add (new Blueprint ("bottle", 11, "bottle", Blueprint.BlueprintType.Consumable,1,Items_to_consume));

		Items_to_consume = new List<Item>();
		Items_to_consume.Add(itemdb.items[9]);
		Blueprints.Add (new Blueprint ("fish_02", 12, "bottle", Blueprint.BlueprintType.Consumable,1,Items_to_consume));

		Items_to_consume = new List<Item>();
		Items_to_consume.Add(itemdb.items[10]);
		Blueprints.Add (new Blueprint ("fish_01", 13, "bottle", Blueprint.BlueprintType.Consumable,1,Items_to_consume));
	}
		
	// Update is called once per frame
	void Update () {

	}
}
