using System.Collections;
using UnityEngine;
using static UnityEngine.UI.Button;

public class CallbackDelay : MonoBehaviour
{
	public float delay;
    [SerializeField]
    private ButtonClickedEvent m_OnClick = new ButtonClickedEvent();

    public ButtonClickedEvent onClick
    {
        get { return m_OnClick; }
        set { m_OnClick = value; }
    }
    public void Invoke()
	{
		StartCoroutine(Coroutine());
	}

	private IEnumerator Coroutine()
	{
		yield return new WaitForSecondsRealtime(delay);
		onClick.Invoke();
	}
}
