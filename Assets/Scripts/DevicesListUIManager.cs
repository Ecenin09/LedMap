using UnityEngine;
using System.Linq;

public class DevicesListUIManager : MonoBehaviour
{
	public void EditMode()
	{
		foreach (var entry in gameObject.GetComponentsInChildren<DeviceUIManager>())
		{
			entry.EditMode();
		}
	}

	public void SelectMode()
	{
		foreach (var entry in gameObject.GetComponentsInChildren<DeviceUIManager>())
		{
			entry.SelectMode();
		}
	}

	public void Select(DeviceUIManager selection)
	{
		foreach (var entry in gameObject.GetComponentsInChildren<DeviceUIManager>().Where(x => x != selection))
		{
			entry.Unselect();
		}
	}
}
