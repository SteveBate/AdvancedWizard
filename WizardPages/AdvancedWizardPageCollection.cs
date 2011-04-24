using System;
using System.Collections;
using AdvancedWizardControl.EventArguments;

namespace AdvancedWizardControl.WizardPages
{
    [Serializable]
    public class AdvancedWizardPageCollection : IList
    {
        private readonly ArrayList _items;

        public event EventHandler<WizardPageEventArgs> OnPageAdded;

        #region public WizardPageCollection() : this(5)

        /// <summary>
        ///   Empty constructor. 
        ///   This will initialize the collection to 5 items.
        /// </summary>		
        public AdvancedWizardPageCollection() : this(5)
        {
        }

        #endregion

        #region public WizardPageCollection(System.Int32 initialCount)

        /// <summary>
        ///   Initializes the container to hold the specified number of items.
        /// </summary>
        /// <param name="initialCount">
        ///   The initial size of the collection. 
        /// </param>
        public AdvancedWizardPageCollection(Int32 initialCount)
        {
            _items = new ArrayList(initialCount);
        }

        #endregion

        #region public System.Boolean Contains(WizardPage page)

        /// <summary>
        ///   For IList implementation only. Do not use.
        /// </summary>
        Boolean IList.Contains(Object wizardPage)
        {
            return _items.Contains(wizardPage);
        }

        /// <summary>
        ///   Attempts to locate the WizardPage within the collection.
        /// </summary>
        /// <param name="page">
        ///   WizardPage to locate.
        /// </param>
        /// <returns>
        ///   True if the WizardPage exists in the collection.
        /// </returns>
        public Boolean Contains(AdvancedWizardPage page)
        {
            return _items.Contains(page);
        }

        #endregion

        #region public WizardPage this[System.Int32 index]

        /// <summary>
        ///   Gets or Sets items in this collection.
        /// </summary>
        public AdvancedWizardPage this[Int32 index]
        {
            get { return (AdvancedWizardPage) _items[index]; }
            set { _items[index] = value; }
        }

        /// <summary>
        ///   For IList implementation purposes only.
        /// </summary>
        Object IList.this[Int32 index]
        {
            get { return this[index]; }
            set
            {
                if (value is AdvancedWizardPage)
                    this[index] = (AdvancedWizardPage) value;
            }
        }

        #endregion

        #region public void CopyTo(System.Array array, System.Int32 index)

        /// <summary>
        ///   Copies the items from this collection into the array at the specified index.
        /// </summary>
        /// <param name="array">
        ///   Array to copy the items to.
        /// </param>
        /// <param name="index">
        ///   Index of position within the array to being copying at.
        /// </param>
        public void CopyTo(Array array, Int32 index)
        {
            if ((array.Length - index) >= Count)
            {
                for (Int32 i = 0; i < Count; i++)
                {
                    array.SetValue(_items[i], index + i);
                }
            }
            else
                throw new ArgumentException(
                    "The Array to Copy To must have enough elements to copy all the items from this collection.",
                    "Array");
        }

        #endregion

        #region public void CopyTo(WizardPageCollection pages)

        /// <summary>
        ///   Copies all the WizardPages from this collection to another WizardPage Collection.
        /// </summary>
        /// <param name="pages">
        ///   Collection to copy to.
        /// </param>
        public void CopyTo(AdvancedWizardPageCollection pages)
        {
            pages.Items.AddRange(Items);
        }

        #endregion

        #region internal System.Collections.ArrayList Items

        internal ArrayList Items
        {
            get { return _items; }
        }

        #endregion

        #region public System.Int32 Count

        /// <summary>
        ///   Returns the number of items contained in the collection.
        /// </summary>
        public Int32 Count
        {
            get { return _items.Count; }
        }

        #endregion

        #region public System.Boolean IsSynchronized

        /// <summary>
        ///   Gets a value indicating whether access to the Collection is synchronized (thread safe).
        /// </summary>
        public Boolean IsSynchronized
        {
            get { return _items.IsSynchronized; }
        }

