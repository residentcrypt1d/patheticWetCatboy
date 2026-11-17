using DoodleStudio95;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Yarn.Unity;

public class SpriteController : MonoBehaviour
{
    [SerializeField] private Sprite[] characterSprites;
    private Sprite newSprite;

    public SpriteRenderer luciShorts;
    public SpriteRenderer luciCollar;
    public GameObject luciFaces;
    public DoodleAnimationFile[] ragdollFaces;

    public GameObject ragdollShorts;
    public DoodleAnimationFile[] ragdollShortsList;
    
    [YarnCommand("luciNeutral")] // sprite 0
    public void LuciNeutral() 
    {
        Debug.Log("he's facing you!");
        newSprite = characterSprites[0];
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    [YarnCommand("luciBack")] // sprite 1
    public void LuciBack()
    {
        Debug.Log("he's not facing you!");
        newSprite = characterSprites[1];
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }
    
    [YarnCommand("playerPhone")] // sprite 2
    public void PlayerPhone()
    {
        Debug.Log("it's your phone!");
        newSprite = characterSprites[2];
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }
    
    [YarnCommand("empty")] // sprite 3
    public void Empty()
    {
        Debug.Log("it's... nobody");
        newSprite = characterSprites[3];
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }
    
    [YarnCommand("chipNeutral")] // sprite 4
    public void ChipNeutral()
    {
        Debug.Log("it's chip!");
        newSprite = characterSprites[4];
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    [YarnCommand("chipPeace")]
    public void ChipPeace()
    {
        Debug.Log("whoa dude where'd your shirt go");
        newSprite = characterSprites[5];
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    [YarnCommand("luciGreeting")]
    public void LuciGreeting()
    {
        Debug.Log("he has a shirt on (kinda) what the fuck!");
        newSprite = characterSprites[6];
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }
    
    [YarnCommand("chipShirtless")]
    public void ChipShirtless()
    {
        Debug.Log("the sexyman");
        newSprite = characterSprites[7];
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }
    
    [YarnCommand("luciPoint")]
    public void LuciPoint()
    {
        Debug.Log("the goober");
        newSprite = characterSprites[8];
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    [YarnCommand("luciNakey")]
    public void LuciNakey()
    {
        Debug.Log("WHERE ARE YOUR PANTS?!?!?");
        newSprite = characterSprites[9];
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    [YarnCommand("removeShorts")]
    public void RemoveShorts()
    {
        Debug.Log("removed ragdoll luci's shorts");
        luciShorts.enabled = false;
    }

    [YarnCommand("removeCollar")]
    public void RemoveCollar()
    {
        Debug.Log("removed ragdoll luci's collar");
        luciCollar.enabled = false;
    }
    
    [YarnCommand("addCollar")]
    public void AddCollar()
    {
        Debug.Log("added ragdoll luci's collar");
        luciCollar.enabled = true;
    }

    [YarnCommand("addCensor")]
    public void AddCensor()
    {
        Debug.Log("hello censor bar");
        ragdollShorts.GetComponent<DoodleAnimator>().File = ragdollShortsList[1];
    }

    [YarnCommand("addShorts")]
    public void AddShorts()
    {
        Debug.Log("added ragdoll luci's shorts back!");
        ragdollShorts.GetComponent<DoodleAnimator>().File = ragdollShortsList[0];
    }

    [YarnCommand("ragdollNeutral")] 
    public void RagdollNeutral()
    {
        Debug.Log("ragdoll has neutral expression!");
        luciFaces.GetComponent<DoodleAnimator>().File = ragdollFaces[0];
    }
    
    [YarnCommand("ragdollBlush")] 
    public void RagdollBlush()
    {
        Debug.Log("ragdoll has blushing expression!");
        luciFaces.GetComponent<DoodleAnimator>().File = ragdollFaces[1];
    }
    
    [YarnCommand("ragdollGasp")] 
    public void RagdollGasp()
    {
        Debug.Log("ragdoll has gasping expression!");
        luciFaces.GetComponent<DoodleAnimator>().File = ragdollFaces[2];
    }
}