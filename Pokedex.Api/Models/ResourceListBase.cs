﻿using System.Collections.Generic;

namespace Pokedex.Api.Models
{
    /// <summary>
    /// The base class for all resource lists
    /// </summary>
    public abstract class ResourceIEnumerable<T> where T : ResourceBase
    {
        /// <summary>
        /// The total number of resources available from this API
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// The URL for the next page in the list.
        /// </summary>
        public string Next { get; set; }

        /// <summary>
        /// The URL for the previous page in the list.
        /// </summary>
        public string Previous { get; set; }
    }

    /// <summary>
    /// The paging object for un-named resources
    /// </summary>
    /// <typeparam name="T">The type of the paged resource</typeparam>
    public class ApiResourceIEnumerable<T> : ResourceIEnumerable<T> where T : ApiResource
    {
        /// <summary>
        /// An enumerable of un-named API resources.
        /// </summary>
        public IEnumerable<ApiResource<T>> Results { get; set; }
    }

    /// <summary>
    /// The paging object for named resources
    /// </summary>
    /// <typeparam name="T">The type of the paged resource</typeparam>
    public class NamedApiResourceIEnumerable<T> : ResourceIEnumerable<T> where T : NamedApiResource
    {
        /// <summary>
        /// An enumerable of named API resources.
        /// </summary>
        public IEnumerable<NamedApiResource<T>> Results { get; set; }
    }
}
