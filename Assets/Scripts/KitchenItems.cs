using UnityEngine;
using Yarn.Unity;

public class KitchenItems : MonoBehaviour
{

    public GameManager myManager;
    public bool collidedWithShelf = false;
    //public bool collidedWithFloor = false;
    public DialogueRunner dr;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if  (collision.gameObject.tag == "shelf" && collidedWithShelf == false)
        {
            Debug.Log("good job you collided");
            myManager.SubtractKitchenItems();
            collidedWithShelf = true;
            //collidedWithFloor = false;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "shelf" && collidedWithShelf == true)
        {
            Debug.Log("why'd you remove it????");
            myManager.AddKitchenItems();
            collidedWithShelf = false;
        }
    }
    
    // additional dialogue for dropping something onto the floor; make it so it doesn't trigger when items spawn

    public void Update()
    {
        if (myManager.kitchenItems == 0)
        {
            Debug.Log("you put everything away!");
            myManager.LoadNextLevel();
            //dr.StartDialogue("KitchenDone");
        }
    }
}
