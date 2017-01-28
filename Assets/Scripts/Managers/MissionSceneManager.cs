using UnityEngine;
using UnityEngine.SceneManagement;
using Util;

public class MissionSceneManager : MonoBehaviour
{
	private void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(Constants.SCENE_ID_MAIN_MENU);
	}
}
