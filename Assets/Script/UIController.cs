using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UIController : MonoBehaviour
{
    [FormerlySerializedAs("setting")] public GameObject helper;
    
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
