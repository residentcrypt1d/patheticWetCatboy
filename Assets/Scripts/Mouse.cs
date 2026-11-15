using DoodleStudio95;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorControl : MonoBehaviour
{
    public LayerMask clothesLayer;
    public LayerMask bodyLayer;
    public DoodleAnimator shirtSprite;
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

    /*void PutOnClothes(GameObject hitObj) // takes one (1) parameter, the thing we clicked on
    {
        if (hitObj.CompareTag("Shirt"))
        {
            shirtSprite.File = hitObj.GetComponent<DoodleAnimator>().File;
        }
    }*/
}