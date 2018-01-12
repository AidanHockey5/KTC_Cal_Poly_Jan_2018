using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text winText;
	// Use this for initialization
	void Start ()
    {
        winText.enabled = false;
	}
	
    public void ShowWinText()
    {
        winText.enabled = true;
    }
}
