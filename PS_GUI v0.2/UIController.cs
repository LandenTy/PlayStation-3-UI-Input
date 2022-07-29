using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIController : MonoBehaviour {

	public string upAxis;
	public string downAxis;
	public string confirmButton;

	private bool isUp = false;
	private bool isDown = false;

	[HideInInspector] public int itemIndex = 0;
	public List<ButtonController> buttonList = new List<ButtonController>();
	public string currentlySelected;

	void Start()
	{
		currentlySelected = buttonList [itemIndex].name;
	}

	void Update()
	{
		ItemSelection ();
		ConfirmSelection ();
	}

	public void ItemSelection()
	{
		if ((!isUp) && (Input.GetAxisRaw(upAxis) == 1))
		{
			isUp = true;
			this.CallWithDelay (LastItem, 0.2f);
		}

		if ((!isDown)  && (Input.GetAxisRaw(downAxis) == 1))
		{
			isDown = true;
			this.CallWithDelay (NextItem, 0.2f);
		}
	}

	public void LastItem()
	{
		if ((isUp) && (Input.GetAxisRaw(upAxis) == 0))
		{
			if (itemIndex > 0)
			{
				isUp = false;

				itemIndex -= 1;
				currentlySelected = buttonList [itemIndex].name;

				SetButtonColor ();
			}
			else
			{
				isUp = false;
			}
		}
	}

	public void NextItem()
	{
		if ((isDown) && (Input.GetAxisRaw(downAxis) == 0))
		{
			if (itemIndex + 1 < buttonList.Count)
			{
				isDown = false;

				itemIndex += 1;
				currentlySelected = buttonList [itemIndex].name;

				SetButtonColor ();
			}
			else
			{
				isDown = false;
			}
		}
	}

	public void ConfirmSelection()
	{
		if (Input.GetButtonUp(confirmButton))
		{
			buttonList [itemIndex].OnButtonClicked (itemIndex + 1);
		}
	}

	public void SetButtonColor()
	{
		for (int i = 0; i < buttonList.Count; i++) {
			buttonList [i].image.color = buttonList [i].notSelected;
		}

		buttonList [itemIndex].OnButtonHovered (itemIndex + 1);
	}
}