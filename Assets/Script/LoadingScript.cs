using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{
    public float progressLeft = 0;
    public Text Proses, LoadingText, PersenText;
    public Button buttonLoading1;
    public Slider sliderLoading;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IeCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        Proses.text = progressLeft.ToString();
        sliderLoading.value = progressLeft;
        if (progressLeft == 100)
        {
            Proses.gameObject.SetActive(false);
            LoadingText.gameObject.SetActive(false);
            sliderLoading.gameObject.SetActive(false);
            PersenText.gameObject.SetActive(false);
            buttonLoading1.gameObject.SetActive(true);
        }
    }

    IEnumerator IeCountdown()
    {
        while (progressLeft < 100)
        {
            yield return new WaitForSeconds(0.05f);
            progressLeft++;
        }
       
    }
}
