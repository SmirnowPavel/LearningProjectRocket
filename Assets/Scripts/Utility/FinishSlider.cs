using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishSlider : MonoBehaviour
{
	[SerializeField]
	private float timeDelay = 2f;
    [SerializeField]
	private Image slider;
	private bool workCoroutine = false;


	private void Start()
	{
		slider = GetComponent<Image>();
	}


	private IEnumerator UpdateTimer()
	{
		float timer = timeDelay;

		while (workCoroutine)
		{
			timer -= Time.deltaTime;
			slider.fillAmount = 1 - timer / timeDelay;

			if (timer < 0f)
			{
				LevelController.Instance.FinishLevel();
				break;
			}

			yield return new WaitForEndOfFrame();
		}
	}


	public void StartSlider()
	{
		workCoroutine = true;
		StartCoroutine(UpdateTimer());
	}


	public void StopSlider()
	{
		workCoroutine = false;
		slider.fillAmount = 0f;
	}
}
