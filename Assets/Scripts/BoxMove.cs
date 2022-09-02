using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMove : MonoBehaviour
{
    public GameObject manager;

    private Animator anim;

    bool isAnim = false;

    float currentTime;
    float animTime = 2.2f;

    float playTime;
    float delayTime = 0.7f;

    RaycastHit h;

    private void Start()
    {
        // �÷��̾ ã�Ƽ� �� �ȿ� �ִ� �ִϸ����� �ҷ�����
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        Debug.Log(manager.GetComponent<Push>().isPush);

        Ray ray = new Ray(transform.position, transform.forward);
        
        //Raycast �ڵ� 
        if (Physics.SphereCast(ray, 0.5f, out h, 2, ~(1<<9)))
        {
            if (h.collider.gameObject.tag == "Box")
            {
                if ((Input.GetKeyDown(KeyCode.F) || manager.GetComponent<Push>().isPush) && isAnim == false)
                {
                    anim.SetBool("pushing", true);

                    StartCoroutine(RotateBox(h));
                    isAnim = true;
                }
                else
                {
                    anim.SetBool("pushing", false);
                }

            }
            
            currentTime += Time.deltaTime;

            if (currentTime > animTime)
            {
                isAnim = false;
                currentTime = 0;
            }
        }

        manager.GetComponent<Push>().isPush = false;
    }

    IEnumerator RotateBox(RaycastHit raycastHit)
    {
        yield return  new WaitForSeconds (0.5f);

        raycastHit.transform.Rotate(0, 15, 0);
    }


}
