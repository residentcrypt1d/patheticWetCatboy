using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LuciDialogue : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Brick")) 
        {
            Debug.Log("you touched the brick!");
            // call brick node
        }

        if (collision.gameObject.CompareTag("Envelope"))
        {
            Debug.Log("you touched the envelope!");
            // call envelope node
        }

        if (collision.gameObject.CompareTag("Clarinet"))
        {
            Debug.Log("you touched the clarinet!");
            // call clarinet node
        }

        if (collision.gameObject.CompareTag("Apple"))
        {
            Debug.Log("you touched the apple!");
            // call apple node
        }
    }
}