using UnityEngine;
using System.Collections;

public class ChangeSceneOnClickScript : MonoBehaviour
{

    public string nextScene = "";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touches != null && Input.touches.Length > 0))
        {
            Application.LoadLevel(nextScene);
        }

    }
}

