using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerPP : MonoBehaviour
{
    public string playerTag = "Player";
    public string menuSceneName = "MenuScene";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            SceneManager.LoadScene(menuSceneName);
        }
    }
}

}
