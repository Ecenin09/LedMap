using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollTabs : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
	[SerializeField] private Scrollbar scrollbar;
	[Range(0, 2)] public int tabIndex;
	[SerializeField] private int direction;
	[SerializeField] private float snapSpeed = 0.05f;
	private bool isDragging;
	private float threshold = 50;
	private float dragPosition;
	[SerializeField] private int dragIntention;
	[SerializeField] private bool dragConfirmed;

	private float ScrollbarValue
	{
		get
		{
			return tabIndex / 2f;
		}
	}

	void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
	{
		direction = Math.Sign(eventData.delta.x);
		isDragging = true;
		dragPosition = eventData.pressPosition.x;
		dragIntention = 0;
		dragConfirmed = false;
	}

	void IDragHandler.OnDrag(PointerEventData eventData)
	{
		if (Math.Sign(eventData.delta.x) != direction)
		{
			direction = Math.Sign(eventData.delta.x);
			dragConfirmed = false;
			dragPosition = eventData.position.x;
		}

		if (!dragConfirmed && Mathf.Abs(eventData.position.x - dragPosition) > threshold)
		{
			dragIntention += -direction;
			dragConfirmed = true;
		}
	}

	void IEndDragHandler.OnEndDrag(PointerEventData eventData)
	{
		tabIndex = Mathf.Clamp(tabIndex + dragIntention, 0, 2);
		isDragging = false;
	}

	private void Update()
	{
		if (!isDragging)
		{
			var delta = Mathf.SmoothStep(scrollbar.value, ScrollbarValue, 0.5f) - scrollbar.value;
			delta = Mathf.Clamp(delta, -snapSpeed, snapSpeed);
			scrollbar.value += delta;
		}
	}

	public void ChangeTab(int index)
	{
		if (index >= 0 && index <= 2)
		{
			tabIndex = index;
		}
	}
}
