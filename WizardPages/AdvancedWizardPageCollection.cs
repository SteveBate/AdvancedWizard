using System;
using System.Collections;
using AdvancedWizardControl.EventArguments;

namespace AdvancedWizardControl.WizardPages
{
    [Serializable]
    public class AdvancedWizardPageCollection : IList
    {
        public event EventHandler<WizardPageEventArgs> OnPageAdded;

        public AdvancedWizardPageCollection() : this(5) { }

        public AdvancedWizardPageCollection(Int32 initialCount) => _items = new ArrayList(initialCount);

        Boolean IList.Contains(Object wizardPage) => _items.Contains(wizardPage);

        public Boolean Contains(AdvancedWizardPage page) => _items.Contains(page);

        public Int32 Count => _items.Count;

        public Boolean IsSynchronized => _items.IsSynchronized;

        public Object SyncRoot => _items.SyncRoot;

        public void CopyTo(AdvancedWizardPageCollection pages) => pages.Items.AddRange(Items);

        public void Clear() => _items.Clear();

        public Int32 IndexOf(AdvancedWizardPage page) => _items.IndexOf(page);

        public void Insert(Int32 index, AdvancedWizardPage page) => _items.Insert(index, page);

        public Boolean IsFixedSize => _items.IsFixedSize;

        public Boolean IsReadOnly => _items.IsReadOnly;

        public AdvancedWizardPage this[Int32 index]
        {
            get => (AdvancedWizardPage) _items[index];
            set => _items[index] = value;
        }

        Object IList.this[Int32 index]
        {
            get => this[index];
            set
            {
                var page = value as AdvancedWizardPage;
                if (page != null)
                    this[index] = page;
            }
        }

        public void CopyTo(Array array, Int32 index)
        {
            if (array.Length - index < Count)
            {
                throw new ArgumentException("The Array to Copy To must have enough elements to copy all the items from this collection.", nameof(array));
            }

            for (Int32 i = 0; i < Count; i++)
            {
                array.SetValue(_items[i], index + i);
            }
        }

        public Int32 Add(AdvancedWizardPage page)
        {
            OnPageAdded?.Invoke(this, new WizardPageEventArgs(page));
            return _items.Add(page);
        }

        public void Remove(AdvancedWizardPage page) => _items.Remove(page);

        public void RemoveAt(Int32 index) => _items.RemoveAt(index);

        public IEnumerator GetEnumerator() => _items.GetEnumerator();

        public IEnumerator GetEnumerator(Int32 index, Int32 count) => _items.GetEnumerator(index, count);

        internal ArrayList Items => _items;

        Int32 IList.IndexOf(Object @object) => _items.IndexOf(@object);

        Int32 IList.Add(Object @object)
        {
            var o = @object as AdvancedWizardPage;
            if (o == null) return -1;
            return Add(o);
        }

        void IList.Insert(Int32 index, Object @object)
        {
            if (!(@object is AdvancedWizardPage))
            {
                throw new ArgumentException("This collection can only contain WizardPage objects.", nameof(@object));
            }

            _items.Insert(index, @object);
        }

        void IList.Remove(Object @object)
        {
            if (!(@object is AdvancedWizardPage)) return;
            _items.Remove(@object);
        }

        private readonly ArrayList _items;
    }
}