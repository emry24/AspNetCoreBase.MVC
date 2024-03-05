using Infrastructure.Contexts;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;
public abstract class Repo<TEntity>(DataContext context) where TEntity : class 
{
    private readonly DataContext _context = context;

    public virtual async Task<ResponseResult> CreateOneasync(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return ResponseFactory.Ok(entity);
        }
        catch (Exception ex) 
        {
            return ResponseFactory.Error(ex.Message);
        }
   
    }

    public virtual async Task<ResponseResult> GetResultAsync()
    {
        try
        {
            var result = await _context.Set<TEntity>().ToListAsync();
            return ResponseFactory.Ok(result);
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }

    }

    public virtual async Task<ResponseResult> GetOneAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<TEntity>().ToListAsync();
            return ResponseFactory.Ok(result);
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }

    }
}
