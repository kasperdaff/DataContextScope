﻿using System.Data;
using System.Data.Common;
using System.Data.Linq;

namespace Numero3.EntityFramework.Implementation
{
  public static class DataContextExtensions
  {
    public static DbTransaction BeginTransaction(this DataContext dbContext, IsolationLevel level)
    {
      DbTransaction transaction = dbContext.Connection.BeginTransaction(level);
      dbContext.Transaction = transaction;
      return transaction;
    }

    public static int SaveChanges(this DataContext dbContext)
    {
      dbContext.SubmitChanges();
      //TODO: I suspect it is supposed to return number of affected rows,
      // see if that is possible using Linq to SQL.
      return 0;
    }
  }

  public interface IDataContextAdapter
  {
    DataContext DataContext { get; }
  }
}