using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControl: MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_NicknameUI;
    [SerializeField] int m_speed;
    Rigidbody2D m_rb2D;
    Animator m_myanim;
    Vector2 m_movement;
    PhotonView m_pv;
    [SerializeField]
    GameObject coins;

    void Start()
    {
        m_rb2D = GetComponent<Rigidbody2D>();
        m_myanim= GetComponent<Animator>();
        m_pv = GetComponent<PhotonView>();
        m_NicknameUI.text = m_pv.Owner.NickName;
        coins = GameObject.FindGameObjectWithTag("Coin");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (m_pv.IsMine && UIManager.Instance.CanMove)
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
            UIManager.Instance.addPoints();
            if (coins.transform.childCount == 1)
            {
                UIManager.Instance.addText(m_pv.Owner.NickName + " obtuvo la ultima moneda");
                Debug.Log(m_pv.Owner.NickName + "obtuvo la ultima moneda");
            }
            else
            {
                UIManager.Instance.addText(m_pv.Owner.NickName + " obtuvo una moneda");
                Debug.Log(m_pv.Owner.NickName + "obtuvo una moneda");
            }

        }
    }
}
