using TMPro;
using UnityEngine;

namespace Assets.Scripts.Player
{
    internal class PlayerHPUI : MonoBehaviour 
    {
        public Health pHealth;
        public TextMeshProUGUI hpText;

        private void Update()
        {
            hpText.text = Mathf.CeilToInt(pHealth.CurrentHP).ToString();
        }
    }
}
