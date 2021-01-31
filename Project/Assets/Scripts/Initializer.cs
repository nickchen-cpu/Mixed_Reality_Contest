using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{


    public GameObject table_a_status;
    public GameObject table_b_status;
    public GameObject table_c_status;
    public Material no_status;


    Material table_a_mat;

    // Start is called before the first frame update
    void Start()
    {
        initalize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void initalize()
    {
        table_a_status.GetComponent<MeshRenderer>().material = no_status;

    }

}
