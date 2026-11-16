using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class LivRoomDialogue : MonoBehaviour
{
    public GameObject dialogueBox;
    public DialogueRunner dr;


    /*private void OnCollisionEnter(Collider2D col)
    {
        if (col.gameObject.CompareTag("lucifer"))
        {
            dialogueBox.SetActive(true);
            Debug.Log("hey its our textbox!");

            dr.StartDialogue("placeholder");

        }
    }*/
}