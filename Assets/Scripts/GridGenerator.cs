using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField]
    private MultiDimensionalInt[] grid;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < grid.Length; i++) {

            for (int k = grid[i].startPosition; k < grid[i].amountCubes + grid[i].startPosition; k++) {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3(k, 0f, i);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    [System.Serializable]
    public class MultiDimensionalInt
    {
        public int amountCubes;
        public int startPosition;
    }
}
