using UnityEngine;
using Yarn.Unity;

public class SpriteController : MonoBehaviour
{
    [SerializeField] private Sprite[] characterSprites;
    private Sprite newSprite;
    
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
}