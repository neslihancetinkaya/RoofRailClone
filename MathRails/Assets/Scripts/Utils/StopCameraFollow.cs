using Cinemachine;
using Player;
using UnityEngine;

namespace Utils
{
    public class StopCameraFollow : MonoBehaviour
    {
        [SerializeField] private PlayerController Player;
        [SerializeField] private CinemachineVirtualCamera VirtualCam;
        [SerializeField] private Transform VirtualTransform;
        
        public void StopFollowLook()
        {
            VirtualTransform.position = Player.transform.position;
            VirtualCam.Follow = VirtualTransform;
            //VirtualCam.LookAt = VirtualTransform;
        }
    }
}