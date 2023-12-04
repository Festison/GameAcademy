using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeComponent : MonoBehaviour
{
    public Point p;
    public MeshRenderer meshRenderer;

    [SerializeField]
    private int costType;
    public int CostType
    {
        get => costType;
        set
        {
            costType = value;
            meshRenderer.materials[costType].color = Color.red;
        }
    }

    private Material mat;
    private void Awake()
    {
        mat = GetComponent<Renderer>().material;
    }

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();      
    }

    public void Set(int _y, int _x, int _costType)
    {
        p.y = _y;
        p.x = _x;
        CostType = _costType;
    }
}
