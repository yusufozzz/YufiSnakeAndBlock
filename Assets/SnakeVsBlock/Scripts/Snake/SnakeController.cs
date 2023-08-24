using System;
using System.Collections.Generic;
using System.Linq;
using SnakeVsBlock.Scripts.Snake.Modules;
using SnakeVsBlock.Scripts.Snake.Segment;
using UnityEngine;

namespace SnakeVsBlock.Scripts.Snake
{
	public class SnakeController : MonoBehaviour
	{
		[field: SerializeField]
		public SnakeData SnakeData { get; private set; }
		
		private readonly List<ModuleBase> _modules = new ();

		public SegmentDataSo SegmentDataSo { get; private set; }

		public T GetModule<T>() where T : ModuleBase
		{
			return _modules.OfType<T>().FirstOrDefault();
		}

		public void Init()
		{
			_modules.AddRange(GetComponents<ModuleBase>());
			foreach (var module in _modules)
			{
				module.Init(this);
			}
		}

		private void Update()
		{
			if (!GameManager.Instance.IsGameStarted) return;
			foreach (var module in _modules)
			{
				module.Tick();
			}
		}

		public void ChangeType(SegmentDataSo segmentDataSo)
		{
			SegmentDataSo = segmentDataSo;
		}
	}
}
