using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject creepyScreen;
    public GameObject gameDevScreen;
    public Player player;
    public GameObject[] screens;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.creepyGuy == true && screens[6].tag != "Creepy")
        {
            Vector2 position = screens[6].transform.position;
            Destroy(screens[6]);
            GameObject creepy = Instantiate(creepyScreen);
            creepy.transform.position = position;
            screens[6] = creepy;
        }
    }

    public void NothingEnding()
    {
        Vector2 position = screens[8].transform.position;
        Destroy(screens[8]);
        GameObject gameDev = Instantiate(gameDevScreen);
        gameDev.transform.position = position;
        screens[8] = gameDev;
    }
}
