using UnityEngine;

namespace Shipov_Snake
{
    internal sealed class Timer
    {
        public float EndTime;
        public bool IsOn;

        public float CurrentTime { get; private set; }

        public void Init(float time)
        {
            EndTime = time;
            IsOn = true;
        }

        private void Reset()
        {
            CurrentTime = 0.0f;
            IsOn = false;
        }

        public void CountTime()
        {
            if (IsOn)
            {
                if (CurrentTime < EndTime)
                {
                    CurrentTime += Time.deltaTime;
                }
                else
                {
                    Reset();
                }
            }
        }

        public void AutoCount(float time)
        {
            if (!IsOn)
            {
                Init(time);
            }

            if (CurrentTime < EndTime)
            {
                CurrentTime += Time.deltaTime;
            }
            else
            {
                Reset();
            }
        }
    }
}
