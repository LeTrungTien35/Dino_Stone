using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public float moveSpeed; // Tốc độ 
    Rigidbody2D m_rb; // Tham chiếu đến Rigidbody2D
    bool m_isGround; // Kiểm tra viên đá chạm đất

    public bool IsGround { get => m_isGround;}// Cho phép các lớp khác truy xuất

    //Xử lý trước khi game bắt đầu
    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();// Tham chiếu đến Rigidbody2D
    }
    //Thay đổi vật lý
    private void FixedUpdate()
    {
        if (m_rb)// Nếu Rigidbody2D không rỗng
            m_rb.velocity = Vector3.down * moveSpeed;// Thay đổi vận tốc
    }

    // Bắt va chạm
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            m_isGround = true;
            Destroy(gameObject, 0f);
            GameManager.Ins.Score++;
            GameGUI.Ins.UpdateScore(GameManager.Ins.Score);
            AudioController.Ins.PlaySound(AudioController.Ins.landSound);
        }    
    }
}
