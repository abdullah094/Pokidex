using System;
namespace Pokedex.Api.Models
{
    public class Succes
    {
        /// <summary>
        /// Number of translations
        /// </summary>
        public int? Total { get; set; }
    }

    public class Contents
    {
        /// <summary>
        /// Translated text
        /// </summary>
        public string Translated { get; set; }

        /// <summary>
        /// Text to translate
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// The type of transalation
        /// </summary>
        public string Translation { get; set; }
    }

    /// <summary>
    /// Translation api response model
    /// </summary>
    public class TranslationApiResponse
    {
        public Succes Succes { get; set; }
        public Contents Contents { get; set; }

        public TranslationApiResponse()
        {
            Succes = new Succes();
            Contents = new Contents();
        }
    }


}
