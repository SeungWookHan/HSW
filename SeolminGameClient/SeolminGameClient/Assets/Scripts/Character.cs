using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    // private
    private Vector3 m_clickPos;

    // public
    public float m_moveSpeed = 10.0f;
    public float m_rotateSpeed = 5.0f;
    public Camera m_viewCamera;
    public GameObject m_hero;

	// Use this for initialization
	void Start () {
	}
	
    void SendPos(Vector3 pos)
    {
        RecvPos(pos);
    }

    void RecvPos(Vector3 pos)
    {
        m_clickPos = pos;
        StopCoroutine("HeroMove");
        StartCoroutine("HeroMove");
    }

	// Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = m_viewCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                SendPos(hit.point);
            }
        }
	}

    IEnumerator HeroMove()
    {
        while (true)
        {
            m_hero.GetComponent<Animation>().CrossFade("Run");
            if (Vector3.Distance(m_hero.transform.position, m_clickPos) < 1f) break;

            Vector3 moveVector = (m_clickPos - m_hero.transform.position).normalized;

            Quaternion lookQt = Quaternion.LookRotation(moveVector);
            lookQt.x = 0;
            lookQt.z = 0;

            transform.rotation = Quaternion.Slerp(m_hero.transform.rotation, lookQt, m_rotateSpeed * Time.deltaTime);
            // 보간 회전을 한다.

            transform.Translate(Vector3.forward * m_moveSpeed * Time.deltaTime);

            yield return null;
        }
        m_hero.GetComponent<Animation>().CrossFade("Breath");
    }
}
