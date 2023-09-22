using UnityEngine;

namespace CameraFollow
{
    public class CameraFollow : MonoBehaviour
    {
        private Transform _player;

        public void Init(Transform player)
        {
            _player = player;
        }

        private void LateUpdate()
        {
            if(_player==null)
            {
                return;
            }

            transform.position = new Vector3(_player.position.x,
                                             _player.position.y, 
                                             transform.position.z);
        }
    }
}
