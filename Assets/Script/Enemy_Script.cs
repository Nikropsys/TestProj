using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NikitaTovs
{
    public class Enemy_Script : MonoBehaviour
    {
        [SerializeField]
        Transform player;
        [SerializeField]
        World_Script world;
        float distance = 15f;
        public delegate void Shoot_Me(Transform enemy);
        public event Shoot_Me On_Shoot;

        // Use this for initialization
        void Start()
        {
            world = GetComponentInParent<World_Script>();
            world.Add_Enemy(this);
            player = world.Get_Player;
            On_Shoot += world.Player_Shoot;
        }

        // Update is called once per frame
        void Update()
        {
            if (Vector3.Distance(transform.position, player.position) <= distance)
                On_Shoot(transform);
        }

        public void Check_Destroy(Transform b, float radius)
        {
            if(Vector3.Distance(transform.position, b.transform.position) <= radius)
            {
                world.RemoveEnemy(this);
                Destroy(gameObject);
            }
        }
   
        public float Set_Distance
        {
            set
            {
                distance = value;
            }
        }
    }
}
