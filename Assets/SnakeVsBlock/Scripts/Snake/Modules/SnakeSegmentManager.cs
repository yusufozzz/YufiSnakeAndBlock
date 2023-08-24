using System.Collections.Generic;
using System.Linq;
using SnakeVsBlock.Scripts.Snake.Segment;
using UnityEngine;

namespace SnakeVsBlock.Scripts.Snake.Modules
{
    public class SnakeSegmentManager : ModuleBase
    {
        [SerializeField]
        private Segment.Segment segmentPrefab;

        [SerializeField]
        private int initialSegmentCount;

        private List<Segment.Segment> _segments = new();
        private List<Vector3> _segmentPositions = new();

        private float _arriveDistance;

        public override void Init(SnakeController snakeController)
        {
            base.Init(snakeController);
            SetArriveDistance();
            SetSegmentsType();
            for (int i = 0; i < initialSegmentCount; i++)
            {
                AddSegment();
            }
            _segmentPositions.Add(SnakeController.transform.position);
        }

        private void SetArriveDistance()
        {
            _arriveDistance = SnakeController.SegmentDataSo.ArriveDistance;
        }

        private void SetSegmentsType()
        {
            segmentPrefab.GetComponent<MeshRenderer>().sharedMaterial.mainTexture = SnakeController.SegmentDataSo.Icon.texture;
        }

        private void AddSegment()
        {
            var newSegment = Instantiate(segmentPrefab);
            _segments.Add(newSegment);
            _segmentPositions.Add(newSegment.transform.position);
        }

        public override void Tick()
        {
            RecordSegmentPositions();
            MoveSegments();
        }

        private void RecordSegmentPositions()
        {
            _segmentPositions.Insert(0, SnakeController.transform.position);
            float totalDistance = 0;
            for (int i = 0; i < _segmentPositions.Count - 1; i++)
            {
                totalDistance += Vector3.Distance(_segmentPositions[i], _segmentPositions[i + 1]);
                if (totalDistance > (_arriveDistance * _segments.Count) + 10)
                {
                    _segmentPositions.RemoveAt(_segmentPositions.Count - 1);
                    break;
                }
            }
        }

        private void MoveSegments()
        {
            float distance = 0;
            int positionIndex = 0;
            for (int i = 0; i < _segments.Count; i++)
            {
                distance += _arriveDistance;
                while (positionIndex < _segmentPositions.Count - 1 && Vector3.Distance(_segmentPositions[positionIndex], _segmentPositions[positionIndex + 1]) < distance)
                {
                    distance -= Vector3.Distance(_segmentPositions[positionIndex], _segmentPositions[positionIndex + 1]);
                    positionIndex++;
                }

                if (positionIndex < _segmentPositions.Count - 1)
                {
                    var segment = _segments[i];
                    segment.Move(_segmentPositions[positionIndex], _segmentPositions[positionIndex + 1], distance);
                    var target = (i == 0) ? SnakeController.transform : _segments[i - 1].transform;
                    segment.Rotate(target.position);
                }
            }
        }
    }
}