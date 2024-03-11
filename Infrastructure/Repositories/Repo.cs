using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;
public abstract class Repo<TEntity>(UserDbContext context) where TEntity : class
{
    private readonly UserDbContext _context = context;

    public virtual async Task<TEntity> CreateOneAsync(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    //public virtual async Task<ResponseResult> GetAllAsync()
    //{
    //    try
    //    {
    //        IEnumerable<TEntity> result = await _context.Set<TEntity>().ToListAsync();
    //        return ResponseFactory.Ok(result);
    //    }
    //    catch (Exception ex)
    //    {
    //        return ResponseFactory.Error(ex.Message);
    //    }
    //}

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        try
        {
            var entities = await _context.Set<TEntity>().ToListAsync();
            if (entities != null)
            {
                return entities;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public virtual async Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            if (result != null)
            {
                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }

    //public virtual async Task<ResponseResult> UpdateOneAsync(Expression<Func<TEntity, bool>> predicate, TEntity updatedEntity)
    //{
    //    try
    //    {
    //        var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
    //        if (result != null)
    //        {
    //            _context.Entry(result).CurrentValues.SetValues(updatedEntity);
    //            await _context.SaveChangesAsync();
    //            return ResponseFactory.Ok(result);
    //        }
    //        return ResponseFactory.NotFound();

    //    }
    //    catch (Exception ex)
    //    {
    //        return ResponseFactory.Error(ex.Message);
    //    }
    //}

    public virtual async Task<TEntity> UpdateOneAsync(Expression<Func<TEntity, bool>> expression, TEntity updatedEntity)
    {
        try
        {
            var entityToUpdate = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
            if (entityToUpdate != null)
            {
                _context.Entry(entityToUpdate).CurrentValues.SetValues(updatedEntity);
                await _context.SaveChangesAsync();
                return entityToUpdate;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    //public virtual async Task<ResponseResult> DeleteOneAsync(Expression<Func<TEntity, bool>> predicate)
    //{
    //    try
    //    {
    //        var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
    //        if (result != null)
    //        {
    //            _context.Set<TEntity>().Remove(result);
    //            await _context.SaveChangesAsync();
    //            return ResponseFactory.Ok("Successfully removed");
    //        }
    //        return ResponseFactory.NotFound();

    //    }
    //    catch (Exception ex)
    //    {
    //        return ResponseFactory.Error(ex.Message);
    //    }
    //}

    public virtual async Task<bool> DeleteOneAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();

                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return false;
    }

    //public virtual async Task<ResponseResult> AlreadyExistsAsync(Expression<Func<TEntity, bool>> predicate)
    //{
    //    try
    //    {
    //        var result = await _context.Set<TEntity>().AnyAsync(predicate);
    //        if (result)
    //            return ResponseFactory.Exists();

    //        return ResponseFactory.NotFound();

    //    }
    //    catch (Exception ex)
    //    {
    //        return ResponseFactory.Error(ex.Message);
    //    }
    //}

    public virtual async Task<bool> AlreadyExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var existing = await _context.Set<TEntity>().AnyAsync(expression);
            return existing;
            //return _context.Set<TEntity>().Any(expression);
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return false;
    }
}
