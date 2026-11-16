using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    //public Animator transition;
    
    public float transitionTime = 1f;

    //public GameObject myTextbox;
    
    void Start()
    {
        // we will set all necessary variables in here teehee
    }

    void Update()
    {
        if (UnityEngine.InputSystem.Keyboard.current.wKey.wasPressedThisFrame)
        {
            Debug.Log("you skipped a scene!");
            LoadNextLevel();
        }

        //if (UnityEngine.InputSystem.Keyboard.current.eKey.wasPressedThisFrame)
        //{
           // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //}
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
