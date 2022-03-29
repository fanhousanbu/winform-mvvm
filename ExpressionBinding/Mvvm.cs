using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace ExpressionBinding
{

    public abstract class ViewModelNotification : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Entity : ViewModelNotification
    {
        private string m_Filed = "DefaultValue";
        public string Field
        {
            get
            {
                return this.m_Filed;
            }
            set
            {
                this.m_Filed = value;
                this.OnPropertyChanged("Field");
            }
        }        

        private decimal m_Decimal = (decimal)60.01;
        public decimal Decimal
        {
            get
            {
                return this.m_Decimal;
            }
            set
            {
                this.m_Decimal = value;
                this.OnPropertyChanged("Decimal");
            }
        }

        private bool m_Bool = false;
        public bool Bool
        {
            get
            {
                return this.m_Bool;
            }
            set
            {
                this.m_Bool = value;
                this.OnPropertyChanged("Bool");
            }
        }

    }

    public static class Ext
    {
        private static ControlBindingsCollection PreBinds<T>(this ControlBindingsCollection collection, Expression<Func<T>> view)
        {
            var lst = new List<Binding>();
            foreach (var v in collection)
            {
                var binded = v as Binding;
                if (binded?.PropertyName.Equals(PropertyName(view)) == true)
                {
                    lst.Add(binded);
                }
            }
            lst.ForEach(r => collection.Remove(r));

            return collection;
        }
        public static void Bind<TEntity, T>(this Control ctrl, TEntity entity, Expression<Func<T>> view, Expression<Func<T>> model)
        {
            ctrl.DataBindings.PreBinds(view).Add(PropertyName(view),
                entity,
                PropertyName(model),
                false,
                DataSourceUpdateMode.OnPropertyChanged
            );
        }

        private static string PropertyName<T>(Expression<Func<T>> property) =>
            (property.Body as MemberExpression)?.Member.Name;
    }
}
