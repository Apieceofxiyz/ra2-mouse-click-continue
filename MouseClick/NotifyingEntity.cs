using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MouseClick
{
    public abstract class NotifyingEntity : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private Dictionary<string, object> property = new Dictionary<string, object>();

        protected bool ContainsProperty([CallerMemberName] string propertyName = "")
        {
            return property.ContainsKey(propertyName);
        }

        protected void SetValueWithNotify(object value, [CallerMemberName] string propertyName = "")
        {
            NotifyChanging(propertyName);
            if (property.ContainsKey(propertyName))
            {
                property[propertyName] = value;
            }
            else
            {
                property.Add(propertyName, value);
            }
            NotifyChanged(propertyName);
        }

        protected T GetValue<T>([CallerMemberName] string propertyName = "")
            => property.ContainsKey(propertyName) ? (T)property[propertyName] : default;

        public event PropertyChangingEventHandler PropertyChanging;
		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyChanged(string propertyName)
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

		private void NotifyChanging(string propertyName)
			=> PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
	}
}
