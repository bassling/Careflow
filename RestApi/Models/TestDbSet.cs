using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    // TestDbSet
    // This allows a simple dataset to look like a DbSet
    public class TestDbSet<T> : IDbSet<T> where T : class
    {
        private ObservableCollection<T> dataSet;
        private IQueryable query;

        public TestDbSet()
        {
            dataSet = new ObservableCollection<T>();
            query = dataSet.AsQueryable();
        }

        public virtual T Find(params object[] keyValues)
        {
            throw new NotImplementedException("Derive new class from TestDbSet and override Find");
        }

        public T Add(T item)
        {
            dataSet.Add(item);
            return item;
        }

        public T Remove(T item)
        {
            dataSet.Remove(item);
            return item;
        }

        public T Attach(T item)
        {
            dataSet.Add(item);
            return item;
        }

        public T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        public ObservableCollection<T> Local
        {
            get { return dataSet; }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return dataSet.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return dataSet.GetEnumerator();
        }

        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { return query.Expression; }
        }

        Type IQueryable.ElementType
        {
            get
            {
                return query.ElementType;
            }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return query.Provider; }
        }

    }
}