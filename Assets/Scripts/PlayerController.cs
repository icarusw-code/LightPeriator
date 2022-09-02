using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private PlayerMove playerMove;
    private Animator anim;
    
    Vector3 movePoint;
    public Transform model;

    private void Awake()
    {
        playerMove = GetComponent<PlayerMove>();
        anim = gameObject.GetComponentInChildren<Animator>();

    }

    private void Update()
    {
        float z =  Input.GetAxisRaw("Horizontal");
        float x = Input.GetAxisRaw("Vertical");

        playerMove.MoveTo(new Vector3(-z, 0, -x));

        Vector3 dir = new Vector3(-z, 0, -x);
        dir.Normalize();
        if (dir.magnitude > 0.5f)
        {
            movePoint = dir;
        }

        Quaternion rotation = Quaternion.LookRotation(movePoint);

        model.rotation = rotation;
        // 애니메이션 실행
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            // anim.SetInteger("AnimationPar", 1);
            anim.SetBool("walk", true);
        }
        else
        {
            //anim.SetInteger("AnimationPar", 0);
            anim.SetBool("walk", false);
        }

    }
}

