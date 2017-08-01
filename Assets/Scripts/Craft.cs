using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Craft: MonoBehaviour {//класспредставляющий наше крафтовое окно
	public List<GameObject> Slots = new List<GameObject>();

	public List<Blueprint> Blueprints = new List<Blueprint> ();
	public GameObject slots;
	static BlueprintDB Blueprintdb;
	ItemsDB itemdb;
	int addedcount = 0;
	public int x = -81, y = 112;
	public int x1 = -60, y1 = -95;
	// Use this for initialization
	void Start () {
		drawslotsBp ();
	}
	void drawslotsBp()
	{
		x = -81; y = 112;
		x1 = -100; y1 = -95;
		Slots.Clear();
		Blueprints.Clear();
		int slotFreeAmount = 25;//почему 25? потому что все слоты представлены одним листом и поэтому чтобы создать новые слоты необходимо начать с той позиции в которой заканчивается инвентарь
		Blueprintdb = GameObject.FindGameObjectWithTag ("BlueprintDatabase").GetComponent<BlueprintDB>();
		itemdb = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent<ItemsDB>();
		for (int i = 1; i < 4; i++) // создаем 12 слотов под наше чертежи и приписываем к каждому слоты чертеж
		{
			for (int j = 1; j < 5; j++) 
			{
				GameObject slot = (GameObject)Instantiate (slots);
				slot.GetComponent<Slot> ().slotNumber = slotFreeAmount;
				slot.GetComponentInChildren<Text> ().enabled = false;
				slot.GetComponent<Slot> ().slotType = Slot.SlotType.bp;
				Slots.Add (slot);
				Blueprints.Add (new Blueprint ());
				slot.name = "slotbp " + ((j - 1)+ 4 *(i-1));
				slot.transform.parent = this.gameObject.transform;
				slot.GetComponent<RectTransform> ().localPosition = new Vector3 (x, y, 0);
				x += 55;
				if (j == 4) {
					x = -81;
					y -= 55;
				}
				slotFreeAmount++;
			}
		}

		for (int j = 1; j < 6; j++) //а здесь мы создаем 5 слотов под ресурсы - итого 37 слотов
		{
			GameObject slot = (GameObject)Instantiate (slots); 
			slot.GetComponent<Slot> ().slotNumber = slotFreeAmount;
			slot.GetComponentInChildren<Text>().enabled = false;
			slot.GetComponent<Slot> ().slotType = Slot.SlotType.res;
			Slots.Add (slot);
			Blueprints.Add (new Blueprint ());
			slot.name = "slotres " + ((j - 1));
			slot.transform.parent = this.gameObject.transform;
			slot.GetComponent<RectTransform> ().localPosition = new Vector3 (x1, y1, 0);
			x1 += 55;
			slotFreeAmount++;
		}
	}


	public void ReleaseResSlots ()//функция освобождения слотов от предметов
	{
		for (int i = 0; i < 5; i++) 
		{
			Blueprints [i + 12].blueprintName = null;
		}
	}

	public void ReleaseBpSlots ()//функция освобождения слотов от предметов
	{
		for (int i = 0; i < 12; i++)
		{
			Blueprints [i].blueprintName = null;
		}
	}
	public void addBlueprintAtExactSpot(Blueprint blueprint,int index)//добавление чертежа на конкретную позицию в первых 12ти слотах крафтового окна
	{
		Blueprints[index] = blueprint;
	}

	public void ShowUsStructureBp()// функции отрисовок блупринтов в слоты по нажатию кнопок
	{
		drawslotsBp ();
		GameObject.FindGameObjectWithTag ("StructureButton").GetComponent<Button> ().interactable = false;
		GameObject.FindGameObjectWithTag ("MaterialButton").GetComponent<Button> ().interactable = true;
		GameObject.FindGameObjectWithTag ("ConsumableButton").GetComponent<Button> ().interactable = true;
		ReleaseBpSlots ();
		ReleaseResSlots ();
		addedcount = 0;
		for (int i = 0; i < 13; i++)
		{			
			if (Blueprintdb.Blueprints [i].blueprintType == Blueprint.BlueprintType.Structure) 
			{
				addBlueprintAtExactSpot (Blueprintdb.Blueprints [i], addedcount);
				addedcount++;
			}
		}
	}
	public void ShowUsmaterialBp()
	{
		drawslotsBp ();
		GameObject.FindGameObjectWithTag ("StructureButton").GetComponent<Button> ().interactable = true;
		GameObject.FindGameObjectWithTag ("MaterialButton").GetComponent<Button> ().interactable = false;
		GameObject.FindGameObjectWithTag ("ConsumableButton").GetComponent<Button> ().interactable = true;
		ReleaseBpSlots ();
		ReleaseResSlots ();
		addedcount = 0;
		for (int i = 0; i < 13; i++)
		{
			if (Blueprintdb.Blueprints [i].blueprintType == Blueprint.BlueprintType.Material)
			{
				addBlueprintAtExactSpot (Blueprintdb.Blueprints [i], addedcount);
				addedcount++;
			}
		}
	}
	public void ShowUsConsumableBp()
	{
		drawslotsBp ();
		GameObject.FindGameObjectWithTag ("StructureButton").GetComponent<Button> ().interactable = true;
		GameObject.FindGameObjectWithTag ("MaterialButton").GetComponent<Button> ().interactable = true;
		GameObject.FindGameObjectWithTag ("ConsumableButton").GetComponent<Button> ().interactable = false;
		ReleaseBpSlots ();
		ReleaseResSlots ();
		addedcount = 0;
		for (int i = 0; i < 13; i++)
		{
			if (Blueprintdb.Blueprints [i].blueprintType == Blueprint.BlueprintType.Consumable)
			{
				addBlueprintAtExactSpot (Blueprintdb.Blueprints [i], addedcount);
			addedcount++;
			}
		}
	}

}
