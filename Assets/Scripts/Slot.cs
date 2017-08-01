using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerDownHandler {//класс отвечающий за наши слоты
	public int slotNumber;
	public int activeSlotNumber;
	public Item item;
	public Blueprint blueprint;
	public SlotType slotType;
	public enum SlotType
	{
		bp,res,item
	}
	Image itemImage;
	Inventory inventory;
	Craft craft;
	SaveActiveSlotNumber saveslot;
	Text itemAmount;
	// Use this for initialization
	void Start () {
		activeSlotNumber = 0;
		itemAmount = gameObject.transform.GetChild (1).GetComponent<Text> ();
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory>(); 
		craft = GameObject.FindGameObjectWithTag ("Craft").GetComponent<Craft> ();
		itemImage = gameObject.transform.GetChild (0).GetComponent<Image> ();
		saveslot = GameObject.FindGameObjectWithTag ("ActiveSlot").GetComponent<SaveActiveSlotNumber> ();
	}
	
	// Update is called once per frame

	void Update () //тут мы отризовываем нужные нам свойства в зависимости от того что хранится в слоте
	{
		if (slotType == SlotType.bp) {
			if (craft.Blueprints [slotNumber - 25].blueprintName != null) {// -25 - это из-за того что слоты под блупринты и ресурсы находятся в окне крафта
				itemImage.enabled = true;
				itemImage.sprite = craft.Blueprints [slotNumber - 25].blueprintIcon;
			} else
				itemImage.enabled = false;
		}
		if (slotType == SlotType.res) {
			if (craft.Blueprints[slotNumber-25].blueprintName != null) {
				itemImage.enabled = true;
				itemImage.sprite = craft.Blueprints[slotNumber-25].blueprintIcon;
			} else {
				itemImage.enabled = false;
				itemAmount.enabled = false;
			}
		}
		if(slotType == SlotType.item)
		{
			if (inventory.Items [slotNumber].itemName != null) {
				itemImage.enabled = true;
				itemImage.sprite = inventory.Items [slotNumber].itemIcon;

				if (inventory.Items [slotNumber].itemType != Item.ItemType.Structure) {
					itemAmount.enabled = true;
					itemAmount.text = "" + inventory.Items [slotNumber].itemValue;
				} else {
					itemAmount.enabled = false;
					itemAmount.text = "0";
				}
			} else {
				itemImage.enabled = false;
				itemAmount.enabled = false;
			}
		}
	}

	public void addItemsinResources(int id,int slotnumber)
	{
		inventory.addItemInResources(id,slotnumber);
	}
	public void OnPointerDown(PointerEventData  data)//функция нажатия на слоты. если у нас в инвентаре находится еда - мы можем ее съесть(ресурсы не можем :))
	{//а при нажатии на чертеж мы отображаем ресурсы на его постройку в слоты под ресурсы
		craft.ReleaseResSlots();
		if (slotType == SlotType.bp)
		{
			activeSlotNumber = slotNumber - 25;
			saveslot.setslotnumber(activeSlotNumber);
			for (int i = 0; i < craft.Blueprints [slotNumber-25].ItemsToConsume.Count; i++) 
			{
				addItemsinResources (craft.Blueprints [slotNumber - 25].ItemsToConsume [i].itemID,slotNumber - 25);
			}
		}
		if (slotType == SlotType.item) {
			if (inventory.Items [slotNumber].itemType == Item.ItemType.Consumable) {
				inventory.Items [slotNumber].itemValue--;
				if (inventory.Items [slotNumber].itemValue == 0) {
					inventory.Items [slotNumber] = new Item ();
					itemAmount.enabled = false;
				}
			}
		}
		Debug.Log ("clicked");
	}
}
