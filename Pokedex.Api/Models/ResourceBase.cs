namespace Pokedex.Api.Models
{
    /// <summary>
    /// The base class for classes that have an API endpoint
    /// </summary>
    public abstract class ResourceBase
    {
        /// <summary>
        /// The identifier for this resource
        /// </summary>
        public abstract int Id { get; set; }
    }

    /// <summary>
    /// The base class for API resources that have a name property
    /// </summary>
    public abstract class NamedApiResource : ResourceBase
    {
        /// <summary>
        /// The name of this resource
        /// </summary>
        public abstract string Name { get; set; }
    }

    /// <summary>
    /// The base class for API resources that don't have a name property
    /// </summary>
    public abstract class ApiResource : ResourceBase { }

    /// <summary>
    /// Allows for automatic fetching of a resource via a url
    /// </summary>
    public abstract class UrlNavigation<T> where T : ResourceBase
    {
        /// <summary>
        /// Url of the referenced resource
        /// </summary>
        public string Url { get; set; }
    }
}
