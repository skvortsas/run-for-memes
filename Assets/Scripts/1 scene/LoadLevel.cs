using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void LoadByIndex(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
