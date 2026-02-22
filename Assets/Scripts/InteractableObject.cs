using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public Player player;
    public string[] dialogueLines;
    public Dialogue dialogue;
    public float dialogueSpeed;
    public bool interactable;
    public BoxCollider2D boxCollider;
    public int playerReact;
    public bool interacted;
    public bool key;
    public bool creepy;
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
                if (interacted == false)
                {
                    player.checker++;
                }
                PlayerChecks();


                interacted = true;
                Dialogue newDialogue = Instantiate(dialogue);
                newDialogue.lines = dialogueLines;
                newDialogue.textSpeed = dialogueSpeed;
                newDialogue.interactableObject = this;

            }
        }
    }

    void PlayerChecks()
    {
        if (key == true)
        {
            player.keyGet = true;
        }

        if (creepy == true)
        {
            player.creepyGuy = true;
        }
    }
}
