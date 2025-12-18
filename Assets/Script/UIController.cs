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
    public GameObject winPanel;
    public GameObject startPanel;
    public GameObject settingPanel;
    public GameObject tipPanel;
    [Header("按钮")]
    public Button startButton;
    public Button helpButton;
    public Button settingBtn;
    public Button settingBackBtn;
    public Button endButton;
    public Button replayBtn;
    public Button replayBtn2;
    public Button closeHelperBtn;
    public Button tipBackBtn;
    

    protected override void Awake()
    {
        base.Awake();
        startButton.onClick.AddListener(StartGame);
        // endButton.onClick.AddListener(EndGame);
        helpButton.onClick.AddListener(() => Helper(true));
        closeHelperBtn.onClick.AddListener(() => Helper(false));
        replayBtn.onClick.AddListener(Replay);
        replayBtn2.onClick.AddListener(Replay);
        settingBtn.onClick.AddListener(() => Setting(true));
        settingBackBtn.onClick.AddListener(() => Setting(false));
        tipBackBtn.onClick.AddListener(() => Tip(false));
    }

    private void Tip(bool flag)
    {
        tipPanel.SetActive(flag);
        if (!flag)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    
    private void Setting(bool flag)
    {
        settingPanel.SetActive(flag);
    }

    private void Replay()
    {
        SceneManager.LoadScene("Scenes/DemoScene");
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        Tip(true);
    }

    private void Helper(bool flag)
    {
        Debug.Log(flag);
        helper.SetActive(flag);
    }

    public void SetFalse()
    {
        falsePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void SetWin()
    {
        winPanel.SetActive(true);
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
