using DoodleStudio95;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Yarn.Unity;

public class BackgroundController : MonoBehaviour
{

    public Sprite[] backgroundsBedroom;
    private Sprite newBackground;
    
    // BEDROOM BACKGROUND SPRITES
    
    [YarnCommand("sequence1")] // background 1
    public void Sequence1()
    {
        Debug.Log("first image!");
        newBackground = backgroundsBedroom[0];
        gameObject.GetComponent<SpriteRenderer>().sprite = newBackground;
    }
    
    [YarnCommand("sequence2")] // background 2
    public void Sequence2()
    {
        Debug.Log("second image!");
        newBackground = backgroundsBedroom[1];
        gameObject.GetComponent<SpriteRenderer>().sprite = newBackground;
    }
    
    [YarnCommand("sequence3")] // background 3
    public void Sequence3()
    {
        Debug.Log("third image!");
        newBackground = backgroundsBedroom[2];
        gameObject.GetComponent<SpriteRenderer>().sprite = newBackground;
    }
    
    [YarnCommand("sequence4")] // background 4
    public void Sequence4()
    {
        Debug.Log("fourth image!");
        newBackground = backgroundsBedroom[3];
        gameObject.GetComponent<SpriteRenderer>().sprite = newBackground;
    }
    
    [YarnCommand("sequence5")] // background 5
    public void Sequence5()
    {
        Debug.Log("fifth image!");
        newBackground = backgroundsBedroom[4];
        gameObject.GetComponent<SpriteRenderer>().sprite = newBackground;
    }
}