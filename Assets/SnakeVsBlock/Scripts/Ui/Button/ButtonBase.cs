using UnityEngine;

namespace SnakeVsBlock.Scripts.Ui.Button
{
    public class ButtonBase: MonoBehaviour
    {
        private UnityEngine.UI.Button _button;
        protected UnityEngine.UI.Button Button => _button ? _button : (_button = GetComponent<UnityEngine.UI.Button>());
        protected void OnEnable()
        {
            Button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            Button.onClick.RemoveListener(OnButtonClick);
        }
        
        protected virtual void OnButtonClick()
        {
            
        }
    }
}