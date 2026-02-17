using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public Player player;
    public string[] dialogueLines;
    private float distance;
    public Dialogue dialogue;
    public float dialogueSpeed;
    public bool interactable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = Player.FindAnyObjectByType<Player>();
        interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= 1)
        {
            if (Input.GetMouseButtonDown(0) && interactable == true)
            {
                interactable = false;
                player.canMove = false;
                player.StopMoving();
                Dialogue newDialogue = Instantiate(dialogue);
                newDialogue.lines = dialogueLines;
                newDialogue.textSpeed = dialogueSpeed;
                newDialogue.interactableObject = this;
            }
        }
    }
}
