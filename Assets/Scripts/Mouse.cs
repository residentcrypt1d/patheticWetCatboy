using DoodleStudio95;
using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class CursorControl : MonoBehaviour
{
    public LayerMask clothesLayer;
    public LayerMask bodyLayer;
    public LayerMask itemLayer;
    public LayerMask appleLayer;
    public LayerMask brickLayer;
    public LayerMask clarinetLayer;
    public LayerMask envelopeLayer;
    //public DoodleAnimator luciFaceSprite;
    public Rigidbody2D grabbedObject;
    private Vector2 mousePosition;
    
    //public GameObject dialogueBox;
    public DialogueRunner dr;
    public GameObject myManager;

    public bool appleCalled = false;
    public bool brickCalled = false;
    public bool clarinetCalled = false;
    public bool envelopeCalled = false;

    void Start()
    {
        myManager = GameObject.Find("GameManager").GetComponent<GameObject>();
    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 100f, clothesLayer);
            if (hit.collider != null)
            {
                //PutOnClothes(hit.collider.gameObject);
                //Debug.Log("whoa that's a clothes");
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
                // change face sprite
            }
            
            hit = Physics2D.Raycast(mousePosition, Vector2.zero, 100f, appleLayer);
            if (hit.collider != null)
            {
                grabbedObject = hit.rigidbody;
                if (appleCalled == false)
                {
                    AppleDialogue();
                }
            }
            
            hit = Physics2D.Raycast(mousePosition, Vector2.zero, 100f, brickLayer);
            if (hit.collider != null)
            {
                grabbedObject = hit.rigidbody;
                if (brickCalled == false)
                {
                    BrickDialogue();
                }
                
            }
            
            hit = Physics2D.Raycast(mousePosition, Vector2.zero, 100f, clarinetLayer);
            if (hit.collider != null)
            {
                grabbedObject = hit.rigidbody;
                if (clarinetCalled == false)
                {
                    ClarinetDialogue();
                }
            }
            
            hit = Physics2D.Raycast(mousePosition, Vector2.zero, 100f, envelopeLayer);
            if (hit.collider != null)
            {
                grabbedObject = hit.rigidbody;
                if (envelopeCalled == false)
                {
                    EnvelopeDialogue();   
                }
                
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

    void AppleDialogue()
    {
        Debug.Log("u grab apple!");
        dr.StartDialogue("AppleInteract");
        appleCalled = true;
    }

    void BrickDialogue()
    {
        Debug.Log("u grab brick!");
        dr.StartDialogue("BrickInteract");
        brickCalled = true;
    }

    void EnvelopeDialogue()
    {
        Debug.Log("u grab envelope!");
        dr.StartDialogue("EnvelopeInteract");
        envelopeCalled = true;
    }

    void ClarinetDialogue()
    {
        Debug.Log("u grab clarinet!");
        dr.StartDialogue("ClarinetInteract");
        clarinetCalled = true;
    }
}