using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;
using Quaternion = System.Numerics.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class SharkScript : MonoBehaviour
{
    [SerializeField] 
    Transform sharkPrefab;

    [SerializeField] private Transform fishPrefab;
    [SerializeField, Range(1,10)] 
    int resolution = 6;
    [SerializeField] 
    Transform sharkPivot;

    [SerializeField] private Transform fishPivot;

    [SerializeField] 
    Transform sharkPivot2;
    private float rotate = 0;

    
    void Awake()
    {
        Transform[] pivots = new Transform[4 * (resolution - 1)];
        Transform[] sharks = new Transform[4 * (resolution-1)];
        var position = Vector3.zero;
        for (int i = 1; i < resolution; i++)
        {
            for (int j = 1; j < 5; j++)
            {
                position.z = 0;
                position.x = 0;
                Transform point = Instantiate(sharkPrefab);
                position.y = -.5f;
                if (i%2 == 1)
                {
                    if (j == 1)
                    {
                        position.z = 10 * i - 3;
                        point.localRotation = UnityEngine.Quaternion.Euler(0f, 180, 0f);
                    }

                    if (j == 2)
                    {
                        position.z = -10 * i + 3;
                        point.localRotation = UnityEngine.Quaternion.Euler(0f, 0f, 0f);

                    }

                    if (j == 3)
                    {
                        position.x = 10 * i - 3;
                        point.localRotation = UnityEngine.Quaternion.Euler(0f, 270f, 0f);

                    }

                    if (j == 4)
                    {
                        position.x = -10 * i + 3;
                        point.localRotation = UnityEngine.Quaternion.Euler(0f, 90f, 0f);
                    }

                    
                    point.localPosition = position;
                    point.SetParent(transform);
                    sharks[i * j-1] = point;
                    Transform fishPoint = Instantiate(fishPrefab);
                    fishPoint.localPosition = new Vector3(position.x + 3, position.y, position.z);
                    Transform pivotPoint = Instantiate(fishPivot);
                    pivotPoint.localPosition = position;
                    pivotPoint.SetParent(transform);
                    pivots[i * j - 1] = pivotPoint;
                    fishPoint.SetParent(fishPivot);
                }
                else
                {
                    if (j == 1)
                    {
                        position.z = 10 * i - 3;
                        point.localRotation = UnityEngine.Quaternion.Euler(0f, 0, 0f);
                    }

                    if (j == 2)
                    {
                        position.z = -10 * i + 3;
                        point.localRotation = UnityEngine.Quaternion.Euler(0f, 180f, 0f);

                    }

                    if (j == 3)
                    {
                        position.x = 10 * i - 3;
                        point.localRotation = UnityEngine.Quaternion.Euler(0f, -270f, 0f);

                    }

                    if (j == 4)
                    {
                        position.x = -10 * i + 3;
                        point.localRotation = UnityEngine.Quaternion.Euler(0f, -90f, 0f);
                    }

                    point.localPosition = position;
                    point.SetParent(sharkPivot2);
                    sharks[i * j-1] = point;
                    Transform fishPoint = Instantiate(fishPrefab);
                    fishPoint.localPosition = new Vector3(position.x + 3, position.y, position.z);
                    Transform pivotPoint = Instantiate(fishPivot);
                    pivotPoint.localPosition = position;
                    pivotPoint.SetParent(transform);
                    pivots[i * j - 1] = pivotPoint;
                    fishPoint.SetParent(fishPivot);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        rotate += 1;
        for (int i = 0; i < 8; i++)
        {
            if (i<4)
            {
                sharkPivot.localRotation = UnityEngine.Quaternion.Euler(0f, 1.5f * rotate, 0);
            }
            else
            {
                sharkPivot2.localRotation = UnityEngine.Quaternion.Euler(0f, -2 * rotate, 0);
            }
        }

        fishPivot.localRotation = UnityEngine.Quaternion.Euler(0f, rotate, 0);

    }
}
