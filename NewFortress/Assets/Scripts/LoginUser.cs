using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LoginUser : MonoBehaviour {

    public static LoginUser instance;

    class UserInfo
    {
        public string ID;
        public string PassWord;

        public UserInfo(string id, string password)
        {
            ID  = id;
            PassWord = password;
        }
    }
    
    private List<UserInfo> m_userList = new List<UserInfo>();
    public string m_userID;
    public string m_userPassWord;

    public bool m_isLogin = false;

    // Use this for initialization
    void Start()
    {
        AddUser("1234", "1234");
        AddUser("asdf", "asdf");
    }
    void Awake()
    {
        LoginUser.instance = this;
    }

    void AddUser(string id, string password){
        UserInfo user = new UserInfo(id, password);
        Debug.Log("ID : " + user.ID + " , PassWord : " + user.PassWord);
        m_userList.Add(user);
    }

    public void GetUserID(Text ID)
    {
        m_userID = ID.text.ToString();
        Debug.Log(m_userID);
    }

    public void GetUserPassWord(Text PassWord)
    {
        m_userPassWord = PassWord.text.ToString();
        Debug.Log(m_userPassWord);

        if(m_userID != "" && m_userPassWord != "")
            CheckUser();
    }

    void CheckUser()
    {
        Debug.Log("CheckUser");
        UserInfo user = new UserInfo(m_userID, m_userPassWord);
        Debug.Log("ID : " + user.ID + " , PassWord : " + user.PassWord);

        for (int i = 0; i < m_userList.Count; i++)
        {
            if (m_userList[i].ID == user.ID && m_userList[i].PassWord == user.PassWord)
            {
                m_isLogin = true;
                break;
            }
            else
                m_isLogin = false;
        }


        Debug.Log(m_isLogin);
    }

}