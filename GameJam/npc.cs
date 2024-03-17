using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class npc : MonoBehaviour
{
    [SerializeField] GameObject chat;
    [SerializeField] List<string> message;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    int x = 0;
    bool y = false;
    bool z = false;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && y)
        {
            NextChat();
        }
    }
    private void NextChat()
    {
       if(x< message.Count)
        {
            textMeshProUGUI.text = message[x];
            x++;

        }
        else
        {
            chat.SetActive(false);
            z = true;
        }
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !z)
        {
            chat.SetActive(true);
            y = true;
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            chat.SetActive(false);
            y = false;
        }
    }
}
   