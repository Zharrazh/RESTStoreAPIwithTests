﻿using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTStoreAPI.Setup.Sieve
{
    public class SieveCustomFilterMethods : ISieveCustomFilterMethods
    {
        //public IQueryable<Post> IsNew(IQueryable<Post> source, string op, string[] values) // The method is given the {Operator} & {Value}
        //{
        //    var result = source.Where(p => p.LikeCount < 100 &&
        //                                    p.CommentCount < 5);

        //    return result; // Must return modified IQueryable<TEntity>
        //}

        //public IQueryable<T> Latest<T>(IQueryable<T> source, string op, string[] values) where T : BaseEntity // Generic functions are allowed too
        //{
        //    var result = source.Where(c => c.DateCreated > DateTimeOffset.UtcNow.AddDays(-14));
        //    return result;
        //}
    }
}
