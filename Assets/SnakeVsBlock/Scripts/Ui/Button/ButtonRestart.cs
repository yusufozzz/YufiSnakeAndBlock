using UnityEngine.SceneManagement;

namespace SnakeVsBlock.Scripts.Ui.Button
{
    public class ButtonRestart: ButtonBase 
    {
        protected override void OnButtonClick()
        {
            base.OnButtonClick();
            GameManager.Instance.IsGameStarted = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}