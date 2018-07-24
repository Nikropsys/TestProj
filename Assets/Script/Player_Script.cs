using UnityEngine;
using System.Collections;

namespace NikitaTovs
{
    public class Player_Script : MonoBehaviour
    {
        [SerializeField]
        Bullet_Script bullet;
        [SerializeField]
        World_Script world;
        float speed = 15f;
        int reload_time = 5;
        float reloading = 0;
        bool now_reloaded = true;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float move_x = Input.GetAxis("Horizontal");
            transform.position += new Vector3(move_x * Time.deltaTime * speed, 0);
            if (now_reloaded == false)
            {
                if (reloading < reload_time)
                    reloading += Time.deltaTime;
                else
                {
                    reloading = 0;
                    now_reloaded = true;
                }
            }
        }

        public void Shoot(Transform target)
        {
            if (now_reloaded == true)
            {
                now_reloaded = false;             
                Bullet_Script b = Instantiate<Bullet_Script>(bullet, transform.position, transform.rotation, world.transform);
                world.Add_Bullet(b);
                b.Shot(target);
            }
        }
    }
}
