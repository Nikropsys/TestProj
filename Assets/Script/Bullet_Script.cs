using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace NikitaTovs
{
    public class Bullet_Script : MonoBehaviour
    {
        float t = 0;
        float gravity = 9.8f;
        float angle;
        float speed = 15f;
        float curr_speed;
        float radius = 3f;
        int floor_count = 0;

        Vector3 pos;
        [SerializeField]
        Transform target;
        [SerializeField]
        World_Script world;
        public delegate void Bullet_On_Floor(Transform b, float r);
        public event Bullet_On_Floor On_Floor;

        // Use this for initialization
        void Start()
        {
            world = GetComponentInParent<World_Script>();
            On_Floor += world.Destroy_Enemy;
        }

        void Set_Angle()
        {
            pos = transform.position;
            float SinAngle2 = Vector3.Distance(target.position, transform.position) * gravity / (speed * speed);
            angle = (float)Math.Asin(SinAngle2 / 2);
            curr_speed = speed;
        }

        public void Shot(Transform target)
        {
            this.target = target;
            Set_Angle();
        }

        // Update is called once per frame
        void Update()
        {
                Ballistic_Trajectory();
        }

        void Ballistic_Trajectory()
        {
            t += Time.deltaTime;
            float vz = curr_speed * t * Mathf.Cos(angle);
            float vy = (curr_speed * t * Mathf.Sin(angle) - gravity * (t * t) / 2);
            transform.position = new Vector3(0, vy, vz) + pos;
            if (transform.position.y < 0)
            {
                On_Floor(transform, radius);
                if (floor_count < 2)
                {
                    floor_count++;
                    curr_speed /= 2;
                    t = 0;
                    pos = transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                }
                else
                {
                    world.Remove_Bullet(this);
                    Destroy(gameObject);
                }
            }
        }

        public float Get_Radius
        {
            get
            {
                return radius;
            }
        }
        public Transform Set_Target
        {
            set
            {
                target = value;
            }
        }
    }
}
