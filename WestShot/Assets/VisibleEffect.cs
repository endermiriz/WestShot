using UnityEngine;
public class VisibleEffect : MonoBehaviour
{
    public Renderer rend;
    private int _id;
    private int rad;
    public string shaderVariableName = "_DistanceToCamera";
    public string radVariableName = "_DissolvePercentage";
    public GameObject Camera;
    private Vector3 _distanceObjectToCamera;

    public void Start()
    {
        _id = Shader.PropertyToID(shaderVariableName);
        rad = Shader.PropertyToID(radVariableName);
        rend = GetComponent<Renderer> ();
    }

    public void Update()
    {
        _distanceObjectToCamera = Camera.transform.position - this.transform.position;
        rend.material.SetFloat("_DissolvePercentage", 1.5f);
        Shader.SetGlobalFloat(_id, _distanceObjectToCamera.magnitude);
        
    }
}