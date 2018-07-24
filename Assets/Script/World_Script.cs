using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NikitaTovs
{
    public class World_Script : MonoBehaviour
    {
        [SerializeField]
        Player_Script player;
        public List<Bullet_Script> bull_list;
        public List<Enemy_Script> enemy_list;

        private void Awake()
        {
            bull_list = new List<Bullet_Script>();
            enemy_list = new List<Enemy_Script>();
        }
        // Use this for initialization
        void Start()
        { 
            player = GetComponentInChildren<Player_Script>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Add_Bullet(Bullet_Script b)
        {

            bull_list.Add(b);
        }

        public void Add_Enemy(Enemy_Script en)
        {
            enemy_list.Add(en);
        }

        public void Remove_Bullet(Bullet_Script b)
        {
            bull_list.Remove(b);
        }

        public void RemoveEnemy(Enemy_Script en)
        {
            enemy_list.Remove(en);
        }

        public void Player_Shoot(Transform targ)
        {
            player.Shoot(targ);
        }

        public void Destroy_Enemy(Transform b, float r)
        {
            for (int i = 0; i <= enemy_list.Count - 1; i++)
                enemy_list[i].Check_Destroy(b, r);
        }

        public Transform Get_Player
        {
            get { return player.transform;}
        }
    }
}
