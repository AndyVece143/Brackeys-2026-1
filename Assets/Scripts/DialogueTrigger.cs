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

    public bool musicCutter;
    public AudioSource source;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = Player.FindAnyObjectByType<Player>();
        boxCollider = GetComponent<BoxCollider2D>();
        triggered = false;

        if (musicCutter == true)
        {
            source = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
        }
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

        if (musicCutter)
        {
            source.Pause();
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
