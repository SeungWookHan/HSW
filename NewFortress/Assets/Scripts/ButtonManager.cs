using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

    public enum ButtonState
    {
        Login,
        Start,
        Continue,
        Setup,
    }

    public ButtonState m_buttonState;
    public Text m_text;

    void Start()
    {        
        switch (m_buttonState)
        {
            case ButtonState.Login:
                m_text.text = "Login";
                break;

            case ButtonState.Start:
                m_text.text = "Start";
                break;

            case ButtonState.Continue:
                m_text.text = "Continue";
                break;

            case ButtonState.Setup:
                m_text.text = "Setup";
                break;

        }

	}

    public void OnClickButton()
    {
        switch (m_buttonState)
        {
            case ButtonState.Login:
                if (LoginUser.instance != null)
                {
                    if (LoginUser.instance.m_isLogin)
                        Application.LoadLevel("Lobby");
                    else
                        Debug.Log("ID or Passward is False");
                }
                else
                    Debug.Log("Login Fail");
                break;
            case ButtonState.Start:
                Debug.Log("StartButton");
                Application.LoadLevel("InGame");
                break;
            case ButtonState.Continue:
                Debug.Log("ContinuetButton");
                break;
            case ButtonState.Setup:
                Debug.Log("SetupButton");
                break;
        }
    }
}
