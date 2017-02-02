using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Timer : MonoBehaviour {

        public delegate void TimerInvokeFunction();

        private class TimerInvokeFunctionContext
        {
            public int Id { get; private set; }

            public float TimeLeft { get; set; }

            public TimerInvokeFunction CallbackFunction { get; private set; }

            public TimerInvokeFunctionContext(int id, float timeLeft, TimerInvokeFunction callbackFunction)
            {
                this.Id = id;
                this.TimeLeft = timeLeft;
                this.CallbackFunction = callbackFunction;
            }
        }

        private Dictionary<int, TimerInvokeFunctionContext> registeredCallbackFunctions;
        private int counter;

        private void Awake()
        {
            this.registeredCallbackFunctions = new Dictionary<int, TimerInvokeFunctionContext>();
        }

        private void Update()
        {
            if (registeredCallbackFunctions.Count == 0) return;

            List<int> callbacksToRemove = new List<int>();

            foreach (TimerInvokeFunctionContext context in registeredCallbackFunctions.Values)
            {
                float decreasedTime = context.TimeLeft - Time.deltaTime;

                if (decreasedTime < 0.0f)
                {
                    callbacksToRemove.Add(context.Id);

                    context.CallbackFunction.Invoke();
                }
                else
                {
                    context.TimeLeft = decreasedTime;
                }
            }

            for (int i = 0; i < callbacksToRemove.Count; i++)
            {
                registeredCallbackFunctions.Remove(callbacksToRemove[i]);
            }
        }

        public int RegisterCallback(float timeToWait, TimerInvokeFunction callbackFunction)
        {
            TimerInvokeFunctionContext context = new TimerInvokeFunctionContext(counter, timeToWait, callbackFunction);

            this.registeredCallbackFunctions.Add(counter++, context);

            return counter;
        }

        public void UnregisterCallback(int id)
        {
            if (this.registeredCallbackFunctions.ContainsKey(id))
            {
                this.registeredCallbackFunctions.Remove(id);
            }
        }
    }
}
