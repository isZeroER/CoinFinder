using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [FormerlySerializedAs("setting")] public GameObject helper;
    public Button startButton;
    public Button helpButton;
    public Button helpBackButton;
    public Button endButton;

    private void Awake()
    {
        startButton.onClick.AddListener(StartGame);
        // endButton.onClick.AddListener(EndGame);
        helpButton.onClick.AddListener(Helper);
        helpBackButton.onClick.AddListener(HelperBack);
    }

    public void StartGame()
    {
        gameObject.SetActive(false);
    }

    public void Helper()
    {
        helper.SetActive(true);
    }

    public void HelperBack()
    {
        helper.SetActive(false);
    }
    
    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
