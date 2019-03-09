using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{

    public GameObject grid;

    public GameObject CubeToSpawn;

    [SerializeField]
    private MultiDimensionalInt[] gridBuilder;
    // Start is called before the first frame update
    void Start()
    {


    }

    public void BuildGrid() {
        foreach (var item in GameObject.FindGameObjectsWithTag("Cube")) {
            DestroyImmediate(item);
        }

        for (int i = 0; i < gridBuilder.Length; i++) {

            for (int k = gridBuilder[i].startPosition; k < gridBuilder[i].amountCubes + gridBuilder[i].startPosition; k++) {
                //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                GameObject cube = Instantiate(CubeToSpawn);
                cube.transform.position = new Vector3(k, 0f, i);
                cube.tag = "Cube";
                cube.transform.parent = grid.transform;
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
