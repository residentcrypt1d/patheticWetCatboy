using DoodleStudio95;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorControl : MonoBehaviour
{
    public LayerMask clothesLayer;
    public LayerMask bodyLayer;
    public LayerMask itemLayer;
    //public DoodleAnimator luciFaceSprite;
    public Rigidbody2D grabbedObject;
    private Vector2 mousePosition;
    
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 100f, clothesLayer);
            if (hit.collider != null)
            {
                //PutOnClothes(hit.collider.gameObject);
                Debug.Log("whoa that's a clothes");
            }

            hit = Physics2D.Raycast(mousePosition, Vector2.zero, 100f, bodyLayer);
            if (hit.collider != null)
            {
                grabbedObject = hit.rigidbody;
                // change face sprite
            }
            hit = Physics2D.Raycast(mousePosition, Vector2.zero, 100f, itemLayer);
            if (hit.collider != null)
            {
                grabbedObject = hit.rigidbody;
            }
        }
        else if (Mouse.current.leftButton.wasReleasedThisFrame && grabbedObject != null)
        {
            grabbedObject = null;
        }
    }

    void FixedUpdate() // putting our physics stuff in here !
    {
        if (grabbedObject != null)
        {
            grabbedObject.MovePosition(mousePosition);
        }
    }

    /*void LuciShock(GameObject hitObj)
    {
        if (hitObj.CompareTag("lucifer"))
        {
            luciFaceSprite.File = hitObj.GetComponent<DoodleAnimator>().File;
        }
    }
    
    void LuciBlush(BoxCollider2D umm)
    {
        if (umm.CompareTag("square"))
        {
            luciFaceSprite.File = umm.GetComponent<DoodleAnimator>().File;
        }
    }

    void LuciNeutral(GameObject hitObj)
    {
        luciFaceSprite.File = hitObj.GetComponent<DoodleAnimator>().File;
    }

    /*void PutOnClothes(GameObject hitObj) // takes one (1) parameter, the thing we clicked on
    {
        if (hitObj.CompareTag("Shirt"))
        {
            shirtSprite.File = hitObj.GetComponent<DoodleAnimator>().File;
        }
    }*/
}