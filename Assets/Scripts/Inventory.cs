using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour { //класс представляющий наш инвентарь
	public List<GameObject> Slots = new List<GameObject>();//Лист слотов который мы будем отображать

	public List<Blueprint> Blueprints = new List<Blueprint> ();//лист чертежей - он нужен для того чтобы взаимодействовать с окном крафта
	public List<Item> Items = new List<Item> ();//лист наших предметов которые в данный момент хранятся в инвентаре
	public GameObject slots;//префаб по которому рисуются слоты
	BlueprintDB Blueprintdb; 
	ItemsDB itemdb;			//доступ к базе данных чертежей и предметов которые есть в игре
	public int x = -110, y = 112;//позиция отрисовки слотов инвентаря
	// Use this for initialization
	void Start () {//получаем доступ ко всем нужным сущностям
		int slotFreeAmount = 0;
		Blueprints = GameObject.FindGameObjectWithTag ("Craft").GetComponent<Craft>().Blueprints;
		Blueprintdb = GameObject.FindGameObjectWithTag ("BlueprintDatabase").GetComponent<BlueprintDB>();
		itemdb = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent<ItemsDB>();
		for (int i = 1; i < 6; i++) //создаем и инициализируем 25 слотов. К каждому слоту присваиваем один предмет
		{
			for (int j = 1; j < 6; j++) 
			{
				GameObject slot = (GameObject)Instantiate (slots); 
				slot.GetComponent<Slot> ().slotNumber = slotFreeAmount;
				slot.GetComponent<Slot> ().slotType = Slot.SlotType.item;
				Slots.Add (slot);
				Items.Add (new Item ());
				slot.name = "slot " + ((j - 1) + (i-1) * 5);
				slot.transform.parent = this.gameObject.transform;
				slot.GetComponent<RectTransform> ().localPosition = new Vector3 (x, y, 0);
				x += 55;
				if (j == 5)
				{
					x = -110;
					y -= 55;
				}
				slotFreeAmount++;
			}
		}
			
		for (int i = 0; i < 20; i++)// добавялем предметы в инвентарь
			for (int j = 0; j < 13; j++)
				addItem (j);

	}

	public void checkIfItemExists(int itemID, Item item) //если предмет уже есть в инвентарь - просто прибавляем его значение
	{
		for (int i = 0; i < Items.Count; i++) 
		{
			if (Items [i].itemID == itemID) {
				Items [i].itemValue++;
				break;
			}
			else if(i == Items.Count - 1)
			{
				addItemAtFreeSlot(item);
			}	
		}
	}


		
	void addItemAtFreeResourceSlot(Item item,int slotnumber) //здесь мы в ресурсы добавляем именно предметы, а не чертежи
	{
		for (int i = 0; i < 5; i++) 
		{
			
			if (Blueprints[i+12].blueprintName == null && i<Blueprints[slotnumber].ItemsToConsume.Count ) 
			{
					
					Blueprints [i + 12].blueprintDesc = item.itemDesc;
					Blueprints [i + 12].blueprintIcon = item.itemIcon;
					Blueprints [i + 12].blueprintID = item.itemID;
					Blueprints [i + 12].blueprintName = item.itemName;
					
					if (Blueprints [slotnumber].ItemsToConsume [i].itemType == Item.ItemType.Consumable)
						Blueprints [i + 12].blueprintType = Blueprint.BlueprintType.Consumable;
					if (Blueprints [slotnumber].ItemsToConsume [i].itemType == Item.ItemType.Material)
						Blueprints [i + 12].blueprintType = Blueprint.BlueprintType.Material;
					if (Blueprints [slotnumber].ItemsToConsume [i].itemType == Item.ItemType.Structure)
						Blueprints [i + 12].blueprintType = Blueprint.BlueprintType.Structure;
					break;
			}
		}
	}
		
	public void addItemInResources(int id,int slotnumber) //добавляем предмет в свободный слот под ресурсы
	{
		for (int i = 0; i < itemdb.items.Count; i++) 
		{
			if (itemdb.items [i].itemID == id)//ищем нужный нам предмет из базы данных предметов
			{
				Item item = itemdb.items [i];
					addItemAtFreeResourceSlot(item,slotnumber);
			}
		}
	}
	public void addItem(int id)// функция добавления предмета в инвентарь
	{
		for (int i = 0; i < itemdb.items.Count; i++) 
		{
			if (itemdb.items [i].itemID == id)
			{
				Item item = itemdb.items [i];
				if (itemdb.items [i].itemType != Item.ItemType.Structure) //ищем предмет по базе данных и если предмет - строение , то его не суммируем
				{
					checkIfItemExists(id,item);
					break;
				} 
				else
				{
					addItemAtFreeSlot (item);
				}
			}
		}
	}
	void addItemAtFreeSlot(Item item)// непосредственно добавление предмета на пустое место
	{
		for (int i = 0; i < Items.Count; i++) 
		{
			if (Items [i].itemName == null) 
			{
				Items[i] = item;
				break;
			}
		}
	}
}
