using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace ExpressionBinder;

public class Entity:INotifyPropertyChanged
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
            this.SendChangeInfo("Field");
            this.SendChangeInfo("Field2");
        }
    }
    
    private string m_Filed2 = "DefaultValue";

    public string Field2
    {
        get
        {
            return this.m_Filed;
        }
        set
        {
            this.m_Filed = value;
            this.SendChangeInfo("Field");
            this.SendChangeInfo("Field2");
        }
    }
 
    private void SendChangeInfo(string propertyName)
    {
        if (this.PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
            this.SendChangeInfo("Decimal");
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
            this.SendChangeInfo("Bool");
        }
    }
 
    public event PropertyChangedEventHandler PropertyChanged;
}