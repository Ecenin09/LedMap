using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SimpleWindowAnimation : MonoBehaviour
{
	enum InitialState
	{
		VISIBLE,
		HIDDEN
	}

	[SerializeField] private InitialState initialState;
	[SerializeField] private bool changeStateOnEnable = false;
	public string windowFadeIn = "Simple Window In";
	public string windowFadeOut = "Simple Window Out";
	public string windowHiddenStart = "Simple Window Hidden Start";
	public string windowVisibleStart = "Simple Window Visible Start";
	private Animator windowAnimator;
	private bool visible;

	private void Awake()
	{
		windowAnimator = GetComponent<Animator>();
		switch (initialState)
		{
			case InitialState.HIDDEN:
				visible = false;
				windowAnimator.Play(windowHiddenStart);
				break;
			case InitialState.VISIBLE:
			default:
				visible = true;
				windowAnimator.Play(windowVisibleStart);
				break;
		}
	}

	private void OnEnable()
	{
		if (changeStateOnEnable)
		{
			switch (initialState)
			{
				case InitialState.HIDDEN:
					ShowWindow();
					break;
				case InitialState.VISIBLE:
				default:
					HideWindow();
					break;
			}
		}
	}

	public void ShowWindow()
	{
		if (!visible)
		{
			visible = true;
			windowAnimator.Play(windowFadeIn);
		}
	}

	public void HideWindow()
	{
		if (visible)
		{
			visible = false;
			windowAnimator.Play(windowFadeOut);
		}
	}

	public void ChangeVisibility(bool visible)
	{
		if (visible) ShowWindow();
		else HideWindow();
	}
}