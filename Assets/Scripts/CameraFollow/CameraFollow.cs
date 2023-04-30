using Player;
using UnityEngine;

namespace CameraFollow
{
    public class CameraFollow : MonoBehaviour
    {
        private GameObject player;

        public void Init(PlayerMove playerMove)
        {
            player = playerMove.gameObject;
        }

        private void LateUpdate()
        {
            if(player==null)
                return;
            transform.position = new Vector3(player.transform.position.x,
                                             player.transform.position.y, transform.position.z);
        }
    }
}
