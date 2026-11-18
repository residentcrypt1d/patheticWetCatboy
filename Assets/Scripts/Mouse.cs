using System.Collections;
using System.Collections.Generic;
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
    public LayerMask standLayer;
    public LayerMask lampLayer;
    public LayerMask showerLayer;

    public Rigidbody2D grabbedObject;
    private Vector2 mousePosition;

    public GameObject luciFaces;
    public DoodleAnimationFile[] ragdollFaces;

    //public GameObject dialogueBox;
    public DialogueRunner dr;
    public GameObject myManager;

    public bool appleCalled = false;
    public bool brickCalled = false;
    public bool clarinetCalled = false;
    public bool envelopeCalled = false;
    public bool standCalled = false;
    public bool lampCalled = false;

    public bool addSoap = true;
    
    [SerializeField] private float waitTime = .10f;
    public GameObject soapToSpawn;
    private GameObject spawnedSoap;

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
                RagdollGasp();
            }

            hit = Physics2D.Raycast(mousePosition, Vector2.zero, 100f, itemLayer);
            if (hit.collider != null)
            {
                grabbedObject = hit.rigidbody;
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

            hit = Physics2D.Raycast(mousePosition, Vector2.zero, 100f, standLayer);
            if (hit.collider != null)
            {
                grabbedObject = hit.rigidbody;
                if (standCalled == false)
                {
                    StandDialogue();
                }

            }

            hit = Physics2D.Raycast(mousePosition, Vector2.zero, 100f, lampLayer);
            if (hit.collider != null)
            {
                grabbedObject = hit.rigidbody;
                if (lampCalled == false)
                {
                    LampDialogue();
                }

            }
        }

        if (Mouse.current.leftButton.isPressed) // adding & destroying soap
        {
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 100f, showerLayer);
            if (hit.collider != null && addSoap)
            {
                Debug.Log("spawned soap!");
                //StartCoroutine(SpawnSoap(0.5f));
                AddSoap();
            }
            if (hit.collider != null && addSoap == false && gameObject.tag == "bubble")
            {
                Debug.Log("destroyed soap! in theory!"); 
                //Destroy(soapToSpawn);
                //StartCoroutine(SpawnSoap(0.5f));
            }
        }

        else if (Mouse.current.leftButton.wasReleasedThisFrame && grabbedObject != null)
        {
            grabbedObject = null;
            RagdollNeutral();
        }
    }


    void FixedUpdate() // putting our physics stuff in here !
    {
        if (grabbedObject != null)
        {
            grabbedObject.MovePosition(mousePosition);
        }
    }

    public void RagdollGasp()
    {
        Debug.Log("ragdoll has gasping expression!");
        luciFaces.GetComponent<DoodleAnimator>().File = ragdollFaces[1];
    }

    public void RagdollNeutral()
    {
        Debug.Log("ragdoll has neutral expression!");
        luciFaces.GetComponent<DoodleAnimator>().File = ragdollFaces[0];
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

    void StandDialogue()
    {
        Debug.Log("u grab stand!");
        dr.StartDialogue("StandInteract");
        standCalled = true;
    }

    void LampDialogue()
    {
        Debug.Log("u grab lamp!");
        dr.StartDialogue("LampInteract");
        lampCalled = true;
    }

    void AddSoap()
    {
        //Debug.Log("Entered: " + gameObject.name + ". Yay! We did it");
        spawnedSoap = Instantiate(soapToSpawn, mousePosition, Quaternion.Euler(0, 0, (Random.Range(0,360))));
    }

}