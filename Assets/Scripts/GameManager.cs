using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Yarn;
using Yarn.Unity;

public class GameManager : MonoBehaviour
{
    //public Animator transition;
    
    public float transitionTime = 1f;
    public Button kitchenButton;
    public Button bathroomButton;
    public Button bedroomButton;

    public int livRoomItems;
    public DialogueRunner dr;

    void Start()
    {
        //Button kitchenButton = Button.GetComponent("ToKitchen");
        //kitchenButton =  kitchenButton.GetComponent<Button>("ToKitchen");
        livRoomItems = 5;
    }

    void Update()
    {
        // SKIP SCENES
        if (UnityEngine.InputSystem.Keyboard.current.wKey.wasPressedThisFrame)
        {
            Debug.Log("you skipped a scene!");
            LoadNextLevel();
        }
        // BUTTON CHECKS
        if (livRoomItems >0)
        {
            kitchenButton.interactable = false;
        }
        if (livRoomItems == 0)
        {
            kitchenButton.interactable = true;
            //Debug.Log("unlocked kitchen!");
        }

        if (bathroomButton != null)
        {
            bathroomButton.interactable = false;
        }
        else
        {
            bathroomButton.interactable = true;
        }

        if (bedroomButton != null)
        {
            bedroomButton.interactable = false;
        }
        else
        {
            bedroomButton.interactable = true;
        }
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

    
    public void SubtractLivRoomItems()
    {
        livRoomItems -= 1;
    }
}
