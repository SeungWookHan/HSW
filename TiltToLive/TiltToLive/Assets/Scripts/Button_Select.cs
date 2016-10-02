using UnityEngine;
using System.Collections;

public class Button_Select : MonoBehaviour {

    public GameObject popup;

	// Use this for initialization
	void Start () {
        popup.SetActive(false);
	}
	
    public void OnClickSelect(bool IsPopUp)
    {
        popup.SetActive(IsPopUp);
    }
}
