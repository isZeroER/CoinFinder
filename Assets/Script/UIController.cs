using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIController : UnitySingleton<UIController>
{
    [Header("Panel")]
    public GameObject helper;
    public GameObject falsePanel;
    public GameObject startPanel;
    [Header("按钮")]
    public Button startButton;
    public Button helpButton;
    public Button helpBackButton;
    public Button endButton;
    public Button replayBtn;

    protected override void Awake()
    {
        base.Awake();
        startButton.onClick.AddListener(StartGame);
        // endButton.onClick.AddListener(EndGame);
        helpButton.onClick.AddListener(Helper);
        helpBackButton.onClick.AddListener(HelperBack);
        replayBtn.onClick.AddListener(Replay);
    }

    private void Replay()
    {
        SceneManager.LoadScene("Scenes/DemoScene");
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Helper()
    {
        helper.SetActive(true);
    }

    public void HelperBack()
    {
        helper.SetActive(false);
    }

    public void SetFalse()
    {
        falsePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
