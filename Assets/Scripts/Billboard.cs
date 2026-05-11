using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
    internal class Billboard : MonoBehaviour
    {
        [SerializeField] private BillboardType billboardType;
        public enum BillboardType { LookAtCamera, CameraForward }
        void LateUpdate()
        {
            switch (billboardType)
            {
                case BillboardType.LookAtCamera:
                    transform.LookAt(Camera.main.transform);
                    break;
                case BillboardType.CameraForward:
                    transform.forward = Camera.main.transform.forward;
                    break;
                default:
                    break;
            }
        }
    }
