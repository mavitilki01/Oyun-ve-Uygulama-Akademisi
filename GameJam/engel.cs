using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class engel : MonoBehaviour
{

    private Scene scene;

    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
        Debug.Log(scene.name);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(scene.name);
        }

        
    }
}
