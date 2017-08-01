using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveActiveSlotNumber : MonoBehaviour {//класс запоминающий позицию активного слота в блупринтах(запоминает при нажатии на слот с чертежом,значение отдается при нажатии кнопки крафта)
	static int activeSlotsnumber;
	// Use this for initialization
	void Start () {
		activeSlotsnumber = 0;
	}
	public void setslotnumber(int n)
	{
		activeSlotsnumber = n;
	}
	public int getslotnumber()
	{
		return	activeSlotsnumber;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
