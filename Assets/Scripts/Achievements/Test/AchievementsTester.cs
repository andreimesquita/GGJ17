using System.Collections.Generic;
using UnityEngine;

namespace Achievements.Test
{
    public class AchievementsTester : MonoBehaviour
    {
        [SerializeField]
        private MissionsSo Database;
        
        private float initialPlayTime;

        private List<Mission> completedMissions = new List<Mission>();

        [Range(0, 2)]
        public float spaceshipsCounter = 0;

        private void OnEnable()
        {
            Database.ResetGameValues();
        }

        private void Start()
        {
            initialPlayTime = Time.time;
        }

        private void FixedUpdate()
        {
            Database.Persist(MissionType.CURRENT_SPACESHIPS_PLAYING, spaceshipsCounter);

            Database.Increment(MissionType.TOTAL_GAME_PLAYED, Time.time - initialPlayTime);

            Database.Persist(MissionType.TOTAL_GAME_PLAYED_IN_CURRENT_GAME, Time.time - initialPlayTime);

            if (Database.FindCompletedMissions(ref completedMissions))
            {
                foreach (Mission mission in completedMissions)
                {
                    Debug.Log(mission);
                }
            }
        }
    }
}