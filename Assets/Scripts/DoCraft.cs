using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoCraft : MonoBehaviour {//класс отвечающий непосредственно за крафт
	 List<Blueprint> Blueprints = new List<Blueprint> ();
    List<Item> Items = new List<Item> ();
	int activeslotsnumber = 0;
	Inventory inventory;
	ItemsDB itemdb;


	// Use this for initialization
	void Start () {
		activeslotsnumber = GameObject.FindGameObjectWithTag("ActiveSlot").GetComponent<SaveActiveSlotNumber>().getslotnumber();
		Blueprints = GameObject.FindGameObjectWithTag ("Craft").GetComponent<Craft>().Blueprints;
		Items = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ().Items;
		itemdb = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent<ItemsDB>();
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory>(); 
	}



	public void CraftMeItem()
	{
		activeslotsnumber = GameObject.FindGameObjectWithTag("ActiveSlot").GetComponent<SaveActiveSlotNumber>().getslotnumber();
		int itemquantityinres = 0;
		int countinres=0;
		if (Blueprints [12].blueprintName != null)
		{

			for(int j = 0;j<5;j++)
				for (int i = 0; i < Items.Count; i++) //идем по предметам
				{
					if (Items [i].itemID == Blueprints [12 + j].blueprintID)//если встретили в инвентаре необходимый нам предмет который есть в ресурсах
					{
						for (int k = countinres; k < 5; k++)
						{
							if (Blueprints [12 + countinres].blueprintID == 0)
								break;
							if (Blueprints [12 + countinres].blueprintID == Blueprints [12 + k].blueprintID)
								itemquantityinres++;//считаем необходимое количество предметов в ресурсах			
						}
						if (Blueprints [activeslotsnumber].ItemsToConsume.Count > countinres || itemquantityinres != 0)
						{
							if (Items [i].itemValue >= itemquantityinres) {// сравниваем с тем количеством предметов которое есть в инвентаре, если не хватает - пишем что не хватает
								for (int a = j; a < j + itemquantityinres; a++)
								{
									//Blueprints [12 + a].blueprintName = null;//убираем ресурс
									Items [i].itemValue--; // убираем предмет
									if (Items [i].itemValue == 0)// если предметов не осталось - обнуляем ячейку
									Items [i].itemName = null;
									
								}
								//считываем позицию на которой находимся в ресурсах и передаем в j 
								countinres += itemquantityinres;
								j = countinres-1;
								itemquantityinres = 0;
								break;
							} else {
								Debug.Log ("Insufficient Resources");
								return;
							}
						} else
							break;
					} 
				}	
			}

		int id = itemdb.FindIdOfItemThroughBlueprint (Blueprints [activeslotsnumber].blueprintName);//если все нормально и ресурсов достаточно - ищем id предмета который надо создать принимая на вход имя активного сейчас чертежа
		inventory.addItem (id);//добавляем созданный предмет в инвентарь


	}

	// Update is called once per frame
	void Update () {
		
	}
}