        #endregion

        #region public System.Object SyncRoot

        /// <summary>
        ///   Gets an object that can be used to synchronize access to the Collection.
        /// </summary>
        public Object SyncRoot
        {
            get { return _items.SyncRoot; }
        }

        #endregion

        #region public System.Int32 Add(WizardPage page)

        /// <summary>
        ///   For IList implementation only. Do Not Use.
        /// </summary>
        Int32 IList.Add(Object @object)
        {
            if (@object is AdvancedWizardPage)
                return Add((AdvancedWizardPage) @object);
            return -1;
        }

        /// <summary>
        ///   Adds a page to the collection.
        /// </summary>
        /// <param name="page">
        ///   WizardPage to add to the collection.
        /// </param>
        /// <returns>
        ///   Index at which the WizardPage was added.
        /// </returns>
        public Int32 Add(AdvancedWizardPage page)
        {
            if (OnPageAdded != null)
                OnPageAdded(this, new WizardPageEventArgs(page));

            return _items.Add(page);
        }

        #endregion

        #region public void Clear()

        /// <summary>
        ///   Clears the collection.
        /// </summary>
        public void Clear()
        {
            _items.Clear();
        }

        #endregion

        #region public System.Int32 IndexOf(WizardPage page)

        /// <summary>
        ///   For IList implementation only. Do not use.
        /// </summary>
        Int32 IList.IndexOf(Object @object)
        {
            return _items.IndexOf(@object);
        }

        /// <summary>
        ///   Returns the index for the WizardPage within the collection.
        /// </summary>
        /// <param name="page">
        ///   WizardPage to locate within the collection.
        /// </param>
        /// <returns>
        ///   Index of the WizardPage.
        /// </returns>
        public Int32 IndexOf(AdvancedWizardPage page)
        {
            return _items.IndexOf(page);
        }

        #endregion

        #region public void Insert(System.Int32 index, WizardPage page)

        /// <summary>
        ///   For IList implementation only. Do not use.
        /// </summary>
        void IList.Insert(Int32 index, Object @object)
        {
            if (@object is AdvancedWizardPage)
            {
                _items.Insert(index, @object);
            }
            else
            {
                throw new ArgumentException("This collection can only contain WizardPage objects.", "object");
            }
        }

        /// <summary>
        ///   Inserts the WizardPage into the collection at the specified position.
        /// </summary>
        /// <param name="index">
        ///   Position at which to insert the page.
        /// </param>
        /// <param name="page">
        ///   WizardPage to insert.
        /// </param>
        public void Insert(Int32 index, AdvancedWizardPage page)
        {
            _items.Insert(index, page);
        }

        #endregion

        #region public System.Boolean IsFixedSize

        /// <summary>
        ///   Gets a value indicating whether the collection is a fixed size.
        /// </summary>
        public Boolean IsFixedSize
        {
            get { return _items.IsFixedSize; }
        }

        #endregion

        #region public System.Boolean IsReadOnly

        /// <summary>
        ///   Gets a value indicating whether the Collection is read-only.
        /// </summary>
        public Boolean IsReadOnly
        {
            get { return _items.IsReadOnly; }
        }

        #endregion

        #region public void Remove(WizardPage page)

        /// <summary>
        ///   For IList implementation only. Do not use.
        /// </summary>
        void IList.Remove(Object @object)
        {
            if (@object is AdvancedWizardPage)
            {
                _items.Remove(@object);
            }
        }

        /// <summary>
        ///   Removes the first occurrence of a specific WizardPage from the Collection.
        /// </summary>
        /// <param name="page">
        ///   The WizardPage to remove.
        /// </param>
        public void Remove(AdvancedWizardPage page)
        {
            _items.Remove(page);
        }

        #endregion

        #region public void RemoveAt(System.Int32 index)

        /// <summary>
        ///   Removes the element at the specified index of the Collection.
        /// </summary>
        /// <param name="index">
        ///   Index of the element to remove.
        /// </param>
        public void RemoveAt(Int32 index)
        {
            _items.RemoveAt(index);
        }

