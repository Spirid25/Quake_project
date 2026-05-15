using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
namespace Assets.Scripts.Weapon
{
    public class WeaponRecoil : MonoBehaviour
    {
        public float recoilReturnSpeed = 12f;
        public float recoilForce = 0.1f;
        public float recoilKickUp = 0.05f;

        private Vector3 initialposition;
        private Vector3 targetPosition;

        public void Start()
        {
            initialposition = transform.localPosition;
        }
        void Update()
        {
            targetPosition = Vector3.Lerp(targetPosition, Vector3.zero, Time.deltaTime * recoilReturnSpeed);
            transform.localPosition = Vector3.Lerp(transform.localPosition, initialposition + targetPosition, Time.deltaTime * recoilReturnSpeed);
        }
        public void AddRecoil()
        {
            targetPosition = new Vector3(0, recoilKickUp, recoilForce);
        }

    }
}
