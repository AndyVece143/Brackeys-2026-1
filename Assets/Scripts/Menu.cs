using UnityEngine;

public class Menu : MonoBehaviour
{
    public LevelLoader loader;

    public void PlayButton()
    {
        loader.LoadNextLevel("Controls");
    }

    public void OpeningButton()
    {
        loader.LoadNextLevel("Opening");
    }

    public void CreditsButton()
    {
        loader.LoadNextLevel("Credits");
    }

    public void TitleButton()
    {
        loader.LoadNextLevel("Title");
    }
}