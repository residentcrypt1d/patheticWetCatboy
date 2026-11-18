using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SoapDestroyer : MonoBehaviour
{
    private Vector2 positionTracker;
    private Vector2 refPosition = Vector2.zero;
    public float followSpeed = 1.0f;
    public float trackingSpeed = 3f;
    
    [SerializeField] private Sprite[] showerSprites;
    private Sprite newSprite;

    [SerializeField] private GameObject mouseControls;
    
    // toggle between add soap & destroy soap, gonna attach this to buttons
    
    void Start()
    {
        Debug.Log("goodbye world... just a glimpse into my dark and *i am shot dead*");
        Cursor.visible = false;
        
        newSprite = showerSprites[0]; // this is the soap bar
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    
    void Update()
    {
        positionTracker = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        transform.position = Vector2.SmoothDamp(transform.position, positionTracker, ref refPosition, trackingSpeed);
    }
    
    
    
}