using Michsky.UI.ModernUIPack;
using UnityEngine;
using UnityEngine.UI;
using static Michsky.UI.ModernUIPack.ButtonManager;

[RequireComponent(typeof(Image))]
public class RippleManager : MonoBehaviour
{
	public RippleUpdateMode rippleUpdateMode = RippleUpdateMode.UNSCALED_TIME;
	public Sprite rippleShape;
	[Range(0.1f, 5)] public float speed = 1f;
	[Range(0.5f, 25)] public float maxSize = 4f;
	public Color startColor = new Color(1f, 1f, 1f, 1f);
	public Color transitionColor = new Color(1f, 1f, 1f, 0f);
	public bool renderOnTop = false;
	public bool centered = false;

	public void CreateRipple()
	{
		CreateRipple(Input.mousePosition);
	}

	public void CreateRipple(Vector2 pos)
	{
		GameObject rippleObj = new GameObject();
		var image = rippleObj.AddComponent<Image>();
		image.sprite = rippleShape;
		image.raycastTarget = false;
		rippleObj.name = "Ripple";
		gameObject.SetActive(true);
		rippleObj.transform.SetParent(transform);

		if (renderOnTop == true)
			transform.SetAsLastSibling();
		else
			transform.SetAsFirstSibling();

		if (centered == true)
			rippleObj.transform.localPosition = new Vector2(0f, 0f);
		else
			rippleObj.transform.position = pos;

		var tempRipple = rippleObj.AddComponent<Ripple>();
		tempRipple.speed = speed;
		tempRipple.maxSize = maxSize;
		tempRipple.startColor = startColor;
		tempRipple.transitionColor = transitionColor;

		if (rippleUpdateMode == RippleUpdateMode.NORMAL)
			tempRipple.unscaledTime = false;
		else
			tempRipple.unscaledTime = true;
	}
}
