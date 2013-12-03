using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiBo
{
  public class Charge
  {
    private DateTime changedAt;
    private decimal changeValue;
    private decimal currentValue;
    private uint transactionId;

    public Charge(DateTime changedAt, decimal currentValue, decimal changeValue)
    {
      this.changedAt = changedAt;
      this.currentValue = currentValue;
      this.changeValue = changeValue;
    }

    public DateTime ChangeAt
    {
      get { return this.changedAt; }
      set { this.changedAt = value; }
    }

    public decimal ChangeValues
    {
      get { return this.changeValue; }
      set { this.changeValue = value; }
    }

    public decimal CurrentValue
    {
      get { return this.currentValue; }
      set { this.currentValue = value; }
    }

    public uint TransactionId
    {
      get { return this.transactionId; }
      set { this.transactionId = value; }
    }
  }
}