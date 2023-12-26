using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrenoGrid : MonoBehaviour
{
    public int gridSizeX = 10; // Ajuste conforme necessário
    public int gridSizeZ = 10; // Ajuste conforme necessário
    public float nodeRadius = 1f;

    [SerializeField] Transform terrainReferencePoint; // Ponto de referência para o plano
    [SerializeField] TerrenoGenerator vegetationGenerator;
    public bool ifIsDoneVegetation = false;
    public Vector3[,] gridPositions;

    public Node[,] grid;

    void Start()
    {
        CreateGrid();
        SpawnVegetation();
    }

    public void Update()
    {
        if (vegetationGenerator != null) vegetationGenerator.GenerateVegetation();
    }

    private void CreateGrid()
    {
        if (terrainReferencePoint == null)
        {
            Debug.LogError("Por favor, atribua um ponto de referência para o plano no Inspetor.");
            return;
        }

        Vector3 terrainPosition = terrainReferencePoint.position; // Usando o ponto de referência
        Vector3 terrainSize = new Vector3(10, 1, 10); // Ajuste conforme necessário

        int gridSizeX = Mathf.RoundToInt(terrainSize.x / (nodeRadius * 2));
        int gridSizeZ = Mathf.RoundToInt(terrainSize.z / (nodeRadius * 2));

        grid = new Node[gridSizeX, gridSizeZ];

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int z = 0; z < gridSizeZ; z++)
            {
                Vector3 worldPoint = terrainPosition + new Vector3(x * nodeRadius * 2 + nodeRadius, 0, z * nodeRadius * 2 + nodeRadius);

                // Remova a amostragem de altura, pois você não está usando um terreno
                // float elevation = terrainPlane.SampleHeight(worldPoint);

                // worldPoint.y = elevation;

                bool walkable = IsPositionWalkable(worldPoint);

                grid[x, z] = new Node(walkable, worldPoint, x, z);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (grid != null)
        {
            foreach (Node node in grid)
            {
                Gizmos.color = node.walkable ? Color.white : Color.red;
                Gizmos.DrawCube(node.worldPosition, Vector3.one * (nodeRadius * 2 - 0.1f));
            }
        }
    }

    private void SpawnVegetation()
    {
        if (vegetationGenerator != null)
        {
            gridPositions = new Vector3[grid.GetLength(0), grid.GetLength(1)];

            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int z = 0; z < grid.GetLength(1); z++)
                {
                    if (grid[x, z].walkable)
                        gridPositions[x, z] = grid[x, z].worldPosition;
                }
            }

            vegetationGenerator.GeneratePosition(gridPositions);
        }
    }

    private bool IsPositionWalkable(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, nodeRadius);

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Obstacle"))
            {
                return false;
            }
        }

        return true;
    }

    public class Node
    {
        public bool walkable;
        public Vector3 worldPosition;
        public int gridX;
        public int gridZ;

        public Node(bool _walkable, Vector3 _worldPos, int _gridX, int _gridZ)
        {
            walkable = _walkable;
            worldPosition = _worldPos;
            gridX = _gridX;
            gridZ = _gridZ;
        }
    }
}
