using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(LineRenderer))]
public class LaserLauncher : MonoBehaviour
{
    [Header("Laser Info")]
    public float maxDistance = 500f;
    public float intensity = 10f;
    public int maxReflectionCount = 5;

    private List<Vector3> laserPointList = new List<Vector3>();

    LineRenderer laserEffect;

    void Start()
    {
        laserEffect = GetComponent<LineRenderer>();
    }

    void Update()
    {
        // 레이저 세기 조절
        laserEffect.startWidth = intensity * 0.01f;

        laserPointList.Clear();

        Vector3 startPos = transform.position;
        Vector3 direction = transform.forward;
        float distance = maxDistance;

        laserPointList.Add(startPos);

        HitTest(startPos, direction, maxDistance, 0, LayerMask.NameToLayer("Mirror"));

        // 다 끝나고 한번에 그리도록 
        laserEffect.SetPositions(laserPointList.ToArray());

    }

    private void HitTest(Vector3 startPos, Vector3 direction, float distance, int index, LayerMask reflectableLayer)
    {
        // 무한 반사 방지
        if (maxReflectionCount < index) return;

        RaycastHit hit;

        laserEffect.positionCount = index + 2;

        // 시작점, 방향, hitInfo, 
        if (Physics.Raycast(startPos, direction, out hit, distance))
        {
            if (hit.transform.gameObject.GetComponentInChildren<Light>())
            {
                hit.transform.gameObject.GetComponentInChildren<Light>().enabled = true;
                
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("End"))
                {
                    Invoke("scenechange", 1);
                }
                
            }
            

            // 충돌 지점
            laserPointList.Add(hit.point);

            if (hit.transform.gameObject.GetComponent<PrismLaserChecker>() != null)
            {
                hit.transform.gameObject.GetComponent<PrismLaserChecker>().isHit = true;
            }

            // 반사벡터 구하기
            Vector3 reflectDir = Vector3.Reflect(direction, hit.normal);

            // 반사 가능한 오브젝트
            if(reflectableLayer == hit.collider.gameObject.layer)
            {
                // 재귀
                HitTest(hit.point, reflectDir, distance, index + 1, reflectableLayer);
            }
        }
        // 충돌 안하면
        else
        {
            laserPointList.Add(startPos + direction * distance);

        }

    }

    void scenechange()
    {
        SceneManager.LoadScene("EndingScene");
    }
}
