using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data;
using CNT.Models.DataInterfaces;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.IO;
using System.Web;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using CNT.Exceptions;

namespace CNT.DataLayer
{
    public abstract class Repository<TObject> : IRepository<TObject>
    where TObject : class
    {
        protected Context Context = null;
        public Repository(Context context)
        {
            Context = context;
        }
        protected DbSet<TObject> DbSet
        {
            get
            {
                try
                {
                    return Context.Set<TObject>();
                }
                catch (Exception ex)
                {
                    throw new SQLException(ex.Message);
                }
            }
        }
        public virtual IQueryable<TObject> All()
        {
            try
            {
                IQueryable<TObject> RetObj = DbSet.AsQueryable();
                if (RetObj.Count() > 0)
                    return RetObj;
                else
                    throw new SQLNoRecordExeption("There are no relevant records available");

            }
            catch (SQLNoRecordExeption ex)
            {
                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLNoRecordExeption(ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLException(ex.Message);
            }

        }
        public virtual IQueryable<TObject> All(params Expression<Func<TObject, object>>[] includeExpressions)
        {
            try
            {
                IQueryable<TObject> RetObj = DbSet.AsQueryable();
                foreach (var includeExpression in includeExpressions)
                {
                    if (RetObj.Count() > 0)
                        RetObj = RetObj.Include(includeExpression);
                }
                if (RetObj.Count() > 0)
                    return RetObj;
                else
                    throw new SQLNoRecordExeption("There are no relevant records available");

            }
            catch (SQLNoRecordExeption ex)
            {
                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLNoRecordExeption(ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLException(ex.Message);
            }

        }
        public virtual IQueryable<TObject> Filter(Expression<Func<TObject, bool>> predicate)
        {
            try
            {
                IQueryable<TObject> RetObj = DbSet.Where(predicate).AsQueryable<TObject>();
                if (RetObj.Count() > 0)
                    return RetObj;
                else
                    throw new SQLNoRecordExeption("There are no relevant records available");
            }
            catch (SQLNoRecordExeption ex)
            {
                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLNoRecordExeption(ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLException(ex.Message);
            }
        }
        public virtual IQueryable<TObject> Filter(Expression<Func<TObject, bool>> predicate, params Expression<Func<TObject, object>>[] includeExpressions)
        {
            try
            {
                IQueryable<TObject> RetObj = DbSet.Where(predicate).AsQueryable<TObject>();
                foreach (var includeExpression in includeExpressions)
                {
                    RetObj = RetObj.Include(includeExpression);
                }
                if (RetObj.Count() > 0)
                    return RetObj;
                else
                    throw new SQLNoRecordExeption("There are no relevant records available");
            }
            catch (SQLNoRecordExeption ex)
            {
                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLNoRecordExeption(ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLException(ex.Message);
            }
        }
        public virtual IQueryable<TObject> Filter(Expression<Func<TObject, bool>> filter, out int total, int index = 0, int size = 50)
        {
            try
            {
                int skipCount = index * size;
                var _resetSet = filter != null ? DbSet.Where(filter).AsQueryable() : DbSet.AsQueryable();
                _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
                total = _resetSet.Count();
                IQueryable<TObject> RetObj = _resetSet.AsQueryable();
                if (RetObj.Count() > 0)
                    return RetObj;
                else
                    throw new SQLNoRecordExeption("There are no relevant records available");
            }
            catch (SQLNoRecordExeption ex)
            {
                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLNoRecordExeption(ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLException(ex.Message);
            }


        }
        public virtual IQueryable<TObject> Filter(Expression<Func<TObject, bool>> filter, Expression<Func<TObject, object>> sortby, out int total, int index = 0, int size = 50)
        {
            try
            {
                int skipCount = index * size;
                var _resetSet = filter != null ? DbSet.Where(filter).OrderBy(sortby).AsQueryable() : DbSet.AsQueryable();
                _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
                total = _resetSet.Count();
                IQueryable<TObject> RetObj = _resetSet.AsQueryable();
                if (RetObj.Count() > 0)
                    return RetObj;
                else
                    throw new SQLNoRecordExeption("There are no relevant records available");
            }
            catch (SQLNoRecordExeption ex)
            {
                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLNoRecordExeption(ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLException(ex.Message);
            }

        }
        public virtual IQueryable<TObject> FilterNoException(Expression<Func<TObject, bool>> predicate)
        {
            try
            {
                IQueryable<TObject> RetObj = DbSet.Where(predicate).AsQueryable<TObject>();
                return RetObj;
            }
            //catch (SQLNoRecordExeption ex)
            //{
            //    if (ex.InnerException != null)
            //        LogError(ex.InnerException.InnerException.Message);
            //    else
            //        LogError(ex.Message);
            //    throw new SQLNoRecordExeption(ex.Message);
            //}
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLException(ex.Message);
            }
        }
        public bool Contains(Expression<Func<TObject, bool>> predicate)
        {
            try
            {
                IQueryable<TObject> RetObj = DbSet.Where(predicate).AsQueryable<TObject>();
                if (RetObj.Count() > 0)
                    return true;
                else
                    throw new SQLInvalidRecordException("no relevant records");
            }
            catch (SQLInvalidRecordException ex)
            {
                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLInvalidRecordException(ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLException(ex.Message);
            }

        }
        public virtual TObject Find(params object[] keys)
        {
            try
            {
                TObject RetObj = DbSet.Find(keys);
                if (RetObj != null)
                    return RetObj;
                else
                    throw new SQLInvalidRecordException("There are no relevant records available");
            }
            catch (SQLInvalidRecordException ex)
            {
                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLInvalidRecordException(ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLException(ex.Message);
            }

        }
        public virtual TObject Find(Expression<Func<TObject, bool>> predicate)
        {
            try
            {
                TObject RetObj = DbSet.FirstOrDefault(predicate);
                if (RetObj != null)
                    return RetObj;
                else
                    throw new SQLInvalidRecordException("There are no relevant records available");
            }

            catch (SQLInvalidRecordException ex)
            {
                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLInvalidRecordException(ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLException(ex.Message);
            }

        }
        public virtual TObject Find(Expression<Func<TObject, bool>> predicate, params Expression<Func<TObject, object>>[] includeExpressions)
        {
            try
            {
                //TObject RetObj = DbSet.FirstOrDefault(predicate);
                IQueryable<TObject> RetObj = DbSet.Where(predicate).AsQueryable<TObject>();
                foreach (var includeExpression in includeExpressions)
                {
                    RetObj = RetObj.Include(includeExpression);
                }
                if (RetObj != null && RetObj.Count() > 0)
                    return RetObj.FirstOrDefault();
                else
                    throw new SQLInvalidRecordException("There are no relevant records available");
            }
            catch (SQLInvalidRecordException ex)
            {
                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLInvalidRecordException(ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLException(ex.Message);
            }

        }
        public virtual TObject Create(TObject TObject)
        {
            try
            {
                TObject RetObj = DbSet.Add(TObject);
                Context.SaveChanges();
                if (RetObj != null)
                    return RetObj;
                else
                    throw new SQLSaveException("There are no relevant records available");
            }
            catch (SQLSaveException ex)
            {
                TObject RetObj = DbSet.Remove(TObject);
                Context.SaveChanges();

                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLSaveException(ex.Message);
            }
            catch (System.Data.Entity.Core.OptimisticConcurrencyException ex)
            {
                var ctx = ((IObjectContextAdapter)Context).ObjectContext;
                ctx.Refresh(RefreshMode.ClientWins, TObject);
                ctx.SaveChanges();
                throw new Exception(ex.Message);
            }
            catch (DbEntityValidationException e)
            {
                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:",
                        DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format(
                            "- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage));
                    }
                }
                foreach (var item in outputLines)
                {
                    LogError(item);
                }
                throw new SQLException(e.Message);
            }
            catch (Exception ex)
            {
                TObject RetObj = DbSet.Remove(TObject);
                Context.SaveChanges();

                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLException(ex.Message);
            }

        }
        public virtual IQueryable<TObject> Create(IEnumerable<TObject> TObject)
        {
            try
            {
                IEnumerable<TObject> RetObj = DbSet.AddRange(TObject);
                Context.SaveChanges();
                if (RetObj != null)
                    return RetObj.AsQueryable();
                else
                    throw new SQLSaveException("There are no relevant records available");
            }
            catch (SQLSaveException ex)
            {
                IEnumerable<TObject> RetObj = DbSet.RemoveRange(TObject);
                Context.SaveChanges();

                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLSaveException(ex.Message);
            }
            catch (System.Data.Entity.Core.OptimisticConcurrencyException ex)
            {
                var ctx = ((IObjectContextAdapter)Context).ObjectContext;
                ctx.Refresh(RefreshMode.ClientWins, TObject);
                ctx.SaveChanges();
                throw new Exception(ex.Message);
            }
            catch (DbEntityValidationException e)
            {
                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:",
                        DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format(
                            "- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage));
                    }
                }
                foreach (var item in outputLines)
                {
                    LogError(item);
                }
                throw new SQLException(e.Message);
            }
            catch (Exception ex)
            {
                IEnumerable<TObject> RetObj = DbSet.RemoveRange(TObject);
                Context.SaveChanges();

                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLException(ex.Message);
            }

        }
        public virtual int Count
        {
            get
            {
                try
                {
                    int RetObj = DbSet.Count();
                    return RetObj;
                }
                catch (SQLNoRecordExeption ex)
                {
                    if (ex.InnerException != null)
                        LogError(ex.InnerException.InnerException.Message);
                    else
                        LogError(ex.Message);
                    throw new SQLNoRecordExeption(ex.Message);
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                        LogError(ex.InnerException.InnerException.Message);
                    else
                        LogError(ex.Message);
                    throw new SQLException(ex.Message);
                }

            }
        }
        public virtual bool Delete(TObject TObject)
        {
            try
            {
                DbSet.Attach(TObject);
                TObject RetObj = DbSet.Remove(TObject);
                Context.SaveChanges();
                if (RetObj != null)
                    return true;
                else
                    return false;
            }
            catch (SQLDeleteException ex)
            {
                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLDeleteException(ex.Message);
            }
            catch (System.Data.Entity.Core.OptimisticConcurrencyException ex)
            {
                var ctx = ((IObjectContextAdapter)Context).ObjectContext;
                ctx.Refresh(RefreshMode.ClientWins, TObject);
                ctx.SaveChanges();
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLException(ex.Message);
            }

        }
        public virtual bool Update(TObject TObject)
        {
            try
            {
                var entry = Context.Entry(TObject);
                DbSet.Attach(TObject);
                entry.State = System.Data.Entity.EntityState.Modified;

                Context.SaveChanges();

                if (entry != null)
                    return true;
                else
                    throw new SQLUpdateException("There are no relevant records available");
            }
            catch (SQLUpdateException ex)
            {
                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLUpdateException(ex.Message);
            }
            catch (System.Data.Entity.Core.OptimisticConcurrencyException ex)
            {
                var ctx = ((IObjectContextAdapter)Context).ObjectContext;
                ctx.Refresh(RefreshMode.ClientWins, TObject);
                ctx.SaveChanges();
                throw new Exception(ex.Message);
            }
            catch (DbEntityValidationException e)
            {
                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:",
                        DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format(
                            "- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage));
                    }
                }
                foreach (var item in outputLines)
                {
                    LogError(item);
                }
                throw new SQLException(e.Message);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLException(ex.Message);
            }

        }
        public virtual bool Delete(Expression<Func<TObject, bool>> predicate)
        {
            try
            {
                var objects = FilterNoException(predicate);
                foreach (var obj in objects)
                    DbSet.Remove(obj);
                Context.SaveChanges();
                if (objects != null)
                    return true;
                else
                    throw new SQLDeleteException("There are no relevant records available");
            }
            catch (SQLDeleteException ex)
            {
                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLDeleteException(ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    LogError(ex.InnerException.InnerException.Message);
                else
                    LogError(ex.Message);
                throw new SQLException(ex.Message);
            }

        }


        public void LogError(string error)
        {
            try
            {
                if (error == "There is no record available") { }
                else if (error == "There are no relevant records available") { }
                else
                {
                    //string path = HttpContext.Current.Server.MapPath("~/Log/LogErrors.txt");
                    //System.IO.File.AppendAllLines(path, new List<string> { DateTime.Now.ToString() + " - " + error });
                }
            }
            catch (Exception ex) { }
        }
    }
}
