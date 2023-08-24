using System;
using SnakeVsBlock.Scripts.Ui;
using UnityEngine;
namespace SnakeVsBlock.Scripts.Snake.Modules
{
    public class SnakeMovement : ModuleBase
    {
        [SerializeField]
        private JoystickPanel joystickPanel;
        
        private float _defaultXPos;
        private float _touchDelta;
        private Vector2 _lastMousePosition;
        private float _snakeHorizontalSpeed;
        private float _snakeVerticalSpeed;
        private float _roadLimit;

        private readonly float _smoothedFactor = 12.5f;
        private float Delay => 1 / _smoothedFactor;
        public override void Init(SnakeController snakeController)
        {
            base.Init(snakeController);
            _snakeHorizontalSpeed = SnakeController.SnakeData.SnakeHorizontalSpeed;
            _snakeVerticalSpeed = SnakeController.SnakeData.SnakeVerticalSpeed;
            _roadLimit = SnakeController.SnakeData.RoadLimit;
            SetDefaultXPos();
            joystickPanel.OnDragEnd += SetDefaultXPos;
        }

        private void SetDefaultXPos()
        {
            _defaultXPos = transform.position.x;
        }

        public override void Tick()
        {
            if (SnakeController == null) return;
            MoveSnake();
        }

        private void MoveSnake()
        {
            var joystickValue = joystickPanel.TouchDelta;
            var newXPos = _defaultXPos + (joystickValue * _snakeHorizontalSpeed);
            var position = transform.position;
            var target = new Vector3(Mathf.Clamp(newXPos, -_roadLimit, _roadLimit), position.y, position.z);
            var distance = _snakeVerticalSpeed * Time.deltaTime;
            target.z += _smoothedFactor * distance;
            var smoothedTarget = Vector3.Lerp(position, target, Delay);
            transform.position = smoothedTarget;
        }

        private void OnDisable()
        {
            joystickPanel.OnDragEnd -= SetDefaultXPos;
        }
    }
}