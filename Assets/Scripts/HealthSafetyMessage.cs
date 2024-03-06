using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class HealthSafetyMessage : MonoBehaviour
{
    public TMP_Text warningText;
    public TMP_Text bodyText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ActivateWarningText());
    }

    IEnumerator ActivateWarningText()
    {
        yield return new WaitForSeconds(2.0f);
        warningText.enabled = true;
        bodyText.enabled = true;
        yield return new WaitForSeconds(20.0f);
        warningText.enabled = false;
        bodyText.enabled = false;
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadSceneAsync(1);
    }
}
