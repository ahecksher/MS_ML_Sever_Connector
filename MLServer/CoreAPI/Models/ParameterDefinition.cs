// Code generated by Microsoft (R) AutoRest Code Generator 1.2.2.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace MMLServer.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class ParameterDefinition
    {
        /// <summary>
        /// Initializes a new instance of the ParameterDefinition class.
        /// </summary>
        public ParameterDefinition()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ParameterDefinition class.
        /// </summary>
        /// <param name="name">The name of the parameter object.</param>
        /// <param name="type">The type of the parameter object. Possible
        /// values include: 'logical', 'numeric', 'integer', 'character',
        /// 'vector', 'matrix', 'data.frame'</param>
        public ParameterDefinition(string name = default(string), string type = default(string))
        {
            Name = name;
            Type = type;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the name of the parameter object.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the parameter object. Possible values
        /// include: 'logical', 'numeric', 'integer', 'character', 'vector',
        /// 'matrix', 'data.frame'
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

    }
}
