using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZenvaVR;
using Unity;

namespace ZenvaVR

{

    [RequireComponent(typeof(ObjectPool))]
    public class DistanceSpawner : MonoBehaviour
    {


        public Transform reference;


        // minimum 
        public float genDistance;
        ObjectPool pool;

        GameObject newObj;

        public Vector3 direction;

        public float minGap;
        public float maxGap;

        // Use this for initialization
        void Awake()
        {

            pool = GetComponent<ObjectPool>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Vector3.Distance(reference.position, transform.position) <= genDistance)
            {

                Spawn();

                //repos distance swpaner 

                Reposition();
            }
        }

        private void Reposition()
        {
            float gap = UnityEngine.Random.Range(minGap, maxGap);

            float size = 0;

            if (newObj.GetComponent<Renderer>() != null)
            {

                Vector3 directionFilter = Vector3.Scale(newObj.GetComponent<Renderer>().bounds.size, direction);
                size = Mathf.Max(directionFilter.x, directionFilter.y, directionFilter.z);

            }
            else if (newObj.GetComponentInChildren<Renderer>())
            {
                Vector3 directionFilter = Vector3.Scale(newObj.GetComponentInChildren<Renderer>().bounds.size, direction);
                size = Mathf.Max(directionFilter.x, directionFilter.y, directionFilter.z);
            }


            float total = gap + size;

            transform.Translate(direction * total, Space.World);

        }

        private void Spawn()
        {
            newObj = pool.GetObj();

            newObj.transform.position = transform.position;
        }
    }
};