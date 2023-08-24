using System;
using SnakeVsBlock.Scripts.Snake;
using SnakeVsBlock.Scripts.Snake.Segment;
using UnityEngine;

namespace SnakeVsBlock.Scripts.Ui.Button
{
    public class ButtonSelectType: ButtonBase
    {
        [SerializeField]
        private SegmentDataSo segmentDataSo;

        private void Awake()
        {
            Button.image.sprite = segmentDataSo.Icon;
        }

        protected override void OnButtonClick()
        {
            base.OnButtonClick();
            GameManager.Instance.SnakeController.ChangeType(segmentDataSo);
            GameManager.Instance.StartGame();
            transform.parent.gameObject.SetActive(false);
        }
    }
}