using System;

namespace Assets.Homeworks.Homework_8_EventBus
{
    public abstract class Task
    {
        private Action _callback;
        
        public void Run(Action callback)
        {
            _callback = callback;
            
            OnRun();
        }

        protected abstract void OnRun();

        protected void Finish()
        {
            if (_callback is not null)
            {
                Action cachedCallback = _callback;
                _callback = null;
                
                cachedCallback.Invoke();
            }
            
            OnFinish();
        }

        protected virtual void OnFinish()
        {
            
        }
    }
}