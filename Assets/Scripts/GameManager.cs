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
    public Button showerComButton;

    public int livRoomItems;
    public int kitchenItems;
    public DialogueRunner dr;

    void Start()
    {
        //Button kitchenButton = Button.GetComponent("ToKitchen");
        //kitchenButton =  kitchenButton.GetComponent<Button>("ToKitchen");
        livRoomItems = 5;
        kitchenItems = 10;
        bathroomButton.interactable = false;
        bedroomButton.interactable = false;
        showerComButton.interactable = false;
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
        if (livRoomItems > 0)
        {
            kitchenButton.interactable = false;
        }
        if (livRoomItems == 0)
        {
            kitchenButton.interactable = true;
            //Debug.Log("unlocked kitchen!");
        }
        /*if (kitchenItems == 9) // change back to 0 later please
        {
            Debug.Log("you put everything away!");
            //dr.StartDialogue("KitchenComplete");
            LoadNextLevel();
        }*/
    }

    public void BathroomInteractableTrue()
    {
        bathroomButton.interactable = true;
    }
    
    public void BedroomInteractableTrue()
    {
        bedroomButton.interactable = true;
    }

    public void ShowerComInteractableTimer()
    {
        StartCoroutine(ButtonTimer());
    }

    public void OnCollisionEnter2D()
    {
        // if a thing tagged kitchen touches a thing tagged shelf, call subtract kitchen item function
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
    
    IEnumerator ButtonTimer()
    {
        yield return new WaitForSeconds(10f);
        Debug.Log("this would enable our button!");
        showerComButton.interactable = true;
        //dr.StartDialogue("RinseOff");

        // Turn on the button & make it active
        //yield return null;
    }

    
    public void SubtractLivRoomItems()
    {
        livRoomItems -= 1;
    }
    
    public void SubtractKitchenItems()
    {
        kitchenItems -= 1;
    }
    
    public void AddKitchenItems()
    {
        kitchenItems += 1;
    }
}
