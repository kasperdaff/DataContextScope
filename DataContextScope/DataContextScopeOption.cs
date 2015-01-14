﻿/* 
 * Copyright (C) 2014 Mehdi El Gueddari
 * http://mehdi.me
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
namespace Geturi.Data.Linq
{
    /// <summary>
    /// Indicates whether or not a new DataContextScope will join the ambient scope.
    /// </summary>
    public enum DataContextScopeOption
    {
        /// <summary>
        /// Join the ambient DataContextScope if one exists. Creates a new
        /// one otherwise.
        /// 
        /// This is what you want in most cases. Joining the existing ambient scope
        /// ensures that all code within a business transaction uses the same DataContext
        /// instance and that all changes made by service methods called within that 
        /// business transaction are either committed or rolled back atomically when the top-level
        /// scope completes (i.e. it ensures that there are no partial commits). 
        /// </summary>
        JoinExisting,

        /// <summary>
        /// Ignore the ambient DataContextScope (if any) and force the creation of 
        /// a new DataContextScope. 
        /// 
        /// This is an advanced feature that should be used with great care. 
        /// 
        /// When forcing the creation of a new scope, new DataContext instances will be 
        /// created within that inner scope instead of re-using the DataContext instances that
        /// the parent scope (if any) is using. 
        /// 
        /// Any changes made to entities within that inner scope will therefore get persisted 
        /// to the database when SaveChanges() is called in the inner scope regardless of wether 
        /// or not the parent scope is successful.
        /// 
        /// You would typically do this to ensure that the changes made within the inner scope 
        /// are always persisted regardless of the outcome of the overall business transaction
        /// (e.g. to persist the results of an operation, such as a remote API call, that
        /// cannot be rolled back or to persist audit or log entries that must not be rolled back
        /// regardless of the outcome of the business transaction). 
        /// </summary>
        ForceCreateNew
    }
}
