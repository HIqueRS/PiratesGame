using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void SceneChange(int id)
    {
        SceneManager.LoadScene(id);
    }
}
