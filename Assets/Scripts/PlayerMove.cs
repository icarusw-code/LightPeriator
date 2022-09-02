using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    public float speed;      // ĳ���� ������ ���ǵ�.
    private CharacterController controller; // ���� ĳ���Ͱ� �������ִ� ĳ���� ��Ʈ�ѷ� �ݶ��̴�.
    private Vector3 MoveDir;                // ĳ������ �����̴� ����.

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
        // ĳ���� ������.
        controller.SimpleMove(MoveDir * speed);
        
        
    }

    public void MoveTo(Vector3 Dir)
    {
        MoveDir = Dir;
    }
}

