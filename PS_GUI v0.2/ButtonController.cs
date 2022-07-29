using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour {

	public Color32 notSelected;
	public Color32 isSelected;
	public Color32 isHovering;
	public int id;

	[Space(10)]
	public UnityEvent onClickEvent;

	[HideInInspector] public Image image;

	void Start()
	{
		image = GetComponent<Image> ();
		Init ();
	}

	private void Init()
	{
		if (id == 1)
		{
			image.color = isHovering;
		}
	}

	public void OnButtonClicked(int id)
	{
		if (id == this.id)
		{
			image.color = isSelected;
			onClickEvent.Invoke ();
		}
	}

	public void OnButtonHovered(int id)
	{
		if (id == this.id)
		{
			image.color = isHovering;
		}
		else
		{
			image.color = notSelected;
		}
	}
}
