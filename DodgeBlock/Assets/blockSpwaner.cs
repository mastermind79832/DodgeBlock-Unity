using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockSpwaner : MonoBehaviour
{
    public GameObject blocks;
    
    public float maxtimer = 2f;
    float timer = 1f;

    float gScale = 0.5f;


    private void Start()
    {
        
    }

    private void Update()
    {
        if(Time.time >= maxtimer)
        {
            Spwan();
            maxtimer = Time.time + timer ;
        }
        
    }

    // Update is called once per frame
    void Spwan()
    {
        if(gScale <= 2)
            gScale += Time.timeSinceLevelLoad / 200;

        GameObject block = Instantiate(blocks);
        block.transform.position = transform.position;

         

        int index = Random.Range(0,block.transform.childCount);

        Destroy(block.transform.GetChild(index).gameObject);

        for(int i=0 ; i< block.transform.childCount ; i++)
            block.transform.GetChild(i).gameObject.GetComponent<Rigidbody2D>().gravityScale = gScale;




        Destroy(block, 3f);
        
    }
}
