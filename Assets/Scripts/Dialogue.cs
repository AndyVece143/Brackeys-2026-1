using System.Collections;
using TMPro;
using Unity.VectorGraphics;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    [SerializeField] private bool isCutscene;
    public Player player;

    public InteractableObject interactableObject;

    public bool sceneTransition;
    public string sceneName;
    public LevelLoader loader;
    public EndingText endingText;

    public AudioClip soundFX;
    public bool opening;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!isCutscene)
        {
            player = Player.FindAnyObjectByType<Player>();
        }
        textComponent.text = string.Empty;
        loader = LevelLoader.FindAnyObjectByType<LevelLoader>();
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        if (!isCutscene)
        {
            SoundManager.instance.PlaySound(soundFX);
        }
        index = 0;
        StartCoroutine(TypeLine());
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            if (isCutscene && !opening)
            {
                endingText.begin = true;
                Destroy(gameObject);
            }
            else
            {
                
                if (interactableObject != null)
                {
                    interactableObject.interactable = true;
                    Destroy(gameObject);
                }

                if (sceneTransition == true)
                {
                    loader.LoadNextLevel(sceneName);
                    Destroy(gameObject);
                }
                else
                {
                    player.canMove = true;
                    Destroy(gameObject);
                }

            }
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
