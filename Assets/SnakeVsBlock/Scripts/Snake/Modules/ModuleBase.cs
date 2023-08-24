using UnityEngine;

namespace SnakeVsBlock.Scripts.Snake.Modules
{
    public abstract class ModuleBase: MonoBehaviour
    {
        protected SnakeController SnakeController;

        public virtual void Init(SnakeController snakeController)
        {
            SnakeController = snakeController;
        }
        public abstract void Tick();
    }
}