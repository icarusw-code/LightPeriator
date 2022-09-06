using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLoadScene : MonoBehaviour
{
    float currentTime = 0;
    float createTime = 7.8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �ð��� �帥��
        currentTime += Time.deltaTime;

        if(currentTime > createTime)
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
