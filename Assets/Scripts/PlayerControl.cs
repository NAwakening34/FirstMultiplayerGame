using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl: MonoBehaviour
{
    [SerializeField] int m_speed;
    Rigidbody2D m_rb2D;
    Animator m_myanim;
    Vector2 m_movement;
    private int m_score;
    PhotonView m_pv;

    void Start()
    {
        m_rb2D = GetComponent<Rigidbody2D>();
        m_myanim= GetComponent<Animator>();
        m_pv = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (m_pv.IsMine)
        {
            float m_movementX = Input.GetAxis("Horizontal");
            float m_movementY = Input.GetAxis("Vertical");
            m_myanim.SetInteger("VelX", (int)m_movementX);
            m_myanim.SetInteger("VelY", (int)m_movementY);

            m_movement = new Vector2(m_movementX, m_movementY).normalized;
            m_rb2D.MovePosition(m_rb2D.position + m_movement * m_speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bolita"))
        {
            Destroy(collision.gameObject);
            Debug.Log("consiguio punto");
            //m_pv.RPC("AddPointsinUI", RpcTarget.AllBuffered, 5);
        }
        
    }

    //[PunRPC]
    //void AddPointsinUI(int p_newScore)
    //{
    //    UIManager.Instance.updateText(p_newScore);
    //}
}
