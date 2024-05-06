using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassDoors : MonoBehaviour
{
    GameManager gm;
    [SerializeField] GameObject left, right;
    Vector3 leftStart, leftEnd, leftPos, rightStart, rightEnd, rightPos;
    float speed = 2.0f;
    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();

        leftPos = left.transform.position;
        rightPos = right.transform.position;

        leftStart = left.transform.position;
        rightStart = right.transform.position;

        leftEnd = new Vector3(left.transform.position.x, left.transform.position.y, left.transform.position.z - 4.0f);
        rightEnd = new Vector3(right.transform.position.x, right.transform.position.y, right.transform.position.z + 4.0f);
    }

    void Update()
    {
        left.transform.position = leftPos;
        right.transform.position = rightPos;

        if(gm.lightsOut){
            if(leftPos.z > leftEnd.z){
                leftPos.z -= speed * Time.deltaTime;
            } else {
                leftPos.z = leftEnd.z;
            }

            if(rightPos.z < rightEnd.z){
                rightPos.z += speed * Time.deltaTime;
            } else {
                rightPos.z = rightEnd.z;
            }
        }
    }
}
