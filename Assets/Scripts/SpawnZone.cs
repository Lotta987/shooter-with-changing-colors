using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField] private float _topWidth;
    [SerializeField] private float _bottomWidth;
    [SerializeField] private float _height;
    [SerializeField] private float _minSpawnY;
    [SerializeField] private float _maxSpawnY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Mesh CreateTrapezoidMesh()
    {
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[4];
        vertices[0] = new Vector3(-_bottomWidth / 2f, 0, _height / 2f);
        vertices[1] = new Vector3(_bottomWidth / 2f, 0, _height / 2f);
        vertices[2] = new Vector3(-_topWidth / 2f, 0, -_height / 2f);
        vertices[3] = new Vector3(_topWidth / 2f, 0, -_height / 2f);
        int[] triangles = new int[12]
        {
            0,2,1,
            1,2,3,
            0,1,3,
            0,3,2
        };
        Vector3[] normals = new Vector3[4];
        normals[0] = Vector3.up;
        normals[1] = Vector3.up;
        normals[2] = Vector3.up;
        normals[3] = Vector3.up;
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        return mesh;
    }

    private void OnDrawGizmosSelected()
    {
                Gizmos.color = Color.black;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireMesh(CreateTrapezoidMesh(), Vector3.zero);
    }
    public Vector3 GetRandomPointInZone()
    {
        float randomX = Random.Range(-_topWidth / 2f, _topWidth / 2f);
        float randomZ = Random.Range(-_height / 2f, _height / 2f);
        float randomY = Random.Range(_minSpawnY, _maxSpawnY);
        return transform.position + transform.TransformVector(new Vector3(randomX, randomY, randomZ));
    }
}
