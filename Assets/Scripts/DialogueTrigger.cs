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
    public int playerReact;
    public string sceneName;
    public bool sceneTransition;

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
        player.StopMoving(playerReact);
        Dialogue newDialogue = Instantiate(dialogue);
        newDialogue.lines = dialogueLines;
        newDialogue.textSpeed = dialogueSpeed;
        if (sceneTransition == true)
        {
            newDialogue.sceneTransition = true;
            newDialogue.sceneName = sceneName;
        }
        triggered = true;
    }
}
