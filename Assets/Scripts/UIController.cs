using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
	[SerializeField]
	private GameObject ui;

    void Start()
    {
		if(ui == null)
		{
			Debug.LogError("Null UI");
		}
		HideMenu();
    }

	public void ShowMenu()
	{
		Show();
	}

	public void HideMenu()
	{
		StartCoroutine(GamePlayManager.Instance.WaitThenRun(Hide, 1.75f));
	}


	private void Show()
	{
		ui.SetActive(true);
	}

	private void Hide()
	{
		ui.SetActive(false);
	}
}
