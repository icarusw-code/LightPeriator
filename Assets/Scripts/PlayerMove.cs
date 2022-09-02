using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    public float speed;      // 캐릭터 움직임 스피드.
    private CharacterController controller; // 현재 캐릭터가 가지고있는 캐릭터 컨트롤러 콜라이더.
    private Vector3 MoveDir;                // 캐릭터의 움직이는 방향.

    void Start()
    {
        speed = 6.0f;
     
        MoveDir = Vector3.zero;
       
    }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        // 캐릭터 움직임.
        controller.SimpleMove(MoveDir * speed);
        
        
    }

    public void MoveTo(Vector3 Dir)
    {
        MoveDir = Dir;
    }
}