        #endregion

        #region public System.Collections.IEnumerator GetEnumerator()

        /// <summary>
        ///   Returns an enumerator that can iterate through the Collection.
        /// <returns>
        ///   An IEnumerator for the entire Collection.
        /// </returns>
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        #endregion

        #region public System.Collections.IEnumerator GetEnumerator(System.Int32 index, System.Int32 count)

        /// <summary>
        ///   Returns an enumerator that can iterate through the Collection.
        /// </summary>
        /// <param name="index">
        ///   The zero-based starting index of the Collection section that the enumerator should refer to. 
        /// </param>
        /// <param name="count">
        ///   The number of elements in the Collection section that the enumerator should refer to. 
        /// </param>
        /// <returns>
        ///   An IEnumerator for the specified section of the Collection.
        /// </returns>
        public IEnumerator GetEnumerator(Int32 index, Int32 count)
        {
            return _items.GetEnumerator(index, count);
        }

        #endregion

/*
			//the following code may need to be changed to fit the properties of your custom object used in this collection
			//in this collection, the custom objects have properites called 'Name' and 'Value'
			#region public void Remove(System.String name)
			/// <summary>
			///   Removes all WizardPages with the specified Name.
			/// </summary>
			/// <param name="name">
			///   Name of the WizardPage to remove.
			/// </param>
			public void Remove(System.String name)
			{
				for(System.Int32 i = items.Count - 1; i >= 0; i--)
				{
					if(((WizardPage)items[i]).Name == name)
					{
						items.RemoveAt(i);
					}
				}
			}
			#endregion

			#region public System.Int32 Add(System.String pageName, System.String pageValue)
			/// <summary>
			///   Adds a new WizardPage with the Name and Value specified.
			/// </summary>
			/// <param name="pageName">
			///   Name of the new WizardPage.
			/// </param>
			/// <param name="pageValue">
			///   Value of the new WizardPage.
			/// </param>
			/// <returns>
			///   Index within the collection fo the new page.
			/// </returns>
			public System.Int32 Add(System.String pageName, System.String pageValue)
			{
				WizardPage
					page = new WizardPage( );
				page.Name = pageName;
				//page.Value = pageValue;
				return items.Add(page);
			}
			#endregion

			#region public System.Boolean Contains(System.String name)
			/// <summary>
			///   Returns true if the specified page is contained within the collection.
			/// </summary>
			/// <param name="name">
			///   Name of the page to look for in the collection.
			/// </param>
			/// <returns>
			///   True if the page is contained in the collection.
			/// </returns>
			public System.Boolean Contains(System.String name)
			{
				for(System.Int32 i = 0; i < items.Count; i++)
				{
					if(((WizardPage)items[i]).Name == name)
					{
						return true;
					}
				}
				return false;
			}
			#endregion

			#region public System.Int32 IndexOf(System.String name)
			/// <summary>
			///   Returns the index for the WizardPage with the given name within the collection.
			/// </summary>
			/// <param name="name">
			///   Name of the WizardPage to locate within the collection.
			/// </param>
			/// <returns>
			///   Index of the WizardPage with the given Name.
			/// </returns>
			public System.Int32 IndexOf(System.String name)
			{
				for(System.Int32 i = 0; i < items.Count; i++)
				{
					if(((WizardPage)items[i]).Name == name)
					{
						return i;
					}
				}
				return -1;
			}
			#endregion

			#region public WizardPage this[System.String name]
			/// <summary>
			///   Returns the page with the specified name.
			/// </summary>
			public WizardPage this[System.String name]
			{
				get
				{
					WizardPage
						page = null;

					System.String
						lower = name.ToLower();

					for(System.Int32 i = 0; i < items.Count; i++)
					{
						if( ((WizardPage)items[i]).Name.ToLower() == lower)
						{
							return (WizardPage)items[i];
						}
					}

					return page;
				}
			}
			#endregion
*/
    }
}