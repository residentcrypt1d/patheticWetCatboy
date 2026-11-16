using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class FollowMouse : MonoBehaviour
{
    private Vector2 positionTracker;
    private Vector2 refPosition = Vector2.zero;
    public float trackingSpeed = 3f;
    
    [SerializeField] Sprite cursorDefault;
    
    
    void Start()
    {
        Debug.Log("goodbye world... just a glimpse into my dark and *i am shot dead*");
        Cursor.visible = false;
        transform.GetComponent<SpriteRenderer>().sprite = cursorDefault;
    }

    
    void Update() // update this to make it like. not shit maybe?
    {
        positionTracker = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        
        //FOR PRECISE FOLLOW 
        transform.position = Vector2.SmoothDamp(transform.position, positionTracker, ref refPosition, trackingSpeed);
        
    }
}