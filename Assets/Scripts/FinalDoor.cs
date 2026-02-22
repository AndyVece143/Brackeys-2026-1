using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    public Player player;
    public string[] dialogueNoKey;
    public string[] dialogueKey;
    public Dialogue dialogue;
    public bool interactable;
    public BoxCollider2D boxCollider;
    public int playerReact;
    public bool interacted;
    public float dialogueSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = Player.FindAnyObjectByType<Player>();
        boxCollider = GetComponent<BoxCollider2D>();
        interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (boxCollider.IsTouching(player.boxCollider))
        {
            if (Input.GetMouseButtonDown(0) && interactable == true)
            {
                interactable = false;
                player.canMove = false;
                player.StopMoving(playerReact);
                interacted = true;

                if (player.keyGet == false)
                {
                    Dialogue badDialogue = Instantiate(dialogue);
                    badDialogue.lines = dialogueNoKey;
                    badDialogue.textSpeed = dialogueSpeed;
                    //badDialogue.interactableObject = this;
                }

                if (player.keyGet == true)
                {
                    Dialogue goodDialogue = Instantiate(dialogue);
                    goodDialogue.lines = dialogueKey;
                    goodDialogue.textSpeed = dialogueSpeed;
                    goodDialogue.sceneTransition = true;
                    goodDialogue.sceneName = "GoodEnd";
                }
            }
        }
    }
}
