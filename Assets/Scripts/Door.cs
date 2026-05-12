using Assets.Scripts.Player;
using System.Collections;

using UnityEngine;

namespace Assets.Scripts
{
    internal class Door : MonoBehaviour
    {
        public GameObject openPosition;
        public GameObject closePosition;
        public float openSpeed = 2f;
        public float _currentPositionY;
        public bool canInteract = false;
        private Vector3 openPos;
        private Vector3 closePos;
        public GameObject Ktext;
        public bool isMoving;
        public Inventory inventory;

        IEnumerator Fade()
        {
            Ktext.SetActive(true);
            yield return new WaitForSeconds(2f);
            Ktext.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
                if (inventory.hasBlueKey)
                {
                    Debug.Log("You have opened the door!");     
                }
                else
                {
                    StartCoroutine(Fade());
                }
            canInteract = true;
        }
        private void OnTriggerExit(Collider other)
        {
            canInteract = false;
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && inventory.hasBlueKey && canInteract && !isMoving)
            {
                StartCoroutine(OpenDoor());
            }
        }
        
        IEnumerator OpenDoor()
        {
            isMoving = true;
            openPos = openPosition.transform.position;
            closePos = closePosition.transform.position;
            while (Vector3.Distance(transform.position, openPos) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    openPos,
                    openSpeed * Time.deltaTime
                );

                yield return null;
            }

            transform.position = openPos;
            yield return new WaitForSeconds(3f);

            while (Vector3.Distance(transform.position, closePos) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    closePos,
                    openSpeed * Time.deltaTime
                );

                yield return null;
            }

            transform.position = closePos;
            isMoving = false;

        }
        
    }
}
