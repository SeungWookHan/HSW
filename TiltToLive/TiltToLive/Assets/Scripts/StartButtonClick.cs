using UnityEngine;
using System.Collections;

public class StartButtonClick : MonoBehaviour {

    public void OnClickStartButton()
    {
        Application.LoadLevel("Lobby");
    }
}
