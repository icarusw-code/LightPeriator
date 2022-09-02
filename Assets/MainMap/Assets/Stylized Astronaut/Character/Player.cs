using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    private Animator anim;
    private CharacterController controller;

    public float speed = 600.0f;
    // ȸ�� �ӵ�
    float rotateSpeed = 5.0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // �ִϸ��̼� ����
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            anim.SetInteger("AnimationPar", 1);
        }
        else
        {
            anim.SetInteger("AnimationPar", 0);
        }

        // �÷��̾� ����
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // �÷��̾� �̵�
        this.transform.position += Movement * speed * Time.deltaTime;

        // ȸ��
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Movement), Time.deltaTime * rotateSpeed);
        Movement.Normalize();
    }
}