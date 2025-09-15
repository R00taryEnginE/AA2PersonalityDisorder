using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA2PersonalityDisorder.Classes
{
    public class AppEventAggregator
    {
        private readonly Dictionary<Type, List<Delegate>> _subscribers = new Dictionary<Type, List<Delegate>>();

        public void Subscribe<T>(Action<T> handler)
        {
            var type = typeof(T);
            if (!_subscribers.ContainsKey(type))
                _subscribers[type] = new List<Delegate>();

            _subscribers[type].Add(handler);
        }

        public void Unsubscribe<T>(Action<T> handler)
        {
            var type = typeof(T);
            if (_subscribers.ContainsKey(type))
            {
                _subscribers[type].Remove(handler);
                if (_subscribers[type].Count == 0)
                    _subscribers.Remove(type);
            }
        }

        public void Publish<T>(T message)
        {
            var type = typeof(T);
            if (_subscribers.ContainsKey(type))
            {
                foreach (var subscriber in _subscribers[type])
                {
                    var action = subscriber as Action<T>;
                    if (action != null)
                    {
                        action(message);
                    }
                }
            }
        }
    }

    public class StatusMessage
    {
        public string Text { get; set; }
        public StatusMessage(string text) { Text = text; }
    }

    public class ErrorMessage
    {
        public string Text { get; set; }
        public Exception Exception { get; set; }
        public ErrorMessage(string text, Exception ex)
        {
            Text = text;
            Exception = ex;
        }
    }

    public class ProgressMessage
    {
        public int Percentage { get; set; }
        public ProgressMessage(int percent) { Percentage = percent; }
    }

}
