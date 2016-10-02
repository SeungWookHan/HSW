using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopUp_CharacterSelect : MonoBehaviour {

    public Text character;

    public enum CharacterIndex
    {
        None,
        One,
        Two,
        Three,
        Four,
    }

	// Use this for initialization
	void Awake () {
        character.text = "NULL";
    }

    public void OnClickCharacter(int index)
    {
        switch(index)
        {
            case (int)CharacterIndex.One:
                character.text = "One";
                break;
            case (int)CharacterIndex.Two:
                character.text = "Two";
                break;
            case (int)CharacterIndex.Three:
                character.text = "Three";
                break;
            case (int)CharacterIndex.Four:
                character.text = "Four";
                break;
        }

        
    }

}
