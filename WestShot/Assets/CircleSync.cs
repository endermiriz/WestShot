using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CircleSync : MonoBehaviour
{
    float valFloat = 0f;
    
    public static int PosID = Shader.PropertyToID("_Position");
    public static int SizeID = Shader.PropertyToID("_Size");
    public Material WallMaterial;
    public Camera Camera;
    public LayerMask Mask;
    private void Start()
    {
        DOTween.SetTweensCapacity( 500, 125 );
    }
    void Update()
    {
        var dir = Camera.transform.position - transform.position;
        var ray = new Ray(transform.position, dir.normalized);

        if (Physics.Raycast(ray, 3000, Mask))
        {
            DOTween.To(x => valFloat = x, valFloat, .5f, 1);
            WallMaterial.SetFloat(SizeID, valFloat);
        }

        else
        {
            DOTween.To(x => valFloat = x, valFloat, 0, 1);
            WallMaterial.SetFloat(SizeID, valFloat);
            
        }
            

        var view = Camera.WorldToViewportPoint(transform.position);
        WallMaterial.SetVector(PosID, view);
    }
}
