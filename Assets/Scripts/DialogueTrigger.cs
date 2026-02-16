using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public string[] dialogueLines;
    public BoxCollider2D boxCollider;
    public bool retriggerable;
    public bool triggered;
    public Dialogue dialogue;
    public Player player;
    public float dialogueSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = Player.FindAnyObjectByType<Player>();
        boxCollider = GetComponent<BoxCollider2D>();
        triggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!retriggerable && triggered)
        {
            return;
        }

        player.canMove = false;
        player.StopMoving();
        Dialogue newDialogue = Instantiate(dialogue);
        newDialogue.lines = dialogueLines;
        newDialogue.textSpeed = dialogueSpeed;
        triggered = true;
    }
}
