using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> //kế thừa lớp singletonf
{
    public Dino playerPrefab; //tham chiếu đến Dino
    public Stone[] stonePrefab; //tham chiếu đến stone
    public float spawnTime; // Khoảng thời gian để tạo ra các viên đá

    int m_score; // Lưu điểm
    bool m_isGameover;// kiểm tra game kết thúc 
    bool m_isGamebegun; // Game đã bắt đầu
    Dino m_dinoClone; //Lưu biến player

    public int Score { get => m_score; set => m_score = value; }
    public bool IsGameover { get => m_isGameover; set => m_isGameover = value; }
    public bool IsGamebegun { get => m_isGamebegun;}

    public override void Awake() // Không lưu đối tượng khi load qua các scenes khác hay load lại scenes
    {
        MakeSingleton(false);
    }

    public override void Start()
    {
        GameGUI.Ins.ShowGameGui(false);
    }

    public void PlayGame()
    {
        if (playerPrefab)
            m_dinoClone = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);

        StartCoroutine(Spawn());

        GameGUI.Ins.ShowGameGui(true);
    }

    IEnumerator Spawn()
    {
        // Đợi 3 giây
        yield return new WaitForSeconds(3f);
        m_isGamebegun = true; // Bắt đầu game

        if(stonePrefab != null && stonePrefab.Length > 0)
        {
            while(!m_isGameover)
            { 
                int randIdx = Random.Range(0, stonePrefab.Length);
                //Kiểm tra phần tử ở vị trí ngẫu nhiên có rỗng không
                if(stonePrefab[randIdx] != null)
                {
                    Instantiate(stonePrefab[randIdx], new Vector3(m_dinoClone.transform.position.x, Random.Range(6f, 9f), 0f), Quaternion.identity);
                }

                yield return new WaitForSeconds(spawnTime);
            }
        }

        yield return null;
    }    
}
