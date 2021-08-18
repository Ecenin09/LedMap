using Michsky.UI.ModernUIPack;
using UnityEngine;

public class DeviceUIManager : MonoBehaviour
{
	[SerializeField] SimpleWindowAnimation arrow;
	[SerializeField] SimpleWindowAnimation @switch;
	[SerializeField] SwitchManager switchManager;
	DevicesListUIManager _listManager;
	DevicesListUIManager ListManager
	{
		get
		{
			if (_listManager == null)
			{
				_listManager = GetComponentInParent<DevicesListUIManager>();
			}
			return _listManager;
		}
		set
		{
			_listManager = value;
		}
	}

	public void EditMode()
	{
		arrow.ShowWindow();
		@switch.HideWindow();
	}

	public void SelectMode()
	{
		arrow.HideWindow();
		@switch.ShowWindow();
	}

	public void Select()
	{
		ListManager.Select(this);
	}

	public void Unselect()
	{
		switchManager.Change(false);
	}

	public void Rename()
	{
		var myDevicesHandler = GetComponentInParent<MyDevicesHandler>();
		myDevicesHandler.MiddlePanel.HideWindow();
		myDevicesHandler.RenameMenu.ShowWindow();
	}
}
